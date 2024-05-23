# Documentation for the Liquorpedia API and back end:

This API is written using C# and ASP.NET Core 8.0. This repository contains the source code for the API, including the models, context and endpoints files.

The API is deployed using google cloud run via the link made by google cloud build to this repository. A push to this repository will trigger a build onto google cloud run and the updated API will be deployed and any change made will take affect.

the swagger page for the endpoints can be accessed via:

https://liquorpediaapi-tvchhbdpga-uk.a.run.app/swagger/index.html

the endpoints can be accessed in postman via:

https://liquorpediaapi-tvchhbdpga-uk.a.run.app/V2/Endpoints/EndpointName

In compliance with RESTful API principles, all GET and DELETE http requests are made with variables in the request URL, like:

https://liquorpediaapi-tvchhbdpga-uk.a.run.app/V2/Endpoints/EndpointName?VariableName=X

the POST and PUT methods are made with a JSON object in the request body for further security (JSON objects in the body can be encrypted), like:

https://liquorpediaapi-tvchhbdpga-uk.a.run.app/V2/Endpoints/EndpointName
{
          "VariableName":"Contents",
          "VariableName":"Contents"
}

The following details what variables should be used for every endpoint:

GET REQUESTS:

"ReadVideo": will return any videos linked to a cocktail. Takes "int cocktailID" as parameter

"ReadCocktailByIngredient": will return all cocktail information of cocktails that contain the specified ingredient, and any like it. takes "string ingredientName" as a parameter

"ReadCocktailByName": will return all cocktails of the specified name, and any like it. takes "string cocktailName" as a parameter

"ReadArticles": will return any articles linked to a cocktail. Takes "int cocktailID" as a parameter

"ReadCocktailDetails": will return a cocktail linked to a cocktail ID. Takes "int cocktailID" as a parameter

"ReadAllCocktailDetails": will return all cocktail details in the database.

"ReadCocktailTags": will return all tags linked to a cocktail. Takes "int cocktailID" as a parameter

"ReadIngredientsForCocktail": will return all ingredients linked to a cocktail. Takes "int cocktailID" as a parameter

"ReadCocktailsForTag": will return all cocktails that are linked to a tag. Takes "string tagName" as a parameter

"ReadUserFavourites": will return all cocktail IDs, cocktail name, cocktail picture and units linked to a user account. Takes "string currentEmail" as a parameter

"ReadUserFlags": will return all flags (notification and age) linked to a user account. Takes "string currentEmail" as a parameter

DELETE REQUESTS:

"DeleteFavouriteCocktail": will delete an entry of a users favourite cocktail. Takes "int cocktailID" and "string currentEmail" as parameters. will delete the entry related to that user and that cocktail

POST REQUESTS:

"CreateNewFavourite": will create a new entry for a users favourite cocktail. takes "currentEmail" and "cocktailID" as parameters in the JSON object

"CreateUserFlag": will create a new entry for a users preferences. takes "currentEmail", "ageVerificationFlag", and "notificationFlag" as parameters in the JSON object

PUT REQUESTS:

"UpdateUserFlags": will overwrite the current user preferences with the specified options. takes "currentEmail", "newEmail", "ageVerificationFlag" and "notificationFlag" as parameters in the JSON object. NOTE: only the desired fields must be filled, along with the "currentEmail" field

