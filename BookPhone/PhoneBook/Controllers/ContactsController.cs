using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;
using PhoneBook.Services;

namespace PhoneBook.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchTerm)
        {
            IEnumerable<Contact> contacts;
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                contacts = await _contactService.SearchContactsAsync(searchTerm);
                ViewData["SearchTerm"] = searchTerm;
            }
            else
            {
                contacts = await _contactService.GetAllContactsAsync();
            }

            if (ViewData["ContactFormData"] == null)
            {
                ViewData["ContactFormData"] = new ContactViewModel();
            }
            if (!ViewData.ContainsKey("SearchTerm"))
            {
                ViewData["SearchTerm"] = null;
            }

            return View(contacts);
        }

        [HttpGet("Contacts/Search/{name}")]
        public IActionResult Search(string name)
        {
            return RedirectToAction(nameof(Index), new { searchTerm = name });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(Prefix = "contactFormData")] ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                await _contactService.AddContactAsync(contactViewModel);
                TempData["SuccessMessage"] = "Контакт успешно добавлен!";
                return RedirectToAction(nameof(Index));
            }

            var allContacts = await _contactService.GetAllContactsAsync();
            ViewData["ContactFormData"] = contactViewModel;
            ViewData["SearchTerm"] = null;
            return View("Index", allContacts);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _contactService.GetContactByIdAsync(id.Value);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PhoneNumber,Email")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _contactService.UpdateContactAsync(contact);
                    TempData["SuccessMessage"] = "Контакт успешно обновлен!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _contactService.GetContactByIdAsync(contact.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Не удалось сохранить изменения. Возможно, данные были изменены другим пользователем.");
                        return View(contact);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _contactService.GetContactByIdAsync(id.Value);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _contactService.DeleteContactAsync(id);
            TempData["SuccessMessage"] = "Контакт успешно удален!";
            return RedirectToAction(nameof(Index));
        }
    }
}