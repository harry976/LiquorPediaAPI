using System.ComponentModel.DataAnnotations;

namespace Comp2003_API_V1.Models.CRUD.Read
{
    public class ReadIngredientsForCocktail
    {

        [Required]
        [MaxLength(34)]
        public string IngredientName { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public float MeasurementsML { get; set; }

    }
}
