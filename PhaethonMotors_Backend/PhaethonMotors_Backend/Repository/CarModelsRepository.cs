using Microsoft.EntityFrameworkCore;
using PhaethonMotors_Backend.Data;
using PhaethonMotors_Backend.Models;
using PhaethonMotors_Backend.Models.DTOs;

namespace PhaethonMotors_Backend.Repository
{
	public class CarModelsRepository
	{
		private readonly PhaethonDbContext _context;

		public CarModelsRepository(PhaethonDbContext context)
		{
			_context = context;
		}

		public async Task<List<CarModelDto>> GetAllModelsAsync()
		{
			var carModels = await _context.CarModels
		.Include(c => c.SubModel)
		.Include(c => c.ColorOption)
		.Include(c => c.InteriorOption)
		.Include(c => c.WheelOption)
		.Include(c => c.TrimOption)
		.Include(c => c.FeatureOptions)
		.ToListAsync();

#pragma warning disable CS8601 // Possible null reference assignment.
			var dtos = carModels.Select(c => new CarModelDto
			{
				Id = c.Id,
				Name = c.Name,
				FuelType1 = c.FuelType1,
				FuelType2 = c.FuelType2,
				CarImage = c.CarImage,
				BasePrice = c.BasePrice,
				Horsepower = c.Horsepower,
				Torque = c.Torque,
				TopSpeed = c.TopSpeed,
				Acceleration = c.Acceleration,
				SeatingCapacity = c.SeatingCapacity,
				CargoSpace = c.CargoSpace,
				Transmission = c.Transmission,
				DriveType = c.DriveType,
				ColorOption = c.ColorOption == null ? null : new ColorOptionDto
				{
					Id = c.ColorOption.Id,
					Name = c.ColorOption.Name,
					HexCode = c.ColorOption.HexCode,
					Price = c.ColorOption.Price
				},
				InteriorOption = c.InteriorOption == null ? null : new InteriorOptionDto
				{
					Id = c.InteriorOption.Id,
					Name = c.InteriorOption.Name,
					Material = c.InteriorOption.Material,
					Price = c.InteriorOption.Price
				},
				TrimOption = c.TrimOption == null ? null : new TrimOptionDto
				{
					Id = c.TrimOption.Id,
					Name = c.TrimOption.Name,
					PriceIncrease = c.TrimOption.PriceIncrease,
					HorsepowerIncrease = c.TrimOption.HorsepowerIncrease,
					Suspension = c.TrimOption.Suspension
				},
				WheelOption = c.WheelOption == null ? null : new WheelOptionDto
				{
					Id = c.WheelOption.Id,
					Name = c.WheelOption.Name,
					Price = c.WheelOption.Price
				},
				SubModel = c.SubModel == null ? null : new SubModelDto
				{
					Id = c.SubModel.Id,
					Name = c.SubModel.Name,
					PriceIncreace = c.SubModel.PriceIncreace
				},
				FeatureOptions = c.FeatureOptions.Select(f => new FeatureOptionDto
				{
					Id = f.Id,
					Name = f.Name,
					Price = f.Price
				}).ToList()
			}).ToList();
#pragma warning restore CS8601 // Possible null reference assignment.

			return dtos;
		}

		public async Task<CarModel> GetModelByIdAsync(string carModelID)
		{
			return await _context.CarModels
				.Include(c => c.SubModel)
				.Include(c => c.ColorOption)
				.Include(c => c.InteriorOption)
				.Include(c => c.WheelOption)
				.Include(c => c.TrimOption)
				.Include(c => c.FeatureOptions).FirstOrDefaultAsync(c => c.Id == carModelID);
		}

		public async Task<List<SubModel>> GetAllSubModelsAsync()
		{
			return await _context.SubModels.ToListAsync();
		}
	}
}
