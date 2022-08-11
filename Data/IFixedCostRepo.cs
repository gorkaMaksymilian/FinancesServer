using FinancesServer.Models.FixedCosts;

namespace FinancesServer.Data
{
    public interface IFixedCostRepo
    {
        Task SaveChanges();
        Task<FixedCost?> GetFixedCostById(int id);
        Task<IEnumerable<FixedCost>> GetAllCosts();
        Task CreateFixedCost(FixedCost exp);


        void DeleteFixedCost(FixedCost exp);
    }
}