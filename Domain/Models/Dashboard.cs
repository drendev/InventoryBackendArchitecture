
namespace Domain.Models
{
    public class Dashboard
    {
        public int? TotalProducts { get; set; }
        public int? TotalStocks { get; set; }
        public int? TopSelling { get; set; }
        public int? LowStocksProducts { get; set; }
        public int? InStock { get; set; }
        public int? LowStock { get; set; }
        public int? OutOfStock { get; set; }
        public string? LowStockProduct { get; set; }
        public string? OutOfStockProduct { get; set; }
        public int? WeekSold { get; set; }
        public int? TodaySold { get; set; }
        public int? TodaySoldProducts { get; set; }
        public int? WeekSoldProducts { get; set; }
    }
}
