using FinancesServer.Models.FixedIncomes;
using FinancesServer.Models.Shared;

namespace FinancesServer.DTOs.FixedIncomes
{
    public class FixedIncomeReadDto
    {
        public int Id {get;set;}
        public string? Description {get;set;}
        public decimal Amount {get;set;} 
        public FixedIncomeCategoryEnum Category { get; set; }
        public MonthEnum MonthOfFirstPayment {get;set;} 
        public int UserId {get;set;}
    }
}