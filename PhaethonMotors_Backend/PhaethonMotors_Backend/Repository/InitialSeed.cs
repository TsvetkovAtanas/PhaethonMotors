using Microsoft.EntityFrameworkCore;
using PhaethonMotors_Backend.Data;
using PhaethonMotors_Backend.Models;

namespace PhaethonMotors_Backend.Repository
{
	public class InitialSeed
	{
		private readonly PhaethonDbContext _context;

		public InitialSeed(PhaethonDbContext context)
		{
			_context = context;
		}

		public async Task AddInitialCarModels()
		{
			if (_context.CarModels.Any()) return;

			var defaultColor = await AddColor("Base Model Color", "#000000", 0);
			var blackColor = await AddColor("Black Mat", "#000000", 500);
			var greyColor = await AddColor("Grey", "#808080", 500);
			var redColor = await AddColor("Red", "#FF0000", 500);
			var yellowColor = await AddColor("Yellow", "#FFFF00", 500);
			var whiteColor = await AddColor("White", "#FFFFFF", 500);
			var purpleColor = await AddColor("Purple", "#A020F0", 500);

			var featureDef = await AddFeature("Base Model Features", 0);
			var featureAEB = await AddFeature("Automatic Emergency Braking", 5000);
			var featureACC = await AddFeature("Adaptive Cruise Control", 3500);
			var featureAP = await AddFeature("Auto Parking", 6700);
			var featureAH = await AddFeature("Adaptive Headlights", 8700);
			var featureHD = await AddFeature("Head-up Display",2600);
			var featurePC = await AddFeature("Parking Cameras", 4350);

			var interiorDef = await AddInterior("Default Interior", "Base model!", 0);
			var interiorAC = await AddInterior("Aetherium Cabin", "Hand-stitched Alcantara, premium Nappa leather, real ebony wood, and gold accents.", 50000);
			var interiorOL = await AddInterior("Obsidian Lounge", "Carbon fiber, perforated black leather, brushed titanium, and dark suede.", 30000);
			var interiorSE = await AddInterior("Solaris Elegance", "Vegan leather, Eucalyptus wood, and matte aluminum.", 20000);

			var trimDef = await AddTrim("Default", 0, 0, "Base model!");
			var trimApT = await AddTrim("Apex Trim", 55300, 150, "Adjustable Race-Tuned Coilover Suspension for razor-sharp handling.");
			var trimPhT = await AddTrim("Phaethon Trim", 30000, 80, "Adaptive Air Suspension with Magic Ride Control for an ultra-smooth experience.");
			var trimAtT = await AddTrim("Atlas Trim", 40000, 120, "Heavy-Duty Active Off-Road Suspension with hydraulic lift system.");

			var wheelDef = await AddWheel("Base model wheels", 0);
			var wheelT = await AddWheel("TurboSpin diamon cut rims", 8000);
			var wheelV = await AddWheel("VortexX alloy wheels", 2000);
			var wheelP = await AddWheel("PhantomTrack racing wheels", 10000);

			var subASpyder = await AddSubModel("Spyder", 0);
			var subAGT = await AddSubModel("GT", 30000);
			var subARSX = await AddSubModel("RSX", 60000);
			var subHS = await AddSubModel("S", 0);
			var subHL = await AddSubModel("L", 5000);
			var subHVT = await AddSubModel("VT", 10000);
			var subHeR = await AddSubModel("R", 0);
			var subHeGTS = await AddSubModel("GTS", 10000);
			var subHeVX12 = await AddSubModel("VX12", 10000);
			var subIRoyale = await AddSubModel("Royale", 0);
			var subIVeloce = await AddSubModel("Veloce", 5000);
			var subIOpusLuxe = await AddSubModel("OpusLuxe", 7000);
			var subIPhantom = await AddSubModel("Phantom", 30000);
			var subTXTrail = await AddSubModel("X-Trail", 0);
			var subTAero = await AddSubModel("Aero", 5000);
			var subTLX = await AddSubModel("LX", 5700);
			var subTApex = await AddSubModel("Apex", 10700);


			var carModels = new List<CarModel>
			{
				new CarModel
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Aether",
					SubModel = subASpyder,
					FuelType1 = "Gasoline",
					FuelType2 = "",
					CarImage = "~/assets/phaethon-model-1-final.png",
					BasePrice = 120000m,
					Horsepower = 518,
					Torque = 600,
					TopSpeed = 296m,
					Acceleration = 4.5m,
					SeatingCapacity = 2,
					CargoSpace = 10m,
					Transmission = "Automatic",
					DriveType = "FWD",
					ColorOption = defaultColor,
					InteriorOption = interiorDef,
					TrimOption = trimDef,
					WheelOption = wheelDef,
                    FeatureOptions = new List<FeatureOption>{ featureDef }
				},
				new CarModel
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Aether",
					SubModel = subAGT,
					FuelType1 = "Gasoline",
					FuelType2 = "",
					CarImage = "~/assets/aether_gt.jpg",
					BasePrice = 150000m,
					Horsepower = 538,
					Torque = 620,
					TopSpeed = 298m,
					Acceleration = 3.5m,
					SeatingCapacity = 2,
					CargoSpace = 10m,
					Transmission = "Manual",
					DriveType = "AWD",
					ColorOption = defaultColor,
					InteriorOption = interiorDef,
					TrimOption = trimDef,
					WheelOption = wheelDef,
					FeatureOptions = new List<FeatureOption>{ featureDef }
				},
				new CarModel
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Aether",
					SubModel = subARSX,
					FuelType1 = "Gasoline",
					FuelType2 = "",
					CarImage = "~/assets/aether_rsx.jpg",
					BasePrice = 180000m,
					Horsepower = 688,
					Torque = 690,
					TopSpeed = 320m,
					Acceleration = 3m,
					SeatingCapacity = 2,
					CargoSpace = 5.5m,
					Transmission = "Automatic",
					DriveType = "AWD",
					ColorOption = defaultColor,
					InteriorOption = interiorDef,
					TrimOption = trimDef,
					WheelOption = wheelDef,
					FeatureOptions = new List<FeatureOption>{ featureDef }
				},

				new CarModel
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Hyperion",
					SubModel = subHS,
					FuelType1 = "Gasoline",
					FuelType2 = "",
					CarImage = "~/assets/phaethon-model-2.png",
					BasePrice = 150000m,
					Horsepower = 498,
					Torque = 600,
					TopSpeed = 289m,
					Acceleration = 4m,
					SeatingCapacity = 5,
					CargoSpace = 15.5m,
					Transmission = "Manual",
					DriveType = "RWD",
					ColorOption = defaultColor,
					InteriorOption = interiorDef,
					TrimOption = trimDef,
					WheelOption = wheelDef,
					FeatureOptions = new List<FeatureOption>{ featureDef }
				},
				new CarModel
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Hyperion",
					SubModel = subHL,
					FuelType1 = "Gasoline",
					FuelType2 = "",
					CarImage = "~/assets/phaethon-model-2.png",
					BasePrice = 155000m,
					Horsepower = 488,
					Torque = 590,
					TopSpeed = 280m,
					Acceleration = 4.5m,
					SeatingCapacity = 5,
					CargoSpace = 18m,
					Transmission = "Automatic",
					DriveType = "FWD",
					ColorOption = defaultColor,
					InteriorOption = interiorDef,
					TrimOption = trimDef,
					WheelOption = wheelDef,
					FeatureOptions = new List<FeatureOption>{ featureDef }
				},
				new CarModel
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Hyperion",
					SubModel = subHVT,
					FuelType1 = "Gasoline",
					FuelType2 = "",
					CarImage = "~/assets/phaethon-model-2.png",
					BasePrice = 160000m,
					Horsepower = 500,
					Torque = 610,
					TopSpeed = 290m,
					Acceleration = 3.5m,
					SeatingCapacity = 5,
					CargoSpace = 18m,
					Transmission = "Automatic",
					DriveType = "AWD",
					ColorOption = defaultColor,
					InteriorOption = interiorDef,
					TrimOption = trimDef,
					WheelOption = wheelDef,
					FeatureOptions = new List<FeatureOption>{ featureDef }
				},

				new CarModel
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Helios",
					SubModel = subHeR,
					FuelType1 = "Hybrid",
					FuelType2 = "",
					CarImage = "~/assets/phaethon-model-4.png",
					BasePrice = 140000m,
					Horsepower = 450,
					Torque = 560,
					TopSpeed = 290m,
					Acceleration = 3.5m,
					SeatingCapacity = 2,
					CargoSpace = 10m,
					Transmission = "Manual",
					DriveType = "FWD",
					ColorOption = defaultColor,
					InteriorOption = interiorDef,
					TrimOption = trimDef,
					WheelOption = wheelDef,
					FeatureOptions = new List<FeatureOption>{ featureDef }
				},
				new CarModel
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Helios",
					SubModel = subHeGTS,
					FuelType1 = "Gasoline",
					FuelType2 = "",
					CarImage = "~/assets/phaethon-model-4.png",
					BasePrice = 150000m,
					Horsepower = 500,
					Torque = 660,
					TopSpeed = 299m,
					Acceleration = 2.5m,
					SeatingCapacity = 2,
					CargoSpace = 8m,
					Transmission = "Automatic",
					DriveType = "AWD",
					ColorOption = defaultColor,
					InteriorOption = interiorDef,
					TrimOption = trimDef,
					WheelOption = wheelDef,
					FeatureOptions = new List<FeatureOption>{ featureDef }
				},
				new CarModel
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Helios",
					SubModel = subHeVX12,
					FuelType1 = "Gasoline",
					FuelType2 = "",
					CarImage = "~/assets/phaethon-model-4.png",
					BasePrice = 150000m,
					Horsepower = 760,
					Torque = 720,
					TopSpeed = 320m,
					Acceleration = 3.5m,
					SeatingCapacity = 2,
					CargoSpace = 5m,
					Transmission = "Automatic",
					DriveType = "AWD",
					ColorOption = defaultColor,
					InteriorOption = interiorDef,
					TrimOption = trimDef,
					WheelOption = wheelDef,
					FeatureOptions = new List<FeatureOption>{ featureDef }
				},

				new CarModel
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Imperium",
					SubModel= subIRoyale,
					FuelType1 = "Hybrid",
					FuelType2 = "",
					CarImage = "~/assets/phaethon-model-5.png",
					BasePrice = 220000m,
					Horsepower = 360,
					Torque = 520,
					TopSpeed = 250m,
					Acceleration = 5.5m,
					SeatingCapacity = 5,
					CargoSpace = 20m,
					Transmission = "Automatic",
					DriveType = "AWD",
					ColorOption = defaultColor,
					InteriorOption = interiorDef,
					TrimOption = trimDef,
					WheelOption = wheelDef,
					FeatureOptions = new List<FeatureOption>{ featureDef }
				},
				new CarModel
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Imperium",
					SubModel= subIVeloce,
					FuelType1 = "Gasoline",
					FuelType2 = "",
					CarImage = "~/assets/phaethon-model-5.png",
					BasePrice = 225000m,
					Horsepower = 370,
					Torque = 530,
					TopSpeed = 260m,
					Acceleration = 5.2m,
					SeatingCapacity = 5,
					CargoSpace = 20m,
					Transmission = "Manual",
					DriveType = "FWD",
					ColorOption = defaultColor,
					InteriorOption = interiorDef,
					TrimOption = trimDef,
					WheelOption = wheelDef,
					FeatureOptions = new List<FeatureOption>{ featureDef }
				},
				new CarModel
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Imperium",
					SubModel= subIOpusLuxe,
					FuelType1 = "Gasoline",
					FuelType2 = "",
					CarImage = "~/assets/phaethon-model-5.png",
					BasePrice = 227000m,
					Horsepower = 375,
					Torque = 535,
					TopSpeed = 265m,
					Acceleration = 5.5m,
					SeatingCapacity = 5,
					CargoSpace = 20m,
					Transmission = "Automatic",
					DriveType = "AWD",
					ColorOption = defaultColor,
					InteriorOption = interiorDef,
					TrimOption = trimDef,
					WheelOption = wheelDef,
					FeatureOptions = new List<FeatureOption>{ featureDef }
				},
				new CarModel
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Imperium",
					SubModel= subIPhantom,
					FuelType1 = "Hybrid",
					FuelType2 = "",
					CarImage = "~/assets/phaethon-model-5.png",
					BasePrice = 250000m,
					Horsepower = 450,
					Torque = 600,
					TopSpeed = 290m,
					Acceleration = 4.5m,
					SeatingCapacity = 5,
					CargoSpace = 20m,
					Transmission = "Automatic",
					DriveType = "AWD",
					ColorOption = defaultColor,
					InteriorOption = interiorDef,
					TrimOption = trimDef,
					WheelOption = wheelDef,
					FeatureOptions = new List<FeatureOption>{ featureDef }
				},

				new CarModel
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Titanus",
					SubModel= subTXTrail,
					FuelType1 = "Gasoline",
					FuelType2 = "",
					CarImage = "~/assets/phaethon-model-3.png",
					BasePrice = 120000m,
					Horsepower = 350,
					Torque = 500,
					TopSpeed = 260m,
					Acceleration = 5.5m,
					SeatingCapacity = 5,
					CargoSpace = 25.5m,
					Transmission = "Automatic",
					DriveType = "AWD",
					ColorOption = defaultColor,
					InteriorOption = interiorDef,
					TrimOption = trimDef,
					WheelOption = wheelDef,
					FeatureOptions = new List<FeatureOption>{ featureDef }
				},
				new CarModel
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Titanus",
					SubModel= subTAero,
					FuelType1 = "Electric",
					FuelType2 = "",
					CarImage = "~/assets/phaethon-model-3.png",
					BasePrice = 125000m,
					Horsepower = 380,
					Torque = 560,
					TopSpeed = 280m,
					Acceleration = 5m,
					SeatingCapacity = 5,
					CargoSpace = 25.5m,
					Transmission = "Automatic",
					DriveType = "AWD",
					ColorOption = defaultColor,
					InteriorOption = interiorDef,
					TrimOption = trimDef,
					WheelOption = wheelDef,
					FeatureOptions = new List<FeatureOption>{ featureDef }
				},
				new CarModel
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Titanus",
					SubModel= subTLX,
					FuelType1 = "Electric",
					FuelType2 = "",
					CarImage = "~/assets/phaethon-model-3.png",
					BasePrice = 125700m,
					Horsepower = 387,
					Torque = 567,
					TopSpeed = 287m,
					Acceleration = 4.8m,
					SeatingCapacity = 5,
					CargoSpace = 25.5m,
					Transmission = "Automatic",
					DriveType = "AWD",
					ColorOption = defaultColor,
					InteriorOption = interiorDef,
					TrimOption = trimDef,
					WheelOption = wheelDef,
					FeatureOptions = new List<FeatureOption>{ featureDef }
				},
				new CarModel
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Titanus",
					SubModel= subTApex,
					FuelType1 = "Gasoline",
					FuelType2 = "",
					CarImage = "~/assets/phaethon-model-3.png",
					BasePrice = 130700m,
					Horsepower = 490,
					Torque = 860,
					TopSpeed = 298m,
					Acceleration = 5m,
					SeatingCapacity = 5,
					CargoSpace = 25.5m,
					Transmission = "Automatic",
					DriveType = "AWD",
					ColorOption = defaultColor,
					InteriorOption = interiorDef,
					TrimOption = trimDef,
					WheelOption = wheelDef,
					FeatureOptions = new List<FeatureOption>{ featureDef }
				},
			};
			await _context.CarModels.AddRangeAsync(carModels);
			await _context.SaveChangesAsync();
		}

		public async Task<ColorOption> AddColor(string name, string hexCode, decimal price)
		{
			var existingColor = await _context.ColorOptions
				.FirstOrDefaultAsync(c => c.Name == name);
			if (existingColor != null) return existingColor;

			var newColor = new ColorOption
			{
				Id = Guid.NewGuid().ToString(),
				Name = name,
				HexCode = hexCode,
				Price = price,
			};

			_context.ColorOptions.Add(newColor);
			await _context.SaveChangesAsync();
			return newColor;
		}

		public async Task<FeatureOption> AddFeature(string name, decimal price)
		{
			var existingFeature = await _context.FeatureOptions
				.FirstOrDefaultAsync(c => c.Name == name);
			if(existingFeature != null) return existingFeature;

			var newFeature = new FeatureOption { Id = Guid.NewGuid().ToString(), Name = name, Price = price };

			_context.FeatureOptions.Add(newFeature);
			await _context.SaveChangesAsync();
			return newFeature;
		}

		public async Task<InteriorOption> AddInterior(string name, string material, decimal price)
		{
			var existingInterior = await _context.InteriorOptions
				.FirstOrDefaultAsync(c => c.Name == name);
			if (existingInterior != null) return existingInterior;

			var newInterior = new InteriorOption { Id = Guid.NewGuid().ToString(), Name = name, Material = material, Price = price };

			_context.InteriorOptions.Add(newInterior);
			await _context.SaveChangesAsync();
			return newInterior;
		}

		public async Task<TrimOption> AddTrim(string name, decimal priceIncrease, int horsepowerIncrease, string suspension)
		{
			var existingTrim = await _context.TrimOptions.FirstOrDefaultAsync(c => c.Name == name);
			if (existingTrim != null) return existingTrim;

			var newTrim = new TrimOption { Id = Guid.NewGuid().ToString(), Name = name, PriceIncrease = priceIncrease, HorsepowerIncrease = horsepowerIncrease, Suspension = suspension };

			_context.TrimOptions.Add(newTrim);
			await _context.SaveChangesAsync();
			return newTrim;
		}

		public async Task<WheelOption> AddWheel(string name, decimal price)
		{
			var existingWheel = await _context.WheelOptions.FirstOrDefaultAsync(c => c.Name == name);
			if (existingWheel != null) return existingWheel;

			var newWheel = new WheelOption { Id = Guid.NewGuid().ToString(), Name = name, Price = price };

			_context.WheelOptions.Add(newWheel);
			await _context.SaveChangesAsync();
			return newWheel;
		}

		public async Task<SubModel> AddSubModel(string name, decimal priceIncrease)
		{
			var existingSubModel = await _context.SubModels.FirstOrDefaultAsync(c => c.Name == name);
			if (existingSubModel != null) return existingSubModel;

			var newSubModel = new SubModel { Id = Guid.NewGuid().ToString(), Name = name, PriceIncreace = priceIncrease };

			_context.SubModels.Add(newSubModel);
			await _context.SaveChangesAsync();
			return newSubModel;
		}
	}
}
