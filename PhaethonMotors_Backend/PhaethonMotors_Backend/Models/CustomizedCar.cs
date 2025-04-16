using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PhaethonMotors_Backend.Models
{
	public class CustomizedCar
	{
		[Key]
		public string Id { get; set; }
		[Required]
		public string CarModelId { get; set; }
		[Required]
		public string SelectedColorId { get; set; }
		[Required]
		public string SelectedInteriorId { get; set; }
		[Required]
		public string SelectedWheelsId { get; set; }
		[Required]
		public string SelectedTrimId { get; set; }
		[Required]
		public List<string> SelectedFeaturesIds { get; set; }


		public string sketchModelUID { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime SavedAt { get; set; } = DateTime.UtcNow;

		
		[ForeignKey("User")]
		public string UserId { get; set; }
		public User User { get; set; }
	}
}
