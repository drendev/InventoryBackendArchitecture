using Application.Dto;
using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProducts products;

        public ProductController(IProducts products)
        {
            this.products = products;
        }

        [HttpPost("add")]
        public async Task<ActionResult<ProductResponse>> AddProduct(ProductDto productDto)
        {
            var response = await products.AddProductAsync(productDto);
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ProductResponse>> UpdateProduct(ProductDto productDto)
        {
            var response = await products.UpdateProductAsync(productDto);
            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<ProductResponse>> DeleteProduct(string productId)
        {
            var response = await products.DeleteProductAsync(productId);
            return Ok(response);
        }

        [HttpGet("get/{productId}")]
        public async Task<ActionResult<ProductResponse>> GetProduct(string barcode)
        {
            var response = await products.GetProductAsync(barcode);
            return Ok(response);
        }

        [HttpGet("get")]
        public async Task<ActionResult<ProductResponse>> GetProducts()
        {
            var response = await products.GetProductsAsync();
            return Ok(response);
        }

        [HttpPost("addstock")]
        public async Task<ActionResult<ProductResponse>> AddStock(StockDto stockDto)
        {
            var response = await products.AddStockAsync(stockDto);
            return Ok(response);
        }

        [HttpPost("removestock")]
        public async Task<ActionResult<ProductResponse>> RemoveStock(StockDto stockDto)
        {
            var response = await products.RemoveStockAsync(stockDto);
            return Ok(response);
        }
    }
}
