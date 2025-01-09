using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Books> _books=new List<Books>();
        public void AddBook(Books books)
        {
            _books.Add(books);
        }

        public Books GetByID(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);

        }

        public Books GetByTitle(string title)
        {
            return _books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            //_books.FirstOrDefault(b => b.Title.Contains(title));
        }

        public void RemoveBook(Books books)
        {
            _books.Remove(books);
            //throw new NotImplementedException();
        }

        public void Update(Books book)
        {
            var existingBook = GetByID(book.Id);
            if (existingBook != null)
            {
                _books.Remove(existingBook);
                _books.Add(book);
            }
        }
    }
}
