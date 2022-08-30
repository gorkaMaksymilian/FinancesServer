using System.ComponentModel.DataAnnotations;

namespace FinancesServer.Models.Earnings
{
    public class Income
    {
        [Key]
        public int Id {get;set;}

        [Required]
        public DateTime? Date {get;set;}

        [Required]
        [StringLength(50)]
        public string? Description {get;set;}

        [Required]
        public decimal Amount {get;set;}

        [Required]
        public IncomeCategoryEnum Category {get;set;}

        [Required]
        public int UserId {get;set;}
    }
}