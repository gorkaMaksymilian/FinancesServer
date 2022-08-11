using FinancesServer.Models.FixedIncome;
using FinancesServer.Models.Shared;

namespace FinancesServer.DTOs.FixedIncome
{
    public class FixedIncomeReadDto
    {
        public int Id {get;set;}
        public string? Description {get;set;}
        public decimal Amount {get;set;} 
        public FixedIncomeCategoryEnum Category { get; set; }
        public MonthEnum MonthOfFirstPayment {get;set;} 
    }
}