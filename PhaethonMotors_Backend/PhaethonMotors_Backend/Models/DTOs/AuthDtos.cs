using PhaethonMotors_Backend.Models.Enums;

namespace PhaethonMotors_Backend.Models.DTOs
{
	public class RegisterDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}

	public class LoginDto
	{
		public string Email { get; set; }
		public string Password{ get; set; }
	}

	public class UserDto
	{
		public string Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public Roles Role { get; set; }
		public ICollection<CustomizedCar> CustomizedCars { get; set; }
	}
}
