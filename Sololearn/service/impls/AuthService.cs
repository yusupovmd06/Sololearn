using Sololearn.entity;
using Sololearn.mapper;
using SoloLearn.payload;
using Sololearn.repository.contract;
using Sololearn.repository.impls;
using Sololearn.service.contract;
using Sololearn.utils;
using Sololearn.validation;

namespace Sololearn.service.impls;

public class AuthService : IAuthService
{
    private readonly IUserRepository userRepository = AppBeans.Get<IUserRepository>();
    private readonly UserMapper userMapper = new();
    public Response<string> Register(UserRegisterDto dto)
    {
        IList<string> errors = Validation.UserAddValidation(dto);
        User user = userMapper.FromAddDto(dto);
        user.Role = new Role(2, "GUEST", "app guest");
        userRepository.Save(user);
        if (errors.Count != 0)
            return Response<string>.errorResponse(errors);
        return Response<string>.successResponse();
    }

    public Response<UserDto> SignIn(string email, string password)
    {
        User? user = userRepository.FindByEmail(email);
        if (user == null || !user.Password.Equals(password))
            return Response<UserDto>.errorResponse("Wrong email or passwprd");
        return Response<UserDto>.successResponse(userMapper.ToDto(user));

    }

    public void SignOut()
    {
        ContextHolder.CurrentUser = null;
    }
}
