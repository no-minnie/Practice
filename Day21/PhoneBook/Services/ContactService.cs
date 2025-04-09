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

        public void AddContact(ContactViewModel contactViewModel)
        {
            if (contactViewModel == null)
            {
                return;
            }

            var newContact = new Contact
            {
                Name = contactViewModel.Name,
                PhoneNumber = contactViewModel.PhoneNumber,
                Email = contactViewModel.Email
            };

            _contactRepository.AddContact(newContact); 
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _contactRepository.GetAllContacts();
        }

        public IEnumerable<Contact> SearchContacts(string name)
        {
            return _contactRepository.SearchContacts(name);
        }
    }
}