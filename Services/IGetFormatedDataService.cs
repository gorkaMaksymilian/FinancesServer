using FinancesServer.Models.Dashboard;
using FinancesServer.Models.Earnings;
using FinancesServer.Models.Expenses;
using FinancesServer.Models.FixedCosts;
using FinancesServer.Models.FixedIncomes;

namespace FinancesServer.Services
{
    public interface IGetFormatedDataService
    {
        Task<IEnumerable<MonthlyItem>> GetMonthlyEarnings(int month, int year, int userId);
        Task<IEnumerable<MonthlyItem>> GetMonthlyExpenses(int month, int year, int userId);
        Task<IEnumerable<MonthlyItem>> GetFixedCosts(int month, int userId);
        Task<IEnumerable<MonthlyItem>> GetFixedIncomes(int month, int userId);


        Task<IEnumerable<FixedIncome>> GetFixedIncomesByUserId(int userId);
        Task<IEnumerable<FixedCost>> GetFixedCostsByUserId(int userId);
        Task<IEnumerable<Income>> GetIncomesByUserId(int userId);
        Task<IEnumerable<Expense>> GetExpensesByUserId(int userId);
    }
}