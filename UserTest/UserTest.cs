using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using User.Abstraction;
using Moq;
using UserData;
using User;
using User.Services;

namespace UserTest
{
    [TestFixture]
    public class UserServiceTest
    {
        [Test]
        public void When_GetOlderst_returns_the_oldest_in_list()
        {
            //Arrange
            var moqUserReporitory = new Mock<IUserRepository>();
            moqUserReporitory
                .Setup(r => r.GetAll())
                .Returns(GetUsers());

            UserService userService = new UserService(moqUserReporitory.Object);
            //Act
            var user = userService.GetOldest();

            //Asset
            Assert.That(user.Age == 38);
        }


        [Test]
        public void When_GetOrderedBySurname_returns_the_first_user_Alphabetically_ordered_by_surname()
        {
            //Arrange
            var moqUserReporitory = new Mock<IUserRepository>();
            moqUserReporitory
                .Setup(r => r.GetAll())
                .Returns(GetUsers());

            UserService userService = new UserService(moqUserReporitory.Object);
            //Act
            var user = userService.GetOrderedBySurname();

            //Asset
            Assert.That(user.FirstOrDefault().LastName == "Clarke");
        }

        [Test]
        public void When_GetOrderedByAge_returns_the_youngest_user()
        {
            //Arrange
            var moqUserReporitory = new Mock<IUserRepository>();
            moqUserReporitory
                .Setup(r => r.GetAll())
                .Returns(GetUsers());

            UserService userService = new UserService(moqUserReporitory.Object);
            //Act
            var user = userService.GetOrderedByAge();

            //Asset
            Assert.That(user.FirstOrDefault().Age == 1);
        }

        private IEnumerable<Users> GetUsers()
        {
            List<Users> users = new List<Users>();
            users.Add(new Traveller() { Age = 1, DoB = (DateTime.Now - TimeSpan.FromDays(365)), EmailAddress = "bob@hrgworldwide.com", FirstName = "Bob", LastName = "Mortimer", Id = 1, Passport = "123456" });
            users.Add(new Traveller() { Age = 25, DoB = (DateTime.Today.AddYears(-25)), EmailAddress = "charles@hrgworldwide.com", FirstName = "Charles", LastName = "Clarke", Id = 1, Passport = "aaaa1234-45" });
            users.Add(new Traveller() { Age = 38, DoB = new DateTime(1974, 5, 11), EmailAddress = "sarah@hrgworldwide.com", FirstName = "Sarah", LastName = "Jones", Id = 3, Passport = "654321" });

            return users;
        }
    }
}
