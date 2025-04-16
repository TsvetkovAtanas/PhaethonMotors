using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhaethonMotors_Backend.Data;
using PhaethonMotors_Backend.Models;
using PhaethonMotors_Backend.Models.DTOs;
using PhaethonMotors_Backend.Repository;
using PhaethonMotors_Backend.Services;

namespace PhaethonMotors_Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarModelsController : ControllerBase
	{
		private readonly CarModelsService _carModelsService;

		public CarModelsController(CarModelsService carModelsService)
		{
			_carModelsService = carModelsService;
		}

		[HttpGet("dto")]
		public async Task<ActionResult<List<CarModelDto>>> GetAllModels()
		{
			return Ok(await _carModelsService.ServiceGetAllModelsAsync());
		}

		[HttpGet("{carModelID}")]
		public async Task<CarModel> GetModelById(string carModelID)
		{
			return await _carModelsService.ServiceGetModelByIdAsync(carModelID);
		}

		[HttpGet("sub")]
		public async Task<ActionResult<List<SubModel>>> GetAllSubModels()
		{
			return Ok(await _carModelsService.ServiceGetAllSubModelsAsync());
		}
	}
}
