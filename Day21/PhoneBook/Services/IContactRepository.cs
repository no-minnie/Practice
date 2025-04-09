using PhoneBook.Models;

namespace PhoneBook.Services
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAllContacts();
        IEnumerable<Contact> SearchContacts(string name);
        void AddContact(Contact contact);
    }
}