using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Comp2003_API_V1.Models.Tables
{
    public class UserFlags
    {

        [Key]
        [Required]
        [MaxLength(254)]
        public string Email { get; set; }
        [Required]
        public bool AgeVerificationFlag { get; set; }
        [Required]
        public bool NotificationFlag { get; set; }

        public virtual ICollection<CocktailLinking> CocktailLinking { get; set; }
    }
}
