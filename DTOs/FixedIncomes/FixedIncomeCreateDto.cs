using System.ComponentModel.DataAnnotations;
using FinancesServer.Models.FixedIncomes;
using FinancesServer.Models.Shared;

namespace FinancesServer.DTOs.FixedIncomes
{
    public class FixedIncomeCreateDto
    {
        [Required]
        [StringLength(50)]
        public string? Description {get;set;}

        [Required]
        public decimal Amount {get;set;} 

        [Required]
        public FixedIncomeCategoryEnum Category { get; set; }

        [Required]
        public MonthEnum MonthOfFirstPayment {get;set;} 
    }
}