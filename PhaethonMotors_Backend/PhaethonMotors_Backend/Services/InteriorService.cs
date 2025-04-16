using PhaethonMotors_Backend.Models;
using PhaethonMotors_Backend.Repository;

namespace PhaethonMotors_Backend.Services
{
	public class InteriorService
	{
		private readonly InteriorRepository _interiorRepository;
		public InteriorService(InteriorRepository interiorRepository)
		{
			_interiorRepository = interiorRepository;
		}

		public async Task<List<InteriorOption>> ServiceGetAllInteriorsAsync()
		{
			return await _interiorRepository.GetAllInteriorsAsync();
		}

		public async Task<InteriorOption> ServiceGetInteriorByIdAsync(string InteriorOptionID)
		{
			return await _interiorRepository.GetInteriorByIdAsync(InteriorOptionID);
		}
	}
}
