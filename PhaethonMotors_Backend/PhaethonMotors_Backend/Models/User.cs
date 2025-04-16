using PhaethonMotors_Backend.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PhaethonMotors_Backend.Models
{
	public class User
	{
		[Key]
		public string Id { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string PasswordHash { get; set; }
		[Required]
		public Roles Role { get; set; }

		public ICollection<CustomizedCar>? CustomizedCars { get; set; }

	}
}
