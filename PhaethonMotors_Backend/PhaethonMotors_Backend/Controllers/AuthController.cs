using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhaethonMotors_Backend.Models.DTOs;
using PhaethonMotors_Backend.Services;

namespace PhaethonMotors_Backend.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly AuthService _authService;

		public AuthController(AuthService authService)
		{
			_authService = authService;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterDto dto)
		{
			var users = await _authService.ServiceGetAllUsersAsync();

			if (users.Any(u => u.Email == dto.Email))
			{
				return BadRequest("User already exists!");
			}

			await _authService.ServiceAddUserAsync(dto);

			return Ok("User registered successfully");
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginDto dto)
		{
			var token = _authService.Login(dto);
			if (token == null)
			{
				return Unauthorized("Invalid credentials!");
			}

			return Ok(new {token});
		}
	}
}
