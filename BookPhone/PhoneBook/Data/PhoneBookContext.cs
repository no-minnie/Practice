using Microsoft.EntityFrameworkCore;
using PhoneBook.Models; // Пространство имен для модели Contact

namespace PhoneBook.Data // Пространство имен для контекста
{
    public class PhoneBookContext : DbContext
    {
        // Конструктор, необходимый для настройки через DI
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options)
            : base(options)
        {
        }

        // DbSet представляет таблицу "Contacts" в базе данных
        public DbSet<Contact> Contacts { get; set; }
    }
}