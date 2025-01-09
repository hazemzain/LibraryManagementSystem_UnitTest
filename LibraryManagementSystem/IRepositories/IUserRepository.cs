using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUserById(int userId);
        IEnumerable<User> GetAllUsers();
        void Update(User user);
        void Delete(int id);

    }
}
