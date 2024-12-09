using Application.Dto;
using Application.Interfaces;
using Application.Response;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Gateway
{
    internal class ReportGateway: IReports
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration configuration;

        public ReportGateway(AppDbContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
        }

        // Add report
        public async Task<ReportResponse> AddReportAsync(ReportDto reportDto)
        {

            var report = new Report
            {
                ProductName = reportDto.ProductName,
                Quantity = reportDto.Quantity,
                UserName = reportDto.UserName,
                CurrentStock = reportDto.CurrentStock,
                ReportType = reportDto.ReportType
            };

            await appDbContext.Reports.AddAsync(report);
            await appDbContext.SaveChangesAsync();

            return new ReportResponse(true, "Report added successfully");
        }

        // Get all reports
        public async Task<ReportResponse> GetReportsAsync()
        {
            var reports = await appDbContext.Reports.ToListAsync();

            if (reports == null)
            {
                return new ReportResponse(false, "No reports found");
            }

            return new ReportResponse(true, "Reports found", Reports: reports);
        }
    }
}
