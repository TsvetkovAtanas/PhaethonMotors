using PhaethonMotors_Backend.Models;
using PhaethonMotors_Backend.Repository;

namespace PhaethonMotors_Backend.Services
{
	public class ColorService
	{
		private readonly ColorRepository _colorsRepository;
		public ColorService(ColorRepository colorsRepository)
		{
			_colorsRepository = colorsRepository;
		}

		public async Task<List<ColorOption>> ServiceGetAllColorsAsync()
		{
			return await _colorsRepository.GetAllColorsAsync();
		}

		public async Task<ColorOption> ServiceGetColorByIdAsync(string ColorOptionID)
		{
			return await _colorsRepository.GetColorByIdAsync(ColorOptionID);
		}
	}
}
