using Microsoft.EntityFrameworkCore;
using SQLMange.Data;
using SQLMange.DTO.User;
using SQLMange.Model;
using SQLMange.Repository.IRepository;

namespace SQLMange.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.User.FromSqlInterpolated($"exec sp_GetUsers").ToListAsync();
        }
        public async Task<User> GetUserById(int userId)
        {
            var result = (await _context.User.FromSqlRaw($"exec sp_GetUserById @UserId={userId}").ToListAsync());
            if (result.Count > 0) return result[0];
            return null;
        }
        public async Task UpsertUser(UserDTO user)
        {
            await _context.Database.ExecuteSqlAsync($"exec sp_UpsertUser @UserId={user.UserId}, @Username={user.UserName}, @Adderss={user.Adderss}, @PhoneNumber={user.PhoneNumber}, @Email={user.PhoneNumber}");
        }
        public async Task DeleteUser(int userId)
        {
            await _context.Database.ExecuteSqlAsync($"sp_DeleteUser @UserID={userId}");
        }
    }
}
