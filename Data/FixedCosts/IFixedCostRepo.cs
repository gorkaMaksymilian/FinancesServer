using FinancesServer.Models.FixedCosts;

namespace FinancesServer.Data.FixedCosts
{
    public interface IFixedCostRepo
    {
        Task SaveChanges();
        Task<FixedCost?> GetFixedCostById(int id);
        Task<IEnumerable<FixedCost>> GetAllCosts();
        Task CreateFixedCost(FixedCost fExp);


        void DeleteFixedCost(FixedCost fExp);
    }
}