using FinancesServer.Models.Expenses;
using Microsoft.EntityFrameworkCore;

namespace FinancesServer.Data.Expenses
{
    public class ExpenseRepo : IExpenseRepo
    {
        private readonly FinancesDbContext _context;

        public ExpenseRepo(FinancesDbContext context)
        {
            _context = context;   
        }

        public async Task CreateExpense(Expense exp)
        {
            if (exp is null)
                throw new ArgumentNullException(nameof(exp));

            await  _context.AddAsync(exp);
        }

        public void DeleteExpense(Expense exp)
        {
            if (exp is null)
                throw new ArgumentNullException(nameof(exp));
            
            _context.Expenses.Remove(exp);
        }

        public async Task<IEnumerable<Expense>> GetAllExpenses()
        {
            return await _context.Expenses.ToListAsync();
        }

        public async Task<Expense?> GetExpenseById(int id)
        {
            return await _context.Expenses.FirstOrDefaultAsync(exp => exp.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}