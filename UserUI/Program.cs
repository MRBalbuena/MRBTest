using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserUI
{
    class Program
    {
        static void Main(string[] args)
        {
            User.Repositories.UserRepository userRepository = new User.Repositories.UserRepository();
            User.Services.UserService userService = new User.Services.UserService(userRepository);

            var user = userService.GetOldest();
            Console.WriteLine("The oldest user is: {0} {1}. His age is: {1}", user.FirstName, user.LastName, user.Age);

            var users = userService.GetOrderedByAge();
            users.ToList().ForEach( u => {Console.WriteLine("Users ordered by age: {0} {1} - {2}", u.FirstName, u.LastName, u.Age);});

            users = userService.GetOrderedBySurname();
            users.ToList().ForEach(u => { Console.WriteLine("Users ordered by surname: {0} {1} - {2}", u.FirstName, u.LastName, u.Age); });

            Console.Read();
        }
    }
}
