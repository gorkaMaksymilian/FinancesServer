using FinancesServer.Models.Dashboard;

namespace FinancesServer.Services
{
    public interface IGetFormatedDataService
    {
        Task<IEnumerable<MonthlyItem>> GetMonthlyEarnings(int month, int year);
        Task<IEnumerable<MonthlyItem>> GetMonthlyExpenses(int month, int year);
        Task<IEnumerable<MonthlyItem>> GetFixedCosts(int month);
        Task<IEnumerable<MonthlyItem>> GetFixedIncomes(int month);
    }
}