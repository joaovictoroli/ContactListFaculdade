using ContactList.BLL.Model;
using ContactList.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.DAL.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactListDbContext dbContext;

        public ContactRepository(ContactListDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Contact> AddAsync(Contact contact)
        {
            await dbContext.AddAsync(contact);
            await dbContext.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> DeleteAsync(int id)
        {
            var contact = await dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);

            if (contact == null)
            {
                return null;
            }

            dbContext.Contacts.Remove(contact);
            await dbContext.SaveChangesAsync();
            return contact;
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await dbContext.Contacts.ToListAsync();
        }

        public async Task<Contact> GetAsync(int id)
        {
            return await dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Contact> UpdateAsync(int id, Contact contact)
        {
            var existingContact = await dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);

            if (existingContact == null)
            {
                return null;
            }

            existingContact.Name = contact.Name;
            existingContact.LastName = contact.LastName;
            existingContact.Email = contact.Email;
            existingContact.BirthDate = contact.BirthDate;

            await dbContext.SaveChangesAsync();

            return existingContact;

        }

        public async Task<bool> ContactExists(int id)
        {
            return await dbContext.Contacts.AnyAsync(e => e.Id == id);
        }
    }
}

