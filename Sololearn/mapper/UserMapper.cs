using Sololearn.entity;
using SoloLearn.payload;
using Sololearn.repository.contract;
using Sololearn.repository.impls;

namespace Sololearn.mapper
{
    public class UserMapper : IEntityMapper<User, UserDto, UserRegisterDto>
    {
        private static UserMapper? instance;
        internal static UserMapper Instance()
        {
            if (instance == null)
            {
                instance ??= new UserMapper();
            }
            return instance;
        }
        public UserMapper() { }

        public User FromAddDto(UserRegisterDto dto)
        {
            return new User(dto.Name, dto.Email, dto.Password);
        }

        public User FromAddDto(User e, UserRegisterDto dto)
        {
            e.Name = dto.Name;
            e.Email = dto.Email;
            e.Password = dto.Password;
            return e;
        }

        public UserDto ToDto(User e)
        {
            return new UserDto(e.Id, e.Name, e.Email, e.Role);
        }

        public IList<UserDto> ToDto(IEnumerable<User> e)
        {
           return e.Select(ToDto).ToList();
        }
    }
}
