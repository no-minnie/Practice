using Microsoft.EntityFrameworkCore;
using PhoneBook.Data;
using PhoneBook.Models;

namespace PhoneBook.Services
{
    public class EfContactRepository : IContactRepository
    {
        private readonly PhoneBookContext _context;

        public EfContactRepository(PhoneBookContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await _context.Contacts
                                 .OrderBy(c => c.Name) 
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Contact>> SearchContactsAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return await GetAllContactsAsync();
            }

            var allContacts = await _context.Contacts.ToListAsync();

            var filteredContacts = allContacts
                .Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .OrderBy(c => c.Name); 

            return filteredContacts;
        }

        public async Task AddContactAsync(Contact contact)
        {
            if (contact == null) return;
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task<Contact?> GetContactByIdAsync(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            if (contact == null) return;
            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContactAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }
    }
}