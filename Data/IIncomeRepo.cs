using FinancesServer.Models.Earnings;

namespace FinancesServer.Data
{
    public interface IIncomeRepo
    {
        Task SaveChanges();
        Task<Income> GetIncomeById(int id);
        Task<IEnumerable<Income>> GetAllEarnings();
        Task CreateIncome(Income inc);

        void DeleteIncome(Income inc);
    }
}