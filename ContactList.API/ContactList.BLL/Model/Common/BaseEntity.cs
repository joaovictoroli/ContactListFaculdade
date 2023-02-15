using System.ComponentModel.DataAnnotations;

namespace ContactList.BLL.Model.Common
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}