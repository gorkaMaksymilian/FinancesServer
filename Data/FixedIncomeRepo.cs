using FinancesServer.Models.FixedIncome;

namespace FinancesServer.Data
{
    public class FixedIncomeRepo : IFixedIncomeRepo
    {
        public Task CreateFixedIncome(FixedIncome fInc)
        {
            throw new NotImplementedException();
        }

        public void DeleteFixedIncome(FixedIncome fInc)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FixedIncome>> GetAllFixedIncomes()
        {
            throw new NotImplementedException();
        }

        public Task<FixedIncome?> GetFixedIncomeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}