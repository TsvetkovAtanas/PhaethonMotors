using Microsoft.EntityFrameworkCore;
using PhaethonMotors_Backend.Data;
using PhaethonMotors_Backend.Models;

namespace PhaethonMotors_Backend.Repository
{
	public class TrimRepository
	{
		private readonly PhaethonDbContext _context;

		public TrimRepository(PhaethonDbContext context)
		{
			_context = context;
		}

		public async Task<List<TrimOption>> GetAllTrimsAsync()
		{
			return await _context.TrimOptions.ToListAsync();
		}

		public async Task<TrimOption> GetTrimByIdAsync(string TrimOptionID)
		{
			return await _context.TrimOptions.FirstOrDefaultAsync(c => c.Id == TrimOptionID);
		}
	}
}
