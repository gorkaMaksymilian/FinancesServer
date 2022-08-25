using System.ComponentModel.DataAnnotations;

namespace FinancesServer.Models.Shared
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string? Username { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required, MinLength(8), MaxLength(30)]
        public string? Password {get; set;}
        
        [Required]        
        public AuthLevelEnum AuthLevel { get; set; }
    }
}