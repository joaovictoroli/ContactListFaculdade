using ContactList.BLL.Model;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;


namespace ClientAPI.Service
{
    public class APIConsumer : IAPIConsumer
    {
        static HttpClient client = new HttpClient();
        private string baseURL = "https://localhost:7094";

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            if (client.BaseAddress == null)
            {
                client.BaseAddress = new Uri(baseURL);

            }

            HttpResponseMessage getData = await client.GetAsync("api/Contacts");

            IList<Contact> contacts = new List<Contact?>();
            if (getData.IsSuccessStatusCode)
            {
                string results = getData.Content.ReadAsStringAsync().Result;
                contacts = JsonConvert.DeserializeObject<List<Contact>>(results);

            }
            else
            {
                Console.WriteLine("Error calling web API");
            }

            return contacts;
        }

        public async Task<Contact> GetContact(int id)
        {
            if (client.BaseAddress == null)
            {
                client.BaseAddress = new Uri(baseURL);

            }
            HttpResponseMessage getData = await client.GetAsync(baseURL + "/api/Contacts/" + id);
            Contact contact = new Contact();
            if (getData.IsSuccessStatusCode)
            {
                string result = getData.Content.ReadAsStringAsync().Result;
                contact = JsonConvert.DeserializeObject<Contact>(result);

            }
            else
            {
                Console.WriteLine("Error calling web API");
            }

            return contact;
        }

        public async Task<HttpStatusCode> PostContact(Contact contact)
        {
            if (client.BaseAddress == null)
            {
                client.BaseAddress = new Uri(baseURL);

            }
            var response = await client.PostAsJsonAsync("/api/Contacts", contact);

            return GetResponseStatus(response);
        }

        public async Task<HttpStatusCode> DeleteContact(int id)
        {
            if (client.BaseAddress == null)
            {
                client.BaseAddress = new Uri(baseURL);

            }
            HttpResponseMessage response = await client.DeleteAsync($"api/Contacts/{id}");

            return GetResponseStatus(response);
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/Contacts/{contact.Id}", contact);
            response.EnsureSuccessStatusCode();
            GetResponseStatus(response);
            return contact;
        }

        private static HttpStatusCode GetResponseStatus(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Error calling web API");
            }
            return response.StatusCode;
        }
    }
}
