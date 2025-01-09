using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void Delete(int id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }

        public User GetUserById(int userId)
        {
            return _users.FirstOrDefault(u => u.Id == userId);
        }

        public void Update(User user)
        {
            var existingUser = GetUserById(user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
            }
        }
    }
}
