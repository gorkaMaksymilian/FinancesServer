using System.ComponentModel.DataAnnotations;
using FinancesServer.Models.Earnings;

namespace FinancesServer.DTOs.Earnings
{
    public class IncomeUpdateDto
    {
        [Required]
        public DateTime? Date {get;set;}

        [Required]
        [StringLength(50)]
        public string? Description {get;set;}

        [Required]
        public decimal Amount {get;set;}        

        [Required]
        public IncomeCategoryEnum Category {get; set;}

        [Required]
        public int UserId {get;set;}
    }
}