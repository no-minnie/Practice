using PhoneBook.Models; 

namespace PhoneBook.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<IEnumerable<Contact>> SearchContactsAsync(string name);
        Task AddContactAsync(ContactViewModel contactViewModel); // ViewModel для добавления
        Task<Contact?> GetContactByIdAsync(int id);
        Task UpdateContactAsync(Contact contact);
        Task DeleteContactAsync(int id);
    }
}