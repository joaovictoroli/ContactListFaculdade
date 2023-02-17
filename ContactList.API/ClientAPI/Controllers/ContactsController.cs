using ClientAPI.Service;
using ContactList.BLL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace ClientAPI.Controllers
{
    public class ContactsController : Controller
    {
        // GET: ContactsController

        private readonly IAPIConsumer apiConsumer;

        public ContactsController(IAPIConsumer apiConsumer)
        {
            this.apiConsumer = apiConsumer;
        }
        public async Task<IActionResult> Index()
        {
            var contacts = await apiConsumer.GetAllContacts();

            return View(contacts);
        }

        // GET: ContactsController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var contact = await apiConsumer.GetContact(id); 
            return View(contact);
        }

        // GET: ContactsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await apiConsumer.PostContact(contact);
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: ContactsController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var contact =  await apiConsumer.GetContact(id);

            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        // POST: ContactsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await apiConsumer.UpdateContact(contact);
                return RedirectToAction(nameof(Index));
            }
            return View(contact.Id);
        }

        // GET: ContactsController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            await apiConsumer.DeleteContact(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: ContactsController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
