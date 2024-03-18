using System.ComponentModel.DataAnnotations;

namespace Comp2003_API_V1.Models.CRUD.Read
{
    public class ReadUserFavourites
    {

        [Required]
        [MaxLength (254)]
        public string Email { get; set; }
        [Required]
        [MaxLength(30)]
        public string CocktailName { get; set; }
        [Required]
        [MaxLength(255)]
        public string CocktailPicture { get; set; }
        [Required]
        public decimal Units { get; set; }

    }
}
