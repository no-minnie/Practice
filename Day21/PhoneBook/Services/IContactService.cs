using PhoneBook.Models;

namespace PhoneBook.Services
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAllContacts();
        IEnumerable<Contact> SearchContacts(string name);
        void AddContact(ContactViewModel contactViewModel); 
    }
}