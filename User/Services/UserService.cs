using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Abstraction;
using User.Repositories;

namespace User.Services
{
    public class UserService: IUserService
    {
        readonly IUserRepository _UserRepository;
        public UserService(IUserRepository userRepository)
        {
            // Inject by IoC
            _UserRepository = userRepository;
        }
        public UserData.Users GetOldest()
        {
            return _UserRepository.GetAll().OrderByDescending(u => u.Age).FirstOrDefault();
        }

        public IEnumerable<UserData.Users> GetOrderedBySurname()
        {
            return _UserRepository.GetAll().OrderBy(u => u.LastName);
        }

        public IEnumerable<UserData.Users> GetOrderedByAge()
        {
            return _UserRepository.GetAll().OrderBy(u => u.Age);
        }
    }
}
