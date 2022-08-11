using FinancesServer.Models.FixedCosts;
using Microsoft.EntityFrameworkCore;

namespace FinancesServer.Data.FixedCosts
{
    public class FixedCostRepo : IFixedCostRepo
    {
        private readonly FinancesDbContext _context;

        public FixedCostRepo(FinancesDbContext context)
        {
            _context = context;
        }

        public async Task CreateFixedCost(FixedCost fExp)
        {
            if (fExp is null)
                throw new ArgumentNullException(nameof(fExp));

            await  _context.AddAsync(fExp);
        }

        public void DeleteFixedCost(FixedCost fExp)
        {
            if (fExp is null)
                throw new ArgumentNullException(nameof(fExp));
            
            _context.FixedCosts.Remove(fExp);
        }

        public async Task<IEnumerable<FixedCost>> GetAllCosts()
        {
            return await _context.FixedCosts.ToListAsync();
        }

        public async Task<FixedCost?> GetFixedCostById(int id)
        {
            return await _context.FixedCosts.FirstOrDefaultAsync(fExp => fExp.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}