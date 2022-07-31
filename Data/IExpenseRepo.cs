using FinancesServer.Models.Expenses;

namespace FinancesServer.Data
{
    public interface IExpenseRepo
    {
        Task SaveChanges();
        Task<Expense?> GetExpenseById(int id);
        Task<IEnumerable<Expense>> GetAllExpenses();
        Task CreateExpense(Expense exp);


        void DeleteExpense(Expense exp);
    }
}