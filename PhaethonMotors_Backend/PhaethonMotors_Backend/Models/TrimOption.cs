using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhaethonMotors_Backend.Models
{
	public class TrimOption
	{
		[Key]
		public string Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public decimal PriceIncrease { get; set; }
		[Required]
		public int HorsepowerIncrease { get; set; }
		[Required]
		public string Suspension { get; set; }


		// Navigation property for reverse relationship:
		public ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();
	}
}
