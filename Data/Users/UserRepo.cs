using FinancesServer.Models.Shared;
using Microsoft.EntityFrameworkCore;

namespace FinancesServer.Data.Users
{
    public class UserRepo : IUserRepo
    {
        private readonly FinancesDbContext _context;

        public UserRepo(FinancesDbContext context)
        {
            _context = context;
        }

        public async Task CreateUser(User user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            await _context.AddAsync(user);
        }

        public void DeleteUser(User user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            _context.Users.Remove(user);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}