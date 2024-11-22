
using Application.Dto;
using Application.Response;

namespace Application.Interfaces
{
    public interface IProducts
    {
        Task<ProductResponse> AddProductAsync(ProductDto productDto);
        Task<ProductResponse> UpdateProductAsync(ProductDto productDto);
        Task<ProductResponse> DeleteProductAsync(string productId);
        Task<ProductResponse> GetProductAsync(string barcode);
        Task<ProductResponse> GetProductsAsync();
        Task<ProductResponse> AddStockAsync(StockDto stockDto);
        Task<ProductResponse> RemoveStockAsync(StockDto stockDto);
    }
}
