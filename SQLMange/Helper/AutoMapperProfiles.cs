using AutoMapper;
using SQLMange.DTO.User;
using SQLMange.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SQLMange.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserAddDTO, UserDTO>().ReverseMap();
        }
    }
}
