using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Comp2003_API_V1.Models.Tables
{
    public class Tags
    {

        [Key]
        [Required]
        public int TagID { get; set; }
        [Required]
        [MaxLength(15)]
        public string Tag { get; set; }

        public virtual ICollection<TagLinking> TagLinking { get; set; }
    }
}
