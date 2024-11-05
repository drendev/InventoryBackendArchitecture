using Application.Dto;
using Application.Interfaces;
using Application.Response;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Gateway
{
    internal class UserGateway : IUser
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration configuration;

        public UserGateway(AppDbContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
        }

        private async Task<User> FindUserByEmail(string email) =>
            await appDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<LoginResponse> LoginAsync(LoginDto loginDto)
        {
            var getUser = await FindUserByEmail(loginDto.Email);

            if (getUser == null)
            {
                return new LoginResponse(false, "Invalid username or password"); // Prevent brute force attack
            }

            bool verifyPassword = BCrypt.Net.BCrypt.Verify(loginDto.Password, getUser.Password);

            if (verifyPassword)
            {
                return new LoginResponse(true, "Logged in successfully", GenerateJWTToken(getUser));
            }
            else if (!verifyPassword)
            {
                return new LoginResponse(false, "Invalid username or password"); // Prevent brute force attack
            }

            return new LoginResponse(false, "Internal Server Error.");
        }

        private string GenerateJWTToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FullName!),
                new Claim(ClaimTypes.Email, user.Email!)
            };

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<SignupResponse> SignupAsync(SignupDto signupDto)
        {
            var getUser = await FindUserByEmail(signupDto.Email);

            if(getUser != null)
            {
                return new SignupResponse(false, "Email already exists.");
            }

            appDbContext.Users.Add(new User()
            {
                FullName = signupDto.FullName,
                Email = signupDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(signupDto.Password),
                Role = signupDto.Role,
                Birthday = signupDto.Birthday,
                PhoneNumber = signupDto.PhoneNumber
            });

            await appDbContext.SaveChangesAsync();

            return new SignupResponse(true, "Signed Up successfully.");
        }
    }
}
