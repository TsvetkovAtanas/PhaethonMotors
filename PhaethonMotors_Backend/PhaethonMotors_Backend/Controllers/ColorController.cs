using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhaethonMotors_Backend.Models;
using PhaethonMotors_Backend.Services;

namespace PhaethonMotors_Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ColorController : ControllerBase
	{
		private readonly ColorService _colorsService;

		public ColorController(ColorService colorsService)
		{
			_colorsService = colorsService;
		}

		[HttpGet]
		public async Task<ActionResult<List<ColorOption>>> GetAllColors()
		{
			return Ok(await _colorsService.ServiceGetAllColorsAsync());
		}

		[HttpGet("{ColorOptionID}")]
		public async Task<ColorOption> GetColorById(string ColorOptionID)
		{
			return await _colorsService.ServiceGetColorByIdAsync(ColorOptionID);
		}
	}
}
