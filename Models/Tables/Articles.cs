using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Comp2003_API_V1.Models.Tables
{
    public class Articles
    {

        [Key]
        [Required]
        public int ArticleID { get; set; }
        [Required]
        [MaxLength(50)]
        public string ArticleURL { get; set; }


        public virtual ICollection<ArticleLinking> ArticleLinking { get; set; }
    }
}
