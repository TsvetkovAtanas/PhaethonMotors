using PhaethonMotors_Backend.Models;
using PhaethonMotors_Backend.Models.DTOs;
using PhaethonMotors_Backend.Repository;

namespace PhaethonMotors_Backend.Services
{
	public class UserProfileService
	{
		private readonly UserProfileRepository _userProfileRepository;

		public UserProfileService(UserProfileRepository userProfileRepository)
		{
			_userProfileRepository = userProfileRepository;
		}

		public async Task<User> GetUserInfoAsync(string loogedUserId)
		{
			return await _userProfileRepository.GetUserInfoAsync(loogedUserId);
		}

		public async Task<CustomizedCar> ServiceAddCustomizedCarAsync(CustomizedCarDto dto)
		{
			return await _userProfileRepository.AddCustomizedCarAsync(dto);
		}
	}
}
