using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Sale
    {
        public Guid SaleId { get; set; }
        public DateTime? SaleDate { get; set; }
        public int? TotalProducts { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? PaymentMethod { get; set; }
        public string? CustomerName { get; set; }

        // Product Relational Property
        [ForeignKey("ProductId")]
        public Guid ProductId { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
