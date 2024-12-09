using Application.Dto;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IReports
    {
        Task<ReportResponse> AddReportAsync(ReportDto reportDto);
        Task<ReportResponse> GetReportsAsync();
    }
}
