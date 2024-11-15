
using Application.Dto;
using Application.Response;

namespace Application.Interfaces
{
    public interface IProducts
    {
        Task<ProductResponse> AddProductAsync(ProductDto productDto);
        Task<ProductResponse> UpdateProductAsync(ProductDto productDto);
        Task<ProductResponse> DeleteProductAsync(string productId);
        Task<ProductResponse> GetProductAsync(string productId);
        Task<ProductResponse> GetProductsAsync();
        Task<ProductResponse> AddStockAsync(string productId, int stock);
        Task<ProductResponse> RemoveStockAsync(string productId, int stock);
    }
}
