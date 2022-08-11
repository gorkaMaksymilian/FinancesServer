using FinancesServer.Models.Earnings;
using FinancesServer.Models.Expenses;
using FinancesServer.Models.FixedCosts;
using FinancesServer.Models.FixedIncomes;
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

        public DbSet<FixedIncome> FixedIncomes => Set<FixedIncome>();
        public DbSet<FixedCost> FixedCosts => Set<FixedCost>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Sets custom precision (in sql table) for Income.Amount and Expense.Amount properties
            modelBuilder.Entity<Income>().Property(p => p.Amount).HasPrecision(18,2);
            modelBuilder.Entity<Expense>().Property(p => p.Amount).HasPrecision(18,2);

            // Sets custom precision (in sql table) for FixedIncome.Amount and FixedCost.Amount properties
            modelBuilder.Entity<FixedIncome>().Property(p => p.Amount).HasPrecision(18,2);
            modelBuilder.Entity<FixedCost>().Property(p => p.Amount).HasPrecision(18,2);

            base.OnModelCreating(modelBuilder);
        }
    }
}