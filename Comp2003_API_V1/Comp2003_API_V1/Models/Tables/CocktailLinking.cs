using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Comp2003_API_V1.Models.Tables
{
    public class CocktailLinking
    {

        [Key]
        [Required]
        [Column(Order = 0)]
        [MaxLength(254)]
        [ForeignKey("UserFlags")]
        public string Email { get; set; }
        [Key]
        [Required]
        [Column(Order = 1)]
        [ForeignKey("Cocktails")]
        public int CocktailID { get; set; }

        public virtual UserFlags UserFlags { get; set; }
        public virtual Cocktails Cocktails { get; set; }
    }
}
