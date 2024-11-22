
using System.ComponentModel.DataAnnotations;

namespace Application.Dto
{
    public class ProductDto
    {
        [Required]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Barcode { get; set; } = string.Empty;

        [Required]
        public decimal BasePrice { get; set; }

        [Required]
        public decimal SalePrice { get; set; }

        [Required]
        public int Stock { get; set; } = 1;

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public DateOnly ExpiryDate { get; set; } = DateOnly.MinValue;

        [Required]
        public DateOnly ManufDate { get; set; } = DateOnly.MinValue;
    }
}
