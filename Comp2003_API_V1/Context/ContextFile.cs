using Microsoft.EntityFrameworkCore;
using Comp2003_API_V1.Models.Tables;
using Comp2003_API_V1.Models.CRUD.Read;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace Comp2003_API_V1.Context
{
    public class ContextFile : DbContext
    {
        private readonly IConfiguration _configuration;

        public ContextFile(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        //Call the models for tables
        public DbSet<ArticleLinking> ArticleLinking { get; set; }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<CocktailLinking> CocktailLinking { get; set; }
        public DbSet<Cocktails> Cocktails { get; set; }
        public DbSet<IngredientLinking> IngredientILinking { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<TagLinking> TagLinking { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<UserFlags> UserFlags { get; set; }
        public DbSet<VideoLinking> VideoLinking { get; set; }
        public DbSet<Videos> Videos { get; set; }
        public DbSet<ReadCocktailTags> ReadCocktailTags { get; set; }
        public DbSet<ReadIngredientsForCocktail> ReadIngredientsForCocktail { get; set; }
        public DbSet<ReadCocktailsForTag> ReadCocktailsForTag { get; set; }
        public DbSet<ReadUserFavourites> ReadUserFavourites { get; set; }
        public DbSet<ReadUserFlags> ReadUserFlags { get; set; }
        public DbSet<ReadCocktailDetails> ReadCocktailDetails { get; set; }
        public DbSet<ReadArticle> ReadArticle { get; set; }
        public DbSet<ReadCocktailsByName> ReadCocktailsByName { get; set; }
        public DbSet<ReadCocktailsForIngredient> ReadCocktailsForIngredient { get; set; }
        public DbSet<ReadVideo> ReadVideo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
             _configuration.GetConnectionString("MyConnection"),
             new MySqlServerVersion(new Version(8, 0, 0)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleLinking>()
                .HasKey(ArticleLinking => new { ArticleLinking.ArticleID, ArticleLinking.CocktailID });

            modelBuilder.Entity<ArticleLinking>()
                .HasOne(ArticleLinking => ArticleLinking.Articles)
                .WithMany(Articles => Articles.ArticleLinking)
                .HasForeignKey(Articles => Articles.ArticleID);

            modelBuilder.Entity<ArticleLinking>()
                .HasOne(ArticleLinking => ArticleLinking.Cocktails)
                .WithMany(Cocktails => Cocktails.ArticleLinking)
                .HasForeignKey(Cocktails => Cocktails.CocktailID);

            modelBuilder.Entity<VideoLinking>()
                .HasKey(VideoLinking => new { VideoLinking.VideoID, VideoLinking.CocktailID });

            modelBuilder.Entity<VideoLinking>()
                .HasOne(VideoLinking => VideoLinking.Videos)
                .WithMany(Videos => Videos.VideoLinking)
                .HasForeignKey(Videos => Videos.VideoID);

            modelBuilder.Entity<VideoLinking>()
                .HasOne(VideoLinking => VideoLinking.Cocktails)
                .WithMany(Cocktails => Cocktails.VideoLinking)
                .HasForeignKey(Cocktails => Cocktails.CocktailID);

            modelBuilder.Entity<CocktailLinking>()
                .HasKey(CocktailLinking => new { CocktailLinking.Email, CocktailLinking.CocktailID });

            modelBuilder.Entity<CocktailLinking>()
                .HasOne(CocktailLinking => CocktailLinking.Cocktails)
                .WithMany(Cocktails => Cocktails.CocktailLinking)
                .HasForeignKey(Cocktails => Cocktails.CocktailID);

            modelBuilder.Entity<CocktailLinking>()
                .HasOne(CocktailLinking => CocktailLinking.UserFlags)
                .WithMany(UserFlags => UserFlags.CocktailLinking)
                .HasForeignKey(UserFlags => UserFlags.Email);

            modelBuilder.Entity<TagLinking>()
                .HasKey(TagLinking => new { TagLinking.TagID, TagLinking.CocktailID });

            modelBuilder.Entity<TagLinking>()
                .HasOne(TagLinking => TagLinking.Tags)
                .WithMany(Tags => Tags.TagLinking)
                .HasForeignKey(Tags => Tags.TagID);

            modelBuilder.Entity<TagLinking>()
                .HasOne(TagLinking => TagLinking.Cocktails)
                .WithMany(Cocktails => Cocktails.TagLinking)
                .HasForeignKey(Cocktails => Cocktails.CocktailID);

            modelBuilder.Entity<IngredientLinking>()
                .HasKey(IngredientLinking => new { IngredientLinking.CocktailID, IngredientLinking.IngredientID });

            modelBuilder.Entity<IngredientLinking>()
                .HasOne(IngredientLinking => IngredientLinking.Cocktails)
                .WithMany(Cocktails => Cocktails.IngredientLinking)
                .HasForeignKey(Cocktails => Cocktails.CocktailID);

            modelBuilder.Entity<IngredientLinking>()
                .HasOne(IngredientLinking => IngredientLinking.Ingredients)
                .WithMany(Ingredients => Ingredients.IngredientLinking)
                .HasForeignKey(Ingredients => Ingredients.IngredientID);

            modelBuilder.Entity<Articles>()
                .HasKey(Articles =>  Articles.ArticleID);

            modelBuilder.Entity<Cocktails>()
                .HasKey(Cocktails => Cocktails.CocktailID);

            modelBuilder.Entity<Ingredients>()
                .HasKey(Ingredients => Ingredients.IngredientID);

            modelBuilder.Entity<Tags>()
                .HasKey(Tags => Tags.TagID);

            modelBuilder.Entity<UserFlags>()
                .HasKey(UserFlags => UserFlags.Email);

            modelBuilder.Entity<Videos>()
                .HasKey(Videos => Videos.VideoID);

            modelBuilder.Entity<ReadCocktailTags>()
                .HasNoKey();

            modelBuilder.Entity<ReadIngredientsForCocktail>()
                .HasNoKey();

            modelBuilder.Entity<ReadCocktailsForTag>()
                .HasNoKey();

            modelBuilder.Entity<ReadUserFavourites>()
                .HasNoKey();

            modelBuilder.Entity<ReadUserFlags>()
                .HasNoKey();

            modelBuilder.Entity<ReadCocktailDetails>()
                .HasNoKey();

            modelBuilder.Entity<ReadArticle>()
                .HasNoKey();

            modelBuilder.Entity<ReadCocktailsByName>()
                .HasNoKey();
            modelBuilder.Entity<ReadCocktailsForIngredient>()
                .HasNoKey();

            modelBuilder.Entity<ReadCocktailsForTag>()
                .HasNoKey();

            modelBuilder.Entity<ReadVideo>()
                .HasNoKey();

            base.OnModelCreating(modelBuilder);
        }


        //GET
        public async Task<IEnumerable<ReadCocktailTags>> ReadCocktailTagsContext(int? givenCocktailID)
        {
            return await ReadCocktailTags.FromSqlRaw("CALL lqp.ReadCocktailTags(@p0)", givenCocktailID).ToListAsync();
        }

        public async Task<IEnumerable<ReadIngredientsForCocktail>> ReadIngredientsForCocktailContext(int? givenCocktailID)
        {
            return await ReadIngredientsForCocktail.FromSqlRaw("CALL lqp.ReadIngredientsForCocktail(@p0)", givenCocktailID).ToListAsync();
        }

        public async Task<IEnumerable<ReadCocktailsForTag>> ReadCocktailsForTagContext(string? givenTagName)
        {
            return await ReadCocktailsForTag.FromSqlRaw("CALL lqp.ReadCocktailsForTag(@p0)", givenTagName).ToListAsync();
        }

        public async Task<IEnumerable<ReadUserFavourites>> ReadUserFavouritesContext(string? userEmail)
        {
            return await ReadUserFavourites.FromSqlRaw("CALL lqp.ReadUserFavourites(@p0)", userEmail).ToListAsync();
        }

        public async Task<IEnumerable<ReadUserFlags>> ReadUserFlagsContext(string? userEmail)
        {
            return await ReadUserFlags.FromSqlRaw("CALL lqp.ReadUserFlags(@p0)", userEmail).ToListAsync();
        }

        public async Task<IEnumerable<ReadCocktailDetails>> GetCocktailDetailsContext(int? cocktailID)
        {
            return await ReadCocktailDetails
                .FromSqlRaw("CALL lqp.ReadCocktailDetails(@p0)", cocktailID)
                .ToListAsync();
        }
        public async Task<IEnumerable<ReadArticle>> GetArticleContext(int? cocktailID)
        {
            return await ReadArticle
                .FromSqlRaw("CALL lqp.ReadArticle(@p0)", cocktailID)
                .ToListAsync();
        }
        public async Task<IEnumerable<ReadCocktailsByName>> GetCocktailByNameContext(string? CocktailName)
        {
            return await ReadCocktailsByName
                .FromSqlRaw("CALL lqp.ReadCocktailsByName(@p0)", CocktailName)
                .ToListAsync();
        }
        public async Task<IEnumerable<ReadCocktailsForIngredient>> GetCocktailsByIngredientContext(string? Ingredient)
        {
            return await ReadCocktailsForIngredient
                .FromSqlRaw("CALL lqp.ReadCocktailsForIngredient(@p0)", Ingredient)
                .ToListAsync();
        }
        public async Task<IEnumerable<ReadVideo>> GetVideoContext(int? cocktailID)
        {
            return await ReadVideo
                .FromSqlRaw("CALL lqp.ReadVideo(@p0)", cocktailID)
                .ToListAsync();
        }

        //PUT
        public async Task UpdateUserFlagsContext(string? param_old_email, string? param_new_email, int? param_age_verification_flag, int? param_notification_flag)
        {
            var sql = "CALL UpdateUserFlags(@p0, @p1, @p2, @p3)";

            await Database.ExecuteSqlRawAsync(sql, param_old_email, param_new_email, param_age_verification_flag, param_notification_flag);
        }

        //POST
        public async Task CreateNewFavouriteContext(string? NewEmail, int? NewCocktailID)
        {
            await Database.ExecuteSqlRawAsync("CALL lqp.CreateNewFavourite (@p0, @p1)", NewEmail, NewCocktailID);
        }
        public async Task CreateUserFlagsContext(string? Email, int? AgeVerificationFlag, int? NotificationsFlag)
        {
            await
                Database.ExecuteSqlRawAsync("CALL lqp.CreateUserFlag(@p0,@p1,@p2)", Email, AgeVerificationFlag, NotificationsFlag);
        }

        //DELETE
        public async Task DeleteFavouriteCocktailContext(int? CocktailID, string? Email)
        {
            await
                Database.ExecuteSqlRawAsync("CALL lqp.DeleteFavouriteCocktail(@p0,@p1)", CocktailID, Email);
        }

        public async Task DeleteUserFlagsContext(string? Email)
        {
            await
                Database.ExecuteSqlRawAsync("CALL lqp.DeleteUserFlags(@p0)", Email);
        }
    }
}
