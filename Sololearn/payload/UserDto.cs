using Sololearn.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sololearn.payload;

namespace SoloLearn.payload
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public IList<SubjectDto> Courses { get; set; }

        public UserDto(long id, string name, string email, Role role)
        {
            Id = id;
            Name = name;
            Email = email;
            Role = role;
            Courses = new List<SubjectDto>();

        }

    }
}
