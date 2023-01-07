using Sololearn.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sololearn.repository.contract
{
    public interface IUserRepository : IRepository<User, long>
    {
        User? FindByEmail(string email);
    }
}
