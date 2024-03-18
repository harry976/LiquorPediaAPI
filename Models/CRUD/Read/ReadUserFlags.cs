using System.ComponentModel.DataAnnotations;

namespace Comp2003_API_V1.Models.CRUD.Read
{
    public class ReadUserFlags
    {

        [Required]
        [MaxLength (254)]
        public string Email { get; set; }
        [Required]
        public int AgeVerificationFlag { get; set; }
        [Required]
        public int NotificationFlag { get; set; }

    }
}
