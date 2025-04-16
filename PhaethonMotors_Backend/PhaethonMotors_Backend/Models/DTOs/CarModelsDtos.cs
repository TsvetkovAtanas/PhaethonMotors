using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PhaethonMotors_Backend.Models.DTOs
{
	public class CarModelDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string FuelType1 { get; set; }
		public string FuelType2 { get; set; }
		public string CarImage { get; set; }
		public decimal BasePrice { get; set; }
		public int Horsepower { get; set; }
		public int Torque { get; set; }
		public decimal TopSpeed { get; set; }
		public decimal Acceleration { get; set; }
		public int SeatingCapacity { get; set; }
		public decimal CargoSpace { get; set; }
		public string Transmission { get; set; }
		public string DriveType { get; set; }

		public ColorOptionDto ColorOption { get; set; }
		public InteriorOptionDto InteriorOption { get; set; }
		public TrimOptionDto TrimOption { get; set; }
		public WheelOptionDto WheelOption { get; set; }
		public SubModelDto SubModel { get; set; }
		public List<FeatureOptionDto> FeatureOptions { get; set; }
	}

	public class CustomizedCarDto
	{
		public string Id { get; set; }
		public string CarModelId { get; set; }
		public string SelectedColorId { get; set; }
		public string SelectedInteriorId { get; set; }
		public string SelectedWheelsId { get; set; }
		public string SelectedTrimId { get; set; }
		public List<string> SelectedFeaturesIds { get; set; }

		public string sketchModelUID { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime SavedAt { get; set; } = DateTime.UtcNow;

		public string UserId { get; set; }
	}

	public class ColorOptionDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string HexCode { get; set; }
		public decimal Price { get; set; }
	}

	public class InteriorOptionDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Material { get; set; }
		public decimal Price { get; set; }
	}

	public class TrimOptionDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public decimal PriceIncrease { get; set; }
		public int HorsepowerIncrease { get; set; }
		public string Suspension { get; set; }
	}

	public class WheelOptionDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
	}

	public class SubModelDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public decimal PriceIncreace { get; set; }
	}

	public class FeatureOptionDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
	}

}
