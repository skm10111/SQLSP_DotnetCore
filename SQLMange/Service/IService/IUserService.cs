using SQLMange.DTO.User;

namespace SQLMange.Service.IService
{
    public interface IUserService
    {
        Task DeleteUser(int userId);
        Task UpdateUser(UserDTO user);
        Task InsertUser(UserAddDTO user);
        Task<UserDTO> GetUser(int userId);
        Task<List<UserDTO>> GetUsers();
    }
}
