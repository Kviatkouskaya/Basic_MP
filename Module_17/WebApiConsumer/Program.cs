namespace WebApiConsumer
{
    public class Program
    {
        private static readonly HttpClient Client = new HttpClient();
        private static string Uri = "https://localhost:7002/api/products/";

        public static async Task Main(string[] args)
        {
            // Get all products
            string products = await CallProducts($"{Uri}pagenumber={1}%category={1}");
            Console.WriteLine(products);

            // Get product by Id
            string productById = await CallProducts($"{Uri}{1}");
            Console.WriteLine(productById);
        }

        private static async Task<string> CallProducts(string uri)
        {
            HttpResponseMessage response = await Client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                return data;
            }
            return null;
        }
    }
}
