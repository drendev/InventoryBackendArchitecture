using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models
{
    public class Product
    {
        [Key]
        public string ProductId { get; set; }

        public string? Barcode { get; set; }

        public string? ProductName { get; set; }

        public string? Description { get; set; }
        public decimal? BasePrice { get; set; }
        public decimal? SalePrice { get; set; }
        public int? Stock { get; set; }
        public DateOnly? ExpiryDate { get; set; }
        public string? ImageUrl { get; set; }

        public Product()
        {
            ProductId = Guid.NewGuid().ToString("N").Substring(0, 14);
        }
    }
}
