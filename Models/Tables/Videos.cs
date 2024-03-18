using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Comp2003_API_V1.Models.Tables
{
    public class Videos
    {

        [Key]
        [Required]
        public int VideoID { get; set; }
        [Required]
        [MaxLength(50)]
        public string VideoURL { get; set; }

        public virtual ICollection<VideoLinking> VideoLinking { get; set; }
    }
}
