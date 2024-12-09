using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboard dashboard;

        public DashboardController(IDashboard dashboard)
        {
            this.dashboard = dashboard;
        }

        [HttpGet("get")]

        public async Task<ActionResult<DashboardResponse>> GetDashboard()
        {
            var response = await dashboard.GetDashboardAsync();
            return Ok(response);
        }
    }
}
