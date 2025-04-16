﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhaethonMotors_Backend.Models
{
	public class InteriorOption
	{
		[Key]
		public string Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Material { get; set; }
		[Required]
		public decimal Price { get; set; }


		// Navigation property for reverse relationship:
		public ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();
	}
}
