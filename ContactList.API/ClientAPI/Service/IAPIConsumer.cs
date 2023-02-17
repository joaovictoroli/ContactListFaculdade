using ContactList.BLL.Model;
using System.Net;

namespace ClientAPI.Service
{
    public interface IAPIConsumer
    {
        Task<IEnumerable<Contact>> GetAllContacts();
        Task<Contact> GetContact(int id);
        Task<HttpStatusCode> PostContact(Contact contact);
        Task<HttpStatusCode> DeleteContact(int id);

        Task<Contact> UpdateContact(Contact contact);
    }
}
