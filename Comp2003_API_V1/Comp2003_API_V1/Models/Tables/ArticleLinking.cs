using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Comp2003_API_V1.Models.Tables
{
    public class ArticleLinking
    {
        [Key]
        [Required]
        [Column(Order = 0)]
        [ForeignKey("Articles")]
        public int ArticleID { get; set; }
        [Key]
        [Required]
        [Column(Order = 1)]
        [ForeignKey("Cocktails")]
        public int CocktailID { get; set; }

        public virtual Articles Articles { get; set; }
        public virtual Cocktails Cocktails { get; set; }
    }
}
