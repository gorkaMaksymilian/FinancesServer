using FinancesServer.Models.FixedCosts;
using FinancesServer.Models.Shared;

namespace FinancesServer.DTOs.FixedCosts
{
    public class FixedCostReadDto 
    {
        public int Id {get;set;}
        public string? Description {get;set;}
        public decimal Amount {get;set;} 
        public FixedCostCategoryEnum Category { get; set; }
        public MonthEnum MonthOfFirstPayment {get;set;} 
        public int UserId {get;set;}
    }
}