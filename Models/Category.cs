using System.ComponentModel.DataAnnotations;

namespace CrudOperation.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public String ?CategoryName{ get; set; }
    }
}
