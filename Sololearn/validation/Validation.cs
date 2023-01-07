using SoloLearn.payload;

namespace Sololearn.validation
{
    public static class Validation
    {

        public static IList<string> UserAddValidation(UserRegisterDto dto)
        {
            IList<string> result = new List<string>();
            if (dto.Equals(null)) result.Add("User Register Dto can  not be null");
            if (dto.Name.Equals("") || dto.Name == null) result.Add("dto name can not be blank");
            if (dto.Email.Equals("") || dto.Email == null) result.Add("dto email can not be blank");
            if (dto.Password.Equals("") || dto.Password == null) result.Add("dto password can not be blank");
            return result;
        }

    }
}
