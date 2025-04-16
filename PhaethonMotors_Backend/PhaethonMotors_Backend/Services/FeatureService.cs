using PhaethonMotors_Backend.Models;
using PhaethonMotors_Backend.Repository;

namespace PhaethonMotors_Backend.Services
{
	public class FeatureService
	{
		private readonly FeatureRepository _featureRepository;
		public FeatureService(FeatureRepository featureRepository)
		{
			_featureRepository = featureRepository;
		}

		public async Task<List<FeatureOption>> ServiceGetAllFeaturesAsync()
		{
			return await _featureRepository.GetAllFeaturesAsync();
		}

		public async Task<FeatureOption> ServiceGetFeatureByIdAsync(string FeatureOptionID)
		{
			return await _featureRepository.GetFeatureByIdAsync(FeatureOptionID);
		}
	}
}
