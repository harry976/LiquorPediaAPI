using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Comp2003_API_V1.Models.Tables
{
    public class TagLinking
    {

        [Key]
        [Required]
        [Column(Order = 0)]
        [ForeignKey("Tags")]
        public int TagID { get; set; }
        [Key]
        [Required]
        [Column(Order = 1)]
        [ForeignKey("Cocktails")]
        public int CocktailID { get; set; }

        public virtual Tags Tags { get; set; }
        public virtual Cocktails Cocktails { get; set; }
    }
}
