using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Comp2003_API_V1.Models.Tables
{
    public class IngredientLinking
    {

        [Key]
        [Required]
        [Column(Order = 0)]
        [ForeignKey("Ingredients")]
        public int IngredientID { get; set; }
        [Key]
        [Required]
        [Column(Order = 1)]
        [ForeignKey("Cocktails")]
        public int CocktailID { get; set; }
        [Required]
        public float MeasurementsML { get; set; }

        public virtual Cocktails Cocktails { get; set; }
        public virtual Ingredients Ingredients { get; set; }
    }
}
