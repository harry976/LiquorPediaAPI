using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Comp2003_API_V1.Models.Tables
{
    public class VideoLinking
    {

        [Key]
        [Required]
        [Column(Order = 0)]
        [ForeignKey("Videos")]
        public int VideoID { get; set; }
        [Key]
        [Required]
        [Column(Order = 1)]
        [ForeignKey("Cocktails")]
        public int CocktailID { get; set; }

        public virtual Cocktails Cocktails { get; set; }
        public virtual Videos Videos { get; set; }
    }
}
