using Microsoft.EntityFrameworkCore;
using ContactList.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;

namespace ContactList.DAL.Data
{
    public class ContactListDbContext : DbContext
    {
        public ContactListDbContext(DbContextOptions<ContactListDbContext> options) : base(options) 
        { 
        }

        public virtual DbSet<Contact> Contacts { get; set; }    
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ContactListDbContext>
    {
        public ContactListDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory()
      + "/../ContactList.API/appsettings.json").Build();

            var builder = new DbContextOptionsBuilder<ContactListDbContext>();
            var connectionString = configuration.GetConnectionString("ContactList");
            builder.UseSqlServer(connectionString);
            return new ContactListDbContext(builder.Options);
        }
    }
}
