using Application.Dto;
using Application.Interfaces;
using Application.Response;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Gateway
{
    internal class ProductGateway: IProducts
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration configuration;

        public ProductGateway(AppDbContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
        }

        public async Task<ProductResponse> AddProductAsync(ProductDto productDto)
        {
            var findProduct = await appDbContext.Products.FirstOrDefaultAsync(p => p.ProductName == productDto.ProductName);

            if (findProduct != null)
            {
                return new ProductResponse(false, "Product already exists");
            }

            var product = new Product
            {
                ProductName = productDto.ProductName,
                Description = productDto.Description,
                BasePrice = productDto.BasePrice,
                SalePrice = productDto.SalePrice,
                Stock = productDto.Stock,
                ExpiryDate = productDto.ExpiryDate,
                ManufDate = productDto.ManufDate,
                ImageUrl = productDto.ImageUrl,
            };

            await appDbContext.Products.AddAsync(product);
            await appDbContext.SaveChangesAsync();

            return new ProductResponse(true, "Product added successfully");
        }

        public async Task<ProductResponse> UpdateProductAsync(ProductDto productDto)
        {
            var product = await appDbContext.Products.FirstOrDefaultAsync(p => p.ProductName == productDto.ProductName);

            if (product == null)
            {
                return new ProductResponse(false, "Product not found");
            }

            product.ProductName = productDto.ProductName;
            product.Description = productDto.Description;
            product.BasePrice = productDto.BasePrice;
            product.SalePrice = productDto.SalePrice;
            product.Stock = productDto.Stock;
            product.ExpiryDate = productDto.ExpiryDate;
            product.ManufDate = productDto.ManufDate;
            product.ImageUrl = productDto.ImageUrl;

            appDbContext.Products.Update(product);
            await appDbContext.SaveChangesAsync();

            return new ProductResponse(true, "Product updated successfully");
        }

        public async Task<ProductResponse> DeleteProductAsync(string productId)
        {
            var product = await appDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);

            if (product == null)
            {
                return new ProductResponse(false, "Product not found");
            }

            appDbContext.Products.Remove(product);
            await appDbContext.SaveChangesAsync();

            return new ProductResponse(true, "Product deleted successfully");
        }

        // Add stock to product

        public async Task<ProductResponse> AddStockAsync(string productId, int stock)
        {
            var product = await appDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);

            if (product == null)
            {
                return new ProductResponse(false, "Product not found");
            }

            if(stock < 0 || stock > 100)
            {
                return new ProductResponse(false, "Invalid Stock Input");
            }

            product.Stock += stock;

            appDbContext.Products.Update(product);
            await appDbContext.SaveChangesAsync();

            return new ProductResponse(true, "Stock added successfully");
        }

        // Remove stock

        public async Task<ProductResponse> RemoveStockAsync(string productId, int stock)
        {
            var product = await appDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);

            if (product == null)
            {
                return new ProductResponse(false, "Product not found");
            }

            if (product.Stock < stock)
            {
                return new ProductResponse(false, "Stock is less than the quantity you want to remove");
            }

            product.Stock -= stock;

            appDbContext.Products.Update(product);
            await appDbContext.SaveChangesAsync();

            return new ProductResponse(true, "Stock removed successfully");
        }

        // Scan Barcode to search for product
        public async Task<ProductResponse> GetProductAsync(string productId)
        {
            var product = await appDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);

            if (product == null)
            {
                return new ProductResponse(false, "Product not found");
            }

            return new ProductResponse(true, "Product found", Product: product);
        }

        public async Task<ProductResponse> GetProductsAsync()
        {
            var products = await appDbContext.Products.ToListAsync();

            if (products == null)
            {
                return new ProductResponse(false, "No products found");
            }

            return new ProductResponse(true, "Products found", Products: products);
        }
    }
}
