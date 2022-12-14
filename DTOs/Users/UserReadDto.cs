using FinancesServer.Models.Shared;

namespace FinancesServer.DTOs.Users
{
    public class UserReadDto 
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password {get; set;}
        public AuthLevelEnum AuthLevel { get; set; }
    }
}