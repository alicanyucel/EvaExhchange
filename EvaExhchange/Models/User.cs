using System.ComponentModel.DataAnnotations;

namespace EvaExhchange.Models
{
    public class User
    {
        [Key]
        public string UserId { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
