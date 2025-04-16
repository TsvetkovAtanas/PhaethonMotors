using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhaethonMotors_Backend.Models;
using PhaethonMotors_Backend.Services;

namespace PhaethonMotors_Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeatureController : ControllerBase
	{
		private readonly FeatureService _featureService;

		public FeatureController(FeatureService featureService)
		{
			_featureService = featureService;
		}

		[HttpGet]
		public async Task<ActionResult<List<FeatureOption>>> GetAllFeatures()
		{
			return Ok(await _featureService.ServiceGetAllFeaturesAsync());
		}

		[HttpGet("{FeatureOptionID}")]
		public async Task<FeatureOption> GetFeatureById(string FeatureOptionID)
		{
			return await _featureService.ServiceGetFeatureByIdAsync(FeatureOptionID);
		}
	}
}
