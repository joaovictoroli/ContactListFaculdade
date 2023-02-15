using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactList.BLL.Model.Common;

namespace ContactList.BLL.Model
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
