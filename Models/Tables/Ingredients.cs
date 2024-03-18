using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Comp2003_API_V1.Models.Tables
{
    public class Ingredients
    {

        [Key]
        [Required]
        public int IngredientID { get; set; }
        [Required]
        [MaxLength(34)]
        public string IngredientName { get; set; }
        [Required]
        public decimal Cost { get; set; }

        public virtual ICollection<IngredientLinking> IngredientLinking { get; set; }
    }
}
