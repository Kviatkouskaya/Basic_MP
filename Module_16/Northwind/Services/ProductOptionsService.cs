using Microsoft.CodeAnalysis.Emit;
using Microsoft.Extensions.Options;
using Northwind.Models;

namespace Northwind.Services
{
    public interface IProductPageService
    {
        ProductPageOptions GetUnits();
    }

    public class ProductOptionService : IProductPageService
    {
        private readonly ProductPageOptions _productPageOptions;

        public ProductOptionService(IOptions<ProductPageOptions> productOptions)
        {
            _productPageOptions = productOptions.Value;
        }

        public ProductPageOptions GetUnits()
        {
            return _productPageOptions;
        }
    }
}
