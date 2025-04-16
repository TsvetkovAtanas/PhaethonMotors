using System.ComponentModel.DataAnnotations;

namespace PhaethonMotors_Backend.Models
{
	public class CarModel
	{
		[Key]
		public string Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string FuelType1 { get; set; }
		[Required]
		public string FuelType2 { get; set; }
		[Required]
		public string CarImage { get; set; }
		[Required]
		public decimal BasePrice { get; set; }
		[Required]
		public int Horsepower { get; set; }
		[Required]
		public int Torque { get; set; }
		[Required]
		public decimal TopSpeed { get; set; }
		[Required]
		public decimal Acceleration { get; set; }
		[Required]
		public int SeatingCapacity { get; set; }
		[Required]
		public decimal CargoSpace { get; set; }
		[Required]
		public string Transmission { get; set; }
		[Required]
		public string DriveType { get; set; }


		// Foreign keys for single selection relationships:
		public string ColorOptionId { get; set; }
		public ColorOption ColorOption { get; set; }

		public string InteriorOptionId { get; set; }
		public InteriorOption InteriorOption { get; set; }

		public string TrimOptionId { get; set; }
		public TrimOption TrimOption { get; set; }

		public string WheelOptionId { get; set; }
		public WheelOption WheelOption { get; set; }

		public string SubModelId { get; set; }
		public SubModel SubModel { get; set; }

		// Many-to-many for features:
		public ICollection<FeatureOption> FeatureOptions { get; set; } = new List<FeatureOption>();
	}
}
