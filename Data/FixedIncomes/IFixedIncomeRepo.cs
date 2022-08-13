using FinancesServer.Models.FixedIncomes;

namespace FinancesServer.Data.FixedIncomes
{
    public interface IFixedIncomeRepo
    {
        Task SaveChanges();
        Task<FixedIncome?> GetFixedIncomeById(int id);
        Task<IEnumerable<FixedIncome>> GetAllFixedIncomes();
        Task CreateFixedIncome(FixedIncome fInc);

        void DeleteFixedIncome(FixedIncome fInc);
    }
}