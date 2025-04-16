using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhaethonMotors_Backend.Models;
using PhaethonMotors_Backend.Services;

namespace PhaethonMotors_Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class InteriorController : ControllerBase
	{
		private readonly InteriorService _interiorService;

		public InteriorController(InteriorService interiorService)
		{
			_interiorService = interiorService;
		}

		[HttpGet]
		public async Task<ActionResult<List<InteriorOption>>> GetAllInteriors()
		{
			return Ok(await _interiorService.ServiceGetAllInteriorsAsync());
		}

		[HttpGet("{InteriorOptionID}")]
		public async Task<InteriorOption> GetInteriorById(string InteriorOptionID)
		{
			return await _interiorService.ServiceGetInteriorByIdAsync(InteriorOptionID);
		}
	}
}
