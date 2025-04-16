using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhaethonMotors_Backend.Models;
using PhaethonMotors_Backend.Services;

namespace PhaethonMotors_Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WheelController : ControllerBase
	{
		private readonly WheelService _wheelService;

		public WheelController(WheelService wheelService)
		{
			_wheelService = wheelService;
		}

		[HttpGet]
		public async Task<ActionResult<List<WheelOption>>> GetAllWheels()
		{
			return Ok(await _wheelService.ServiceGetAllWheelsAsync());
		}

		[HttpGet("{WheelOptionID}")]
		public async Task<WheelOption> GetInteriorById(string WheelOptionID)
		{
			return await _wheelService.ServiceGetWheelByIdAsync(WheelOptionID);
		}
	}
}
