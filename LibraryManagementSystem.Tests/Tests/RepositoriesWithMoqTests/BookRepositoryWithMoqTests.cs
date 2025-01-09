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
    public class BookRepositoryWithMoqTests
    {
        Mock<IBookRepository> _mockBookRepository;
        [SetUp]
        public void sutup()
        {
            _mockBookRepository = new Mock<IBookRepository>();
        }
        [Test]
        public void GetBookById_ShouldReturnCorrectBook()
        {
            // Arrange
            var book = new Books { Id = 1, Title = "C# Basics", Author = "John Doe" };
            _mockBookRepository.Setup(repo => repo.GetByID(1)).Returns(book);

            // Act
            var result = _mockBookRepository.Object.GetByID(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Title, Is.EqualTo("C# Basics"));
            Assert.That(result.Author, Is.EqualTo("John Doe"));
        }

        [Test]
        public void UpdateBook_ShouldUpdateCorrectBook()
        {
            // Arrange
            var booksList = new List<Books>
            {
                new Books { Id = 1, Title = "C# Basics", Author = "John Doe" }
            };
            _mockBookRepository.Setup(repo => repo.GetByID(It.IsAny<int>())).Returns((int id)=>booksList.FirstOrDefault(b=>b.Id==id));

            _mockBookRepository.Setup(repo => repo.Update(It.IsAny<Books>()))
       .Callback<Books>(book =>
       {
           var existingBook = booksList.FirstOrDefault(b => b.Id == book.Id);
           if (existingBook != null)
           {
               booksList.Remove(existingBook);
               booksList.Add(book);
           }
       });

            _mockBookRepository.Object.Update(new Books { Id = 1, Title = "Nunit Book", Author = "Hazem" });

              //_mockBookRepository.Setup(repo => repo.Update(new Books { Id = 1, Title = "Nunit Book", Author = "Hazem" }));
            // Act
            var result = _mockBookRepository.Object.GetByID(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Title, Is.EqualTo("Nunit Book"));
            Assert.That(result.Author, Is.EqualTo("Hazem"));
        }


        [Test]
        public void GetByID_ShouldReturnNull_WhenBookDoesNotExist()
        {
            // Act
            var result = _mockBookRepository.Object.GetByID(999);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void RemoveBook_ShouldRemoveBook_WhenBookExists()
        {
            // Arrange
            var book = new Books { Id = 1, Title = "C# Basics", Author = "John Doe" };
            _mockBookRepository.Object.AddBook(book);

            // Act
            _mockBookRepository.Object.RemoveBook(book);

            // Assert
            var result = _mockBookRepository.Object.GetByID(1);
            Assert.That(result, Is.Null);
        }


    }
}
