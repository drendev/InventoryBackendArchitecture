
namespace Application.Response
{
    public record LoginResponse(bool Access, string Message = null!, string accessToken = null!);
}
