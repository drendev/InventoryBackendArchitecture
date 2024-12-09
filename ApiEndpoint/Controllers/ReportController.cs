using Application.Dto;
using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReports reports;

        public ReportController(IReports reports)
        {
            this.reports = reports;
        }

        [HttpPost("add")]
        public async Task<ActionResult<ReportResponse>> AddReport(ReportDto reportDto)
        {
            var response = await reports.AddReportAsync(reportDto);
            return Ok(response);
        }

        [HttpGet("list")]
        public async Task<ActionResult<ReportResponse>> GetReports()
        {
            var response = await reports.GetReportsAsync();
            return Ok(response);
        }
    }
}
