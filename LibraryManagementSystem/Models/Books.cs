using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Books
    {
        public int Id { get; set; } //must be unique
        public string? Title { get; set; }
        public string?   Author { get; set; }
    }
}
