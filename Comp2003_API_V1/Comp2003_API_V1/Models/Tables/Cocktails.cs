using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Comp2003_API_V1.Models.Tables
{
    public class Cocktails
    {

        [Key]
        [Required]
        public int CocktailID { get; set; }
        [Required]
        [MaxLength(30)]
        public string CocktailName { get; set; }
        [Required]
        [MaxLength(512)]
        public string CocktailDesription { get; set; }
        [Required]
        public int Difficulty { get; set; }
        [Required]
        [MaxLength(255)]
        public string CocktailPicture { get; set; }
        [Required]
        public decimal Units { get; set; }
        [Required]
        [MaxLength (1024)]
        public string Recipe { get; set; }

        public virtual ICollection<ArticleLinking> ArticleLinking { get; set; }
        public virtual ICollection<VideoLinking> VideoLinking { get; set; }
        public virtual ICollection<CocktailLinking> CocktailLinking { get; set; }
        public virtual ICollection<TagLinking> TagLinking { get; set; }
        public virtual ICollection<IngredientLinking> IngredientLinking { get; set; }
    }
}
