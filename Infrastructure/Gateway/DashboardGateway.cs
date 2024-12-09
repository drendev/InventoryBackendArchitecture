using Application.Interfaces;
using Application.Response;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Gateway
{
    internal class DashboardGateway: IDashboard
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration configuration;

        public DashboardGateway(AppDbContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
        }

        public async Task<DashboardResponse> GetDashboardAsync()
        {
            int totalProducts = await appDbContext.Products.CountAsync();
            int? totalStocks = await appDbContext.Products.SumAsync(s => s.Stock);
            int? lowStocksProducts = await appDbContext.Products.CountAsync(s => s.Stock <= 5);
            int? inStock = await appDbContext.Products.CountAsync(s => s.Stock >= 6);
            int? lowStock = await appDbContext.Products.CountAsync(s => s.Stock > 0 && s.Stock <= 5);
            int? outOfStock = await appDbContext.Products.CountAsync(s => s.Stock == 0);
            string? lowStockProduct = await appDbContext.Products.Where(s => s.Stock <= 5).Select(s => s.ProductName).FirstOrDefaultAsync();
            string? outOfStockProduct = await appDbContext.Products.Where(s => s.Stock == 0).Select(s => s.ProductName).FirstOrDefaultAsync();

            // Define Manila timezone
            var manilaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");
            var nowInManila = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, manilaTimeZone);

            // Define date ranges
            var today = DateOnly.FromDateTime(nowInManila);
            var sevenDaysAgo = today.AddDays(-7);

            // Count distinct products sold today
            int? todaySoldProducts = await appDbContext.Reports
                .Where(r => r.Date == today && r.ReportType == "SOLD STOCK")
                .Select(r => r.ProductName)
                .Distinct()
                .CountAsync();

            // Count distinct products sold in the past week
            int? weekSoldProducts = await appDbContext.Reports
                .Where(r => r.Date >= sevenDaysAgo && r.Date <= today && r.ReportType == "SOLD STOCK")
                .Select(r => r.ProductName)
                .Distinct()
                .CountAsync();

            // Weekly sold stock
            int? weekSold = await appDbContext.Reports
                .Where(r => r.Date >= sevenDaysAgo && r.Date <= today && r.ReportType == "SOLD STOCK")
                .SumAsync(r => r.Quantity);

            // Daily sold stock
            int? daySold = await appDbContext.Reports
                .Where(r => r.Date == today && r.ReportType == "SOLD STOCK")
                .SumAsync(r => r.Quantity);

            var topSelling = await appDbContext.Reports
                .Where(r => r.Date >= sevenDaysAgo && r.Date <= today) 
                .GroupBy(r => r.ProductName)
                .Where(g => g.Sum(r => r.Quantity) > 40)
                .CountAsync();

            var dashboard = new Dashboard
            {
                TotalProducts = totalProducts,
                TotalStocks = totalStocks,
                TopSelling = topSelling,
                LowStocksProducts = lowStocksProducts,
                InStock = inStock,
                LowStock = lowStock,
                OutOfStock = outOfStock,
                LowStockProduct = lowStockProduct,
                OutOfStockProduct = outOfStockProduct,
                WeekSold = weekSold,
                TodaySold = daySold,
                TodaySoldProducts = todaySoldProducts,
                WeekSoldProducts = weekSoldProducts
            };

            return new DashboardResponse(true, "Dashboard found", Dashboard: dashboard);
        }
    }
}
