using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sololearn.entity.templates;

namespace Sololearn.entity
{
    public class User : AbsLongEntity
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public User() { }
        public User(string name, string email, string password) 
        {
            Name= name;
            Email= email;
            Password= password;
        }

        public User(long id, DateTime addedAt, bool isActive, bool isDeleted,
            long addedBy, string name, string email, string password, Role role)
            : base(id, addedAt, isActive, isDeleted, addedBy)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }
    }
}
