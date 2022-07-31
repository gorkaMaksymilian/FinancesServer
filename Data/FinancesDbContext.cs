using FinancesServer.Models.Earnings;
using FinancesServer.Models.Expenses;
using Microsoft.EntityFrameworkCore;

namespace FinancesServer.Data
{
    public class FinancesDbContext : DbContext
    {
        public FinancesDbContext(DbContextOptions<FinancesDbContext> options) : base(options)
        {
            
        }

        public DbSet<Income> Earnings => Set<Income>();
        public DbSet<Expense> Expenses => Set<Expense>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Income>().Property(p => p.Amount).HasPrecision(18,2);
            modelBuilder.Entity<Expense>().Property(p => p.Amount).HasPrecision(18,2);

            base.OnModelCreating(modelBuilder);
        }
    }
}