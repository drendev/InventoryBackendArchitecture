using Application.Dto;
using Application.Response;


namespace Application.Interfaces
{
    public interface IUser
    {
        Task<SignupResponse> SignupAsync(SignupDto signupDto);
        Task<LoginResponse> LoginAsync(LoginDto loginDto);
    }
}
