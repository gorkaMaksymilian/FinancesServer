using FinancesServer.Models.FixedIncomes;
using Microsoft.EntityFrameworkCore;

namespace FinancesServer.Data.FixedIncomes
{
    public class FixedIncomeRepo : IFixedIncomeRepo
    {
        private readonly FinancesDbContext _context;

        public FixedIncomeRepo(FinancesDbContext context)
        {
            _context = context;
        }

        public async Task CreateFixedIncome(FixedIncome fInc)
        {
            if (fInc is null)
                throw new ArgumentNullException(nameof(fInc));

            await _context.AddAsync(fInc);
        }

        public void DeleteFixedIncome(FixedIncome fInc)
        {
            if (fInc is null)
                throw new ArgumentNullException(nameof(fInc));

            _context.FixedIncomes.Remove(fInc);
        }

        public async Task<IEnumerable<FixedIncome>> GetAllFixedIncomes()
        {
            return await _context.FixedIncomes.ToListAsync();
        }

        public async Task<FixedIncome?> GetFixedIncomeById(int id)
        {
            return await _context.FixedIncomes.FirstOrDefaultAsync(fInc => fInc.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}