using System.ComponentModel.DataAnnotations;
using FinancesServer.Models.FixedCosts;
using FinancesServer.Models.Shared;

namespace FinancesServer.DTOs.FixedCosts
{
    public class FixedCostCreateDto
    {
        [Required]
        [StringLength(50)]
        public string? Description {get;set;}

        [Required]
        public decimal Amount {get;set;} 

        [Required]
        public FixedCostCategoryEnum Category { get; set; }

        [Required]
        public MonthEnum MonthOfFirstPayment {get;set;} 
    }
}