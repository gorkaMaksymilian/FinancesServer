using FinancesServer.Models.FixedCosts;

namespace FinancesServer.Data
{
    public class FixedCostRepo : IFixedCostRepo
    {
        private readonly FinancesDbContext _context;

        public FixedCostRepo(FinancesDbContext context)
        {
            _context = context;
        }

        public Task CreateFixedCost(FixedCost exp)
        {
            throw new NotImplementedException();
        }

        public void DeleteFixedCost(FixedCost exp)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FixedCost>> GetAllCosts()
        {
            throw new NotImplementedException();
        }

        public Task<FixedCost?> GetFixedCostById(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}