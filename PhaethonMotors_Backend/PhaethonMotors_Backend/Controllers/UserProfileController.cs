using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhaethonMotors_Backend.Models;
using PhaethonMotors_Backend.Models.DTOs;
using PhaethonMotors_Backend.Services;
using System.Security.Claims;

namespace PhaethonMotors_Backend.Controllers
{
	[Route("api/profile")]
	[ApiController]
	public class UserProfileController : ControllerBase
	{
		private readonly UserProfileService _userProfileService;

		public UserProfileController(UserProfileService userProfileService)
		{
			_userProfileService = userProfileService;
		}

		[HttpGet]
		public async Task<ActionResult<User>> GetProfileData()
		{
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

			if (userId == null || userRole == null) { return BadRequest("User Not Found!"); }

			return Ok(await _userProfileService.GetUserInfoAsync(userId));
		}

		[HttpPost("custom")]
		public async Task<IActionResult> AddCustomizedCar([FromBody]CustomizedCarDto dto)
		{

			await _userProfileService.ServiceAddCustomizedCarAsync(dto);

			return Ok("Customized car saved successfully!");
		}
	}
}
