using Microsoft.EntityFrameworkCore;
using PhaethonMotors_Backend.Data;
using PhaethonMotors_Backend.Models;

namespace PhaethonMotors_Backend.Repository
{
	public class FeatureRepository
	{
		private readonly PhaethonDbContext _context;

		public FeatureRepository(PhaethonDbContext context)
		{
			_context = context;
		}

		public async Task<List<FeatureOption>> GetAllFeaturesAsync()
		{
			return await _context.FeatureOptions.ToListAsync();
		}

		public async Task<FeatureOption> GetFeatureByIdAsync(string FeatureOptionID)
		{
			return await _context.FeatureOptions.FirstOrDefaultAsync(c => c.Id == FeatureOptionID);
		}
	}
}
