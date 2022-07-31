using FinancesServer.Models.Earnings;

namespace FinancesServer.DTOs.Earnings
{
    public class IncomeReadDto
    {
        public int Id {get; set;}

        public DateTime? Date {get;set;}

        public string? Description {get;set;}

        public decimal Amount {get;set;}        

        public IncomeCategoryEnum Category {get; set;}
    }
}