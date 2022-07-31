using FinancesServer.Models.Expenses;

namespace FinancesServer.DTOs.Expenses
{
    public class ExpenseReadDto
    {
        public int Id {get; set;}

        public DateTime? Date {get;set;}

        public string? Description {get;set;}

        public decimal Amount {get;set;}        

        public ExpenseCategoryEnum Category {get; set;}
    }
}