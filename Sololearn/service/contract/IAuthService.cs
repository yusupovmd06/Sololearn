using SoloLearn.payload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sololearn.service.contract
{
    public interface IAuthService
    {
        Response<string> Register(UserRegisterDto dto);
        Response<UserDto> SignIn(string email, string password);
        void SignOut();
    }
}
