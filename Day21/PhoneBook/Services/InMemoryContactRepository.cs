using PhoneBook.Models;

namespace PhoneBook.Services
{
    public class InMemoryContactRepository : IContactRepository 
    {
        private static List<Contact> _contacts = new List<Contact>()
        {
            new Contact { Id = 1, Name = "Анна Каренина", PhoneNumber = "123-45-67", Email = "test1@mail.com" },
            new Contact { Id = 2, Name = "Пьер Безухов", PhoneNumber = "987-65-43", Email = "test2@mail.com" }
        };
        private static int _nextId = 3;

        public void AddContact(Contact contact)
        {
            if (contact == null)
            {
                return;
            }
            contact.Id = _nextId++;
            _contacts.Add(contact);
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _contacts.OrderBy(c => c.Name).ToList();
        }

        public IEnumerable<Contact> SearchContacts(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return GetAllContacts();
            }
            string lowerName = name.ToLowerInvariant();
            return _contacts
                .Where(c => c.Name.ToLowerInvariant().Contains(lowerName))
                .OrderBy(c => c.Name)
                .ToList();
        }
    }
}