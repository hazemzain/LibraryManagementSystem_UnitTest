using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repositories
{
    public interface IBookRepository
    {
        public void AddBook(Books books);
        public void RemoveBook(Books books);
        public Books GetByID(int id);
        public Books GetByTitle(string title);
        void Update(Books book);




    }
}
