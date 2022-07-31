using System.ComponentModel.DataAnnotations;

namespace FinancesServer.Models.Expenses
{
    public class Expense
    {
        [Key] 
        public int Id {get; set;}

        [Required]
        public DateTime? Date {get;set;}

        [Required]
        [StringLength(50)]
        public string? Description {get;set;}

        [Required]
        public decimal Amount {get;set;}        

        [Required]
        public ExpenseCategoryEnum Category {get; set;}
    }
}