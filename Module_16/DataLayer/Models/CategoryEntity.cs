using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class CategoryEntity
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public object Picture { get; set; }
    }
}