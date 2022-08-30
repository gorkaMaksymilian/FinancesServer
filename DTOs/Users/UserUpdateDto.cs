using System.ComponentModel.DataAnnotations;
using FinancesServer.Models.Shared;

namespace FinancesServer.DTOs.Users
{
    public class UserUpdateDto 
    {
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