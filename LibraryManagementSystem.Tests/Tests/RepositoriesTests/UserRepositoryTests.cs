using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Tests.Tests.RepositoriesTests
{
    public class UserRepositoryTests
    {
        private UserRepository _userRepository;
        [SetUp]
        public void setup()
        { 
            _userRepository = new UserRepository();
        }

        [Test]
        public void Add_User_ShouldAddUserToRepository()
        {
            // Arrange
            var user = new User { Id = 1, Name = "Hazem Zain", Email = "hazemzain17@gmail.com" };

            // Act
            _userRepository.AddUser(user);

            // Assert
            var result = _userRepository.GetUserById(1);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo("Hazem Zain"));
            Assert.That(result.Email, Is.EqualTo("hazemzain17@gmail.com"));
        }

        [Test]
        public void Update_User_ShouldUpdateUserInRepository()
        {
            // Arrange
            var user = new User { Id = 1, Name = "Hazem Zain", Email = "hazemzain17@gmail.com" };

            // Act
            _userRepository.AddUser(user);
            _userRepository.Update(new User { Id = 1, Name = "Hazem mahmoud Zain", Email = "hazemzain1999@gmail.com" });

            // Assert
            var result = _userRepository.GetUserById(1);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo("Hazem mahmoud Zain"));
            Assert.That(result.Email, Is.EqualTo("hazemzain1999@gmail.com"));
        }

        [Test]
        public void Delete_User_ShouldDeleteUserFromRepository()
        {
            // Arrange
            var user = new User { Id = 1, Name = "Hazem Zain", Email = "hazemzain17@gmail.com" };

            // Act
            _userRepository.AddUser(user);
            _userRepository.Delete(1);
            // Assert
            var result = _userRepository.GetUserById(1);
            Assert.That(result, Is.Null);
           
        }

    }
}
