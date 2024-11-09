using System.ComponentModel.DataAnnotations;


namespace Domain.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
