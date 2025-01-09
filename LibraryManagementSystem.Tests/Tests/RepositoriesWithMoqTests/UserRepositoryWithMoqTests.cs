using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Tests.Tests.RepositoriesWithMoqTests
{
    public class UserRepositoryWithMoqTests
    {
        Mock<IUserRepository> _mockUserRepository;
        [SetUp]
        public void sutup()
        {
            _mockUserRepository = new Mock<IUserRepository>();
        }
        [Test]
        public void Add_User_ShouldAddUserToMockRepository()
        {
            // Arrange
            var user = new User { Id = 1, Name = "Hazem Zain", Email = "hazemzain17@gmail.com" };

            // Act
            _mockUserRepository.Object.AddUser(user);
            _mockUserRepository.Verify(repo => repo.AddUser(It.Is<User>(u => u.Id == user.Id && u.Name == user.Name && u.Email == user.Email)), Times.Once);


            
        }
        [Test]
        public void GetUserById_ShouldReturnCorrectUser()
        {
            // Arrange
            var user = new User { Id = 1, Name = "Hazem Zain", Email = "hazemzain17@gmail.com" };
            _mockUserRepository.Setup(repo => repo.GetUserById(1)).Returns(user);

            // Act
            var result = _mockUserRepository.Object.GetUserById(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo("Hazem Zain"));
            Assert.That(result.Email, Is.EqualTo("hazemzain17@gmail.com"));
        }
        [Test]
        public void GetAllUser_ShouldReturnAllUser()
        {
            // Arrange
            var users = new  List<User> {
                new User { Id = 1, Name = "Hazem Zain", Email = "hazemzain17@gmail.com" } ,
                new User { Id = 2, Name = "Mohmed Zain", Email = "Mohamedzain1999@gmail.com" } ,

            };
            _mockUserRepository.Setup(repo => repo.GetAllUsers()).Returns(users);

            // Act
            var result = _mockUserRepository.Object.GetAllUsers();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.Any(u=>u.Name== "Mohmed Zain"), Is.True);
            Assert.That(result.Any(u => u.Email == "hazemzain17@gmail.com"), Is.True);

        }

        [Test]
        public void AddUser_ShouldThrowException_WhenUserAlreadyExists()
        {
            
            var user = new User { Id = 1, Name = "John Doe", Email = "john@example.com" };
            _mockUserRepository.Object.AddUser(user);

            
            Assert.Throws<InvalidOperationException>(() => _mockUserRepository.Object.AddUser(user));
        }
        [Test]
        public void GetUserById_ShouldReturnNull_WhenUserDoesNotExist()
        {
            var user = _mockUserRepository.Object.GetUserById(999);
            Assert.That(user, Is.Null);

        }

    }
}
