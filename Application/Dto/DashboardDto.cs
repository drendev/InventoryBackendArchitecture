using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class DashboardDto
    {
        [Required]
        public int TotalProducts { get; set; } = 0;

        [Required]
        public int TotalStocks { get; set; } = 0;

        [Required]
        public int TopSelling { get; set; } = 0;

        [Required]
        public int LowStocksProducts { get; set; } = 0;

        [Required]
        public int InStock { get; set; } = 0;

        [Required]
        public int LowStock { get; set; } = 0;

        [Required]
        public int OutOfStock { get; set; } = 0;

        [Required]
        public string LowStockProduct { get; set; } = "";

        [Required]
        public string OutOfStockProduct { get; set; } = "";

        [Required]
        public int WeeklyStocks { get; set; } = 0;
    }
}
