using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class Category
    {
        [JsonIgnore]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
    }
}
