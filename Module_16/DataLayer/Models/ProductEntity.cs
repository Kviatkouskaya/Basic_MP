namespace DataAccess.Models
{
    public class ProductEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public CategoryType CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 UnitsInStock { get; set; }
        public Int16 UnitsOnOrder { get; set; }
        public Int16 ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
