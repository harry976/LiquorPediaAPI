FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build-env

# Copy csproj and restore as distinct layers
COPY ./Comp2003_API_V1/Comp2003_API_V1.csproj ./Comp2003_API_V1/Comp2003_API_V1.csproj
COPY *.sln .
RUN dotnet restore

RUN dotnet tool install --global dotnet-ef

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o build --no-restore

ARG MIGRATION_CONNECTION
RUN dotnet ef database update --connection $MIGRATION_CONNECTION

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env ./build .
ENV ASPNETCORE_URLS=http://*:8080
EXPOSE 8080
ENTRYPOINT [ "dotnet", "Comp2003_API_V1.dll" ]