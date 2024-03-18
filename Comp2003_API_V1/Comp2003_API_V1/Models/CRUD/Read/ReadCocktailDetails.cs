namespace Comp2003_API_V1.Models.CRUD.Read
{
    public class ReadCocktailDetails
    {
        public int CocktailID { get; set; }
        public string CocktailName { get; set; }
        public string CocktailDescription { get; set; }
        public int Difficulty { get; set; }
        public string? CocktailPicture { get; set; }
        public string Recipe { get; set; }
        public decimal Units { get; set; }
    }
}

