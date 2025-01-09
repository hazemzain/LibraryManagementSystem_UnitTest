using LibraryManagementSystem.Repositories;

using Microsoft.Extensions.DependencyInjection;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IBookRepository, BookRepository>();
            serviceCollection.AddSingleton<IUserRepository, UserRepository>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            

           

            var bookRepository = serviceProvider.GetService<IBookRepository>();
            var userRepository = serviceProvider.GetService<IUserRepository>();
            


            if (bookRepository == null || userRepository == null)
            {
                Console.WriteLine("Repositories are not registered in the DI container.");
            }

            
            var newBook = new Books { Id = 1, Title = "C# Basics", Author = "John Doe" };
            bookRepository.AddBook(newBook);

            var retrievedBook = bookRepository.GetByID(1);
            Console.WriteLine($"Retrieved Book: {retrievedBook.Title} by {retrievedBook.Author}");
            Console.WriteLine("Hello, World!");
        }
    }
}
