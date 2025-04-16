using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PhaethonMotors_Backend.Models;
using PhaethonMotors_Backend.Models.DTOs;
using PhaethonMotors_Backend.Models.Enums;
using PhaethonMotors_Backend.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PhaethonMotors_Backend.Services
{
	public class AuthService
	{
		private readonly AuthRepository _authRepository;
		private readonly IConfiguration _configuration;
		public AuthService(AuthRepository authRepository, IConfiguration configuration)
		{
			_authRepository = authRepository;
			_configuration = configuration;
		}

		public async Task<List<UserDto>> ServiceGetAllUsersAsync()
		{
			return await _authRepository.GetAllUsersAsync();
		}

		public async Task<User> ServiceAddUserAsync(RegisterDto dto)
		{
			var newUser = new User
			{
				Id = Guid.NewGuid().ToString(),
				FirstName = dto.FirstName,
				LastName = dto.LastName,
				Email = dto.Email,
				PasswordHash = ComputeHash(dto.Password),
				Role = Roles.Customer,
			};
			return await _authRepository.AddUserAsync(newUser);
		}

		public string Login(LoginDto dto)
		{
			var user = _authRepository.GetAllUsersAsync().Result.FirstOrDefault(u => u.Email == dto.Email);
			if (user == null || user.PasswordHash != ComputeHash(dto.Password))
			{
				return null;
			}

			return GenerateJwtToken(user);
		}

		private string ComputeHash(string input)
		{
			using (var sha = System.Security.Cryptography.SHA256.Create())
			{
				var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
				return Convert.ToBase64String(bytes);
			}
		}

		private string GenerateJwtToken(UserDto user)
		{
			var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Secret"]);
			var tokenHandler = new JwtSecurityTokenHandler();

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
					new Claim(ClaimTypes.NameIdentifier, user.Id),
					new Claim(ClaimTypes.Name, user.FirstName),
					new Claim(ClaimTypes.Email, user.Email),
					new Claim(ClaimTypes.Role, user.Role.ToString())
				}),
				Expires = DateTime.UtcNow.AddHours(1),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			 var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
