using Microsoft.EntityFrameworkCore;
using PhaethonMotors_Backend.Data;
using PhaethonMotors_Backend.Models;

namespace PhaethonMotors_Backend.Repository
{
	public class ColorRepository
	{
		private readonly PhaethonDbContext _context;

		public ColorRepository(PhaethonDbContext context)
		{
			_context = context;
		}

		public async Task<List<ColorOption>> GetAllColorsAsync()
		{
			return await _context.ColorOptions.ToListAsync();
		}

		public async Task<ColorOption> GetColorByIdAsync(string ColorOptionID)
		{
			return await _context.ColorOptions.FirstOrDefaultAsync(c => c.Id == ColorOptionID);
		}
	}
}
