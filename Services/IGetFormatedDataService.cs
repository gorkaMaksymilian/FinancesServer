using FinancesServer.Models.Dashboard;
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
        Task<IEnumerable<FixedIncome>> GetFixedCostsByUserId(int userId);
        Task<IEnumerable<FixedIncome>> GetIncomesByUserId(int userId);
        Task<IEnumerable<FixedIncome>> GetExpensesByUserId(int userId);
    }
}