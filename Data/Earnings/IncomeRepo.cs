using FinancesServer.Models.Earnings;
using Microsoft.EntityFrameworkCore;

namespace FinancesServer.Data.Earnings
{
    public class IncomeRepo : IIncomeRepo
    {
        private readonly FinancesDbContext _context;

        public IncomeRepo(FinancesDbContext context)
        {
            _context = context;
        }

        public async Task CreateIncome(Income inc)
        {
            if (inc is null)
                throw new ArgumentNullException(nameof(inc));

            await _context.AddAsync(inc);
        }

        public void DeleteIncome(Income inc)
        {
            if (inc is null)
                throw new ArgumentNullException(nameof(inc));

            _context.Earnings.Remove(inc);
        }

        public async Task<IEnumerable<Income>> GetAllEarnings()
        {
            return await _context.Earnings.ToListAsync();
        }

        public async Task<Income?> GetIncomeById(int id)
        {
            return await _context.Earnings.FirstOrDefaultAsync(inc => inc.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}