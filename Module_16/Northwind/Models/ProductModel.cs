using System.ComponentModel.DataAnnotations;
using DataAccess.Models;

namespace Northwind.Models
{
    public class ProductModel
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Name length can't be more than 40.")]
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
        public CategoryType CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 UnitsInStock { get; set; }
        public Int16 UnitsOnOrder { get; set; }
        public Int16 ReorderLevel { get; set; }
        [Required]
        [StringLength(1, ErrorMessage = "{0} length must contain 0 - false or 1 - true.")]
        public bool Discontinued { get; set; }
    }
}
