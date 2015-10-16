using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserData;

namespace User.Abstraction
{
    public interface IUserRepository
    {
        IEnumerable<Users> GetAll();
    }
}
