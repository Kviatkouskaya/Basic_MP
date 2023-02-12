using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess
{
    [Table("Orders")]
    public class OrderModel
    {
        [Required]
        public int Id { get; set; }

        public int Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int ProductId { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Order:");
            sb.AppendLine($"Order id: {Id}");
            sb.AppendLine($"Status: {Status}");
            sb.AppendLine($"Created date: {CreatedDate}");
            sb.AppendLine($"Updated date: {UpdatedDate}");
            sb.AppendLine($"Product id: {ProductId}");

            return sb.ToString();
        }
    }
}