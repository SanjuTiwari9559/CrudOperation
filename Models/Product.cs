using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOperation.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ?MProductName { get; set; }
        public int ProductPrice { get; set; }
        public int ProductQty { get; set; }
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public virtual Category Categories { get; set; }
    }
}
