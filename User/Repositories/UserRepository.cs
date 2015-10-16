using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Abstraction;
using UserData;

namespace User.Repositories
{
    public class UserRepository: IUserRepository
    {
        readonly InterviewTestEntities _Database = new InterviewTestEntities();
        public IEnumerable<UserData.Users> GetAll()
        {
            return _Database.Users.ToList();
        }
    }
}
