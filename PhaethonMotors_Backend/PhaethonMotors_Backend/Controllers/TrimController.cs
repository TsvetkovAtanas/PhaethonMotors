using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhaethonMotors_Backend.Models;
using PhaethonMotors_Backend.Services;

namespace PhaethonMotors_Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TrimController : ControllerBase
	{
		private readonly TrimService _trimService;

		public TrimController(TrimService trimService)
		{
			_trimService = trimService;
		}

		[HttpGet]
		public async Task<ActionResult<List<TrimOption>>> GetAllTrims()
		{
			return Ok(await _trimService.ServiceGetAllTrimsAsync());
		}

		[HttpGet("{TrimOptionID}")]
		public async Task<TrimOption> GetTrimById(string TrimOptionID)
		{
			return await _trimService.ServiceGetTrimByIdAsync(TrimOptionID);
		}
	}
}
