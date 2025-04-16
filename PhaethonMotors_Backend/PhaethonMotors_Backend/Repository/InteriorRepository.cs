using Microsoft.EntityFrameworkCore;
using PhaethonMotors_Backend.Data;
using PhaethonMotors_Backend.Models;

namespace PhaethonMotors_Backend.Repository
{
	public class InteriorRepository
	{
		private readonly PhaethonDbContext _context;

		public InteriorRepository(PhaethonDbContext context)
		{
			_context = context;
		}

		public async Task<List<InteriorOption>> GetAllInteriorsAsync()
		{
			return await _context.InteriorOptions.ToListAsync();
		}

		public async Task<InteriorOption> GetInteriorByIdAsync(string InteriorOptionID)
		{
			return await _context.InteriorOptions.FirstOrDefaultAsync(c => c.Id == InteriorOptionID);
		}
	}
}
