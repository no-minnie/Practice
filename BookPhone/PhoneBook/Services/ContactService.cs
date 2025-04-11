using PhoneBook.Models;

namespace PhoneBook.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }


        public async Task AddContactAsync(ContactViewModel contactViewModel)
        {
            if (contactViewModel == null) return;

            var newContact = new Contact
            {
                Name = contactViewModel.Name,
                PhoneNumber = contactViewModel.PhoneNumber,
                Email = contactViewModel.Email
            };
            await _contactRepository.AddContactAsync(newContact);
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await _contactRepository.GetAllContactsAsync();
        }

        public async Task<IEnumerable<Contact>> SearchContactsAsync(string name)
        {
            return await _contactRepository.SearchContactsAsync(name);
        }

        public async Task<Contact?> GetContactByIdAsync(int id)
        {
            return await _contactRepository.GetContactByIdAsync(id);
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            await _contactRepository.UpdateContactAsync(contact);
        }

        public async Task DeleteContactAsync(int id)
        {
            await _contactRepository.DeleteContactAsync(id);
        }
    }
}