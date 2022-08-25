using FinancesServer.Models.Shared;

namespace FinancesServer.Data.Users
{
    public interface IUserRepo
    {
        Task SaveChanges();
        Task<User?> GetUserById(int id);
        Task<IEnumerable<User>> GetAllUsers();
        Task CreateUser(User inc);

        void DeleteUser(User inc);
    }
}