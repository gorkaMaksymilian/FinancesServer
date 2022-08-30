using System.ComponentModel.DataAnnotations;
using FinancesServer.Models.Expenses;

namespace FinancesServer.DTOs.Expenses
{
    public class ExpenseUpdateDto
    {
        [Required]
        public DateTime? Date {get;set;}

        [Required]
        [StringLength(50)]
        public string? Description {get;set;}

        [Required]
        public decimal Amount {get;set;}        

        [Required]
        public ExpenseCategoryEnum Category {get; set;}

        [Required]
        public int UserId {get;set;}
    }
}