using Microsoft.EntityFrameworkCore;
using PhaethonMotors_Backend.Data;
using PhaethonMotors_Backend.Migrations;
using PhaethonMotors_Backend.Models;
using PhaethonMotors_Backend.Models.DTOs;

namespace PhaethonMotors_Backend.Repository
{
	public class AuthRepository
	{
		private readonly PhaethonDbContext _dbContext;

		public AuthRepository(PhaethonDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<UserDto>> GetAllUsersAsync()
		{
			var users = await _dbContext.Users.Include(u => u.CustomizedCars).ToListAsync();

			var userDtos = users.Select(u => new UserDto
			{
				Id = u.Id,
				FirstName = u.FirstName,
				LastName = u.LastName,
				Email = u.Email,
				PasswordHash = u.PasswordHash,
				Role = u.Role,
				CustomizedCars = u.CustomizedCars != null
					? u.CustomizedCars.Select(c => new CustomizedCar
					{
						Id = c.Id,
						CarModelId = c.CarModelId,
						SelectedColorId = c.SelectedColorId,
						SelectedInteriorId = c.SelectedInteriorId,
						SelectedWheelsId = c.SelectedWheelsId,
						SelectedTrimId = c.SelectedTrimId,
						SelectedFeaturesIds = c.SelectedFeaturesIds,
						sketchModelUID = c.sketchModelUID,
						TotalPrice = c.TotalPrice,
						SavedAt = c.SavedAt,
						UserId = c.UserId
					}).ToList()
					: new List<CustomizedCar>()
			}).ToList();
			return userDtos;
		}

		public async Task<User> AddUserAsync(User newUser)
		{
			var user = await _dbContext.Users.AddAsync(newUser);
			await _dbContext.SaveChangesAsync();
			return user.Entity;
		}
	}
}
