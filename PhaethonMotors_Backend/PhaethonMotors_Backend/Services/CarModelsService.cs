using Microsoft.EntityFrameworkCore;
using PhaethonMotors_Backend.Models;
using PhaethonMotors_Backend.Models.DTOs;
using PhaethonMotors_Backend.Repository;

namespace PhaethonMotors_Backend.Services
{
	public class CarModelsService
	{
		private readonly CarModelsRepository _carModelsRepository;
		public CarModelsService(CarModelsRepository carModelsRepository) 
		{
			_carModelsRepository = carModelsRepository;
		}

		public async Task<List<CarModelDto>> ServiceGetAllModelsAsync()
		{
			return await _carModelsRepository.GetAllModelsAsync();
		}

		public async Task<CarModel> ServiceGetModelByIdAsync(string carModelID)
		{
			return await _carModelsRepository.GetModelByIdAsync(carModelID);
		}

		public async Task<List<SubModel>> ServiceGetAllSubModelsAsync()
		{
			return await _carModelsRepository.GetAllSubModelsAsync();
		}
	}
}
