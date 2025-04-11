using PhoneBook.Models;

namespace PhoneBook.Services
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<IEnumerable<Contact>> SearchContactsAsync(string name);
        Task AddContactAsync(Contact contact);
        Task<Contact?> GetContactByIdAsync(int id); 
        Task UpdateContactAsync(Contact contact); 
        Task DeleteContactAsync(int id);     
    }
}