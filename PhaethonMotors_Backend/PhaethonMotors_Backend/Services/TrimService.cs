using PhaethonMotors_Backend.Models;
using PhaethonMotors_Backend.Repository;

namespace PhaethonMotors_Backend.Services
{
	public class TrimService
	{
		private readonly TrimRepository _trimRepository;
		public TrimService(TrimRepository trimRepository)
		{
			_trimRepository = trimRepository;
		}

		public async Task<List<TrimOption>> ServiceGetAllTrimsAsync()
		{
			return await _trimRepository.GetAllTrimsAsync();
		}

		public async Task<TrimOption> ServiceGetTrimByIdAsync(string TrimOptionID)
		{
			return await _trimRepository.GetTrimByIdAsync(TrimOptionID);
		}
	}
}
