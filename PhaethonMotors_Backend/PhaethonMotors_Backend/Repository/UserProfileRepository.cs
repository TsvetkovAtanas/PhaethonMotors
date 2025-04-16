using Microsoft.EntityFrameworkCore;
using PhaethonMotors_Backend.Data;
using PhaethonMotors_Backend.Models;
using PhaethonMotors_Backend.Models.DTOs;

namespace PhaethonMotors_Backend.Repository
{
	public class UserProfileRepository
	{
		private readonly PhaethonDbContext _context;

		public UserProfileRepository(PhaethonDbContext context)
		{
			_context = context;
		}

		public async Task<User> GetUserInfoAsync(string loggedUserId)
		{

			return await _context.Users.Include(c => c.CustomizedCars).FirstOrDefaultAsync(u => u.Id == loggedUserId);
		}

		public async Task<CustomizedCar> AddCustomizedCarAsync(CustomizedCarDto dto)
		{
			var customCar = new CustomizedCar
			{
				Id = Guid.NewGuid().ToString(),
				CarModelId = dto.CarModelId,
				SelectedColorId = dto.SelectedColorId,
				SelectedInteriorId = dto.SelectedInteriorId,
				SelectedWheelsId = dto.SelectedWheelsId,
				SelectedTrimId = dto.SelectedTrimId,
				SelectedFeaturesIds = dto.SelectedFeaturesIds,
				sketchModelUID = dto.sketchModelUID,
				TotalPrice = dto.TotalPrice,
				SavedAt = DateTime.UtcNow,
				UserId = dto.UserId,
			};
			await _context.CustomizedCars.AddAsync(customCar);
			await _context.SaveChangesAsync();
			return customCar;
		}
	}
}
