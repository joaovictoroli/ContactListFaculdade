using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ContactList.BLL.Model.Common;

namespace ContactList.BLL.Model
{
    public class Contact : BaseEntity
    {
        [Display(Name = "Nome")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Sobrenome")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required]
        public DateTime BirthDate { get; set; }
    }
}
