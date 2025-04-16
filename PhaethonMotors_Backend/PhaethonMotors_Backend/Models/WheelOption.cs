using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PhaethonMotors_Backend.Models
{
	public class WheelOption
	{
		[Key]
		public string Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public decimal Price { get; set; }


		// Navigation property for reverse relationship:
		public ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();
	}
}
