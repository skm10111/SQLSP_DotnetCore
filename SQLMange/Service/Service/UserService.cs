using AutoMapper;
using SQLMange.DTO.User;
using SQLMange.Model;
using SQLMange.Repository.IRepository;
using SQLMange.Service.IService;

namespace SQLMange.Service.Service
{
    public class UserService: IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<List<UserDTO>> GetUsers()
        {
            return _mapper.Map<List<User>, List<UserDTO>>(await _userRepository.GetUsers());
        }
        public async Task<UserDTO> GetUser(int userId)
        {
            return _mapper.Map<User, UserDTO>(await _userRepository.GetUserById(userId));
        }
        public async Task UpdateUser(UserDTO user)
        {
            await _userRepository.UpsertUser(user);
        }
        public async Task InsertUser(UserAddDTO user)
        {
            await _userRepository.UpsertUser((_mapper.Map<UserAddDTO, UserDTO>(user)));
        }

        public async Task DeleteUser(int userId)
        {
            await _userRepository.DeleteUser(userId);
        }
    }
}
