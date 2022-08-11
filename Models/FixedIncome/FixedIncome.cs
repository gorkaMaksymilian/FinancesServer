using System.ComponentModel.DataAnnotations;
using FinancesServer.Models.Shared;

namespace FinancesServer.Models.FixedIncome
{
    public class FixedIncome
    {
        [Key]
        public int Id {get;set;}

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