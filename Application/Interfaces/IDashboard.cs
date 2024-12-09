using Application.Response;

namespace Application.Interfaces
{
    public interface IDashboard
    {
        Task<DashboardResponse> GetDashboardAsync();
    }
}
