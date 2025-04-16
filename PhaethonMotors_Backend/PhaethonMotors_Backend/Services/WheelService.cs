using PhaethonMotors_Backend.Models;
using PhaethonMotors_Backend.Repository;

namespace PhaethonMotors_Backend.Services
{
	public class WheelService
	{
		private readonly WheelRepository _wheelRepository;
		public WheelService(WheelRepository wheelRepository)
		{
			_wheelRepository = wheelRepository;
		}

		public async Task<List<WheelOption>> ServiceGetAllWheelsAsync()
		{
			return await _wheelRepository.GetAllWheelsAsync();
		}

		public async Task<WheelOption> ServiceGetWheelByIdAsync(string WheelOptionID)
		{
			return await _wheelRepository.GetWheelByIdAsync(WheelOptionID);
		}
	}
}
