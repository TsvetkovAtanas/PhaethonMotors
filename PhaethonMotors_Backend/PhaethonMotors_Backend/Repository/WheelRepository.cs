using Microsoft.EntityFrameworkCore;
using PhaethonMotors_Backend.Data;
using PhaethonMotors_Backend.Models;

namespace PhaethonMotors_Backend.Repository
{
	public class WheelRepository
	{
		private readonly PhaethonDbContext _context;

		public WheelRepository(PhaethonDbContext context)
		{
			_context = context;
		}

		public async Task<List<WheelOption>> GetAllWheelsAsync()
		{
			return await _context.WheelOptions.ToListAsync();
		}

		public async Task<WheelOption> GetWheelByIdAsync(string WheelOptionID)
		{
			return await _context.WheelOptions.FirstOrDefaultAsync(c => c.Id == WheelOptionID);
		}
	}
}
