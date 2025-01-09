using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using NUnit.Framework.Internal;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Tests.Tests.RepositoriesTests
{
    [TestFixture]
    public class BookRepositoryTests
    {
        private BookRepository _bookRepository;
        [SetUp]
        public void Setup()
        {
            _bookRepository = new BookRepository();
        }
        [Test]
        public void Add_Book_ShouldAddBookToRepository()
        {
            var book = new Books { Id =1, Title = "C# Basics", Author = "John Doe" };

            _bookRepository.AddBook(book);

            var result = _bookRepository.GetByID(1);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Title, Is.EqualTo("C# Basics"));
            Assert.That(result.Author, Is.EqualTo("John Doe"));

        }
        [Test]
        public void Remove_Book_ShouldRemoveBookFromRepository()
        {
            var book = new Books { Id = 1, Title = "C# Basics", Author = "John Doe" };

            _bookRepository.AddBook(book);
            _bookRepository.RemoveBook(book);

            var result = _bookRepository.GetByID(1);
            Assert.That(result, Is.Null);
           

        }
    }
}
