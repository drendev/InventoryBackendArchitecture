using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }

        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal? BasePrice { get; set; }
        public decimal? SalePrice { get; set; }
        public int? Stock { get; set; }
        public DateOnly? ExpiryDate { get; set; }
        public DateOnly? ManufDate { get; set; }
        public string? ImageUrl { get; set; }

        // Category Relational Property
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        // Sales
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
