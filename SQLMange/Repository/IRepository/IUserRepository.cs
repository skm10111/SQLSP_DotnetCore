using SQLMange.DTO.User;
using SQLMange.Model;

namespace SQLMange.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserById(int userId);
        Task UpsertUser(UserDTO user);
        Task DeleteUser(int userId);
    }
}
