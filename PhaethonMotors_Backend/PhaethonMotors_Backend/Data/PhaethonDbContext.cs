using Microsoft.EntityFrameworkCore;
using PhaethonMotors_Backend.Models;

namespace PhaethonMotors_Backend.Data
{
	public class PhaethonDbContext : DbContext
	{
		public DbSet<CarModel> CarModels { get; set; }
		public DbSet<ColorOption> ColorOptions { get; set; }
		public DbSet<FeatureOption> FeatureOptions { get; set; }
		public DbSet<InteriorOption> InteriorOptions { get; set; }
		public DbSet<TrimOption> TrimOptions { get; set; }
		public DbSet<WheelOption> WheelOptions { get; set; }
		public DbSet<SubModel> SubModels { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<CustomizedCar> CustomizedCars { get; set; }

		public PhaethonDbContext(DbContextOptions<PhaethonDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// One-to-many for ColorOption:
			modelBuilder.Entity<CarModel>()
				.HasOne(cm => cm.ColorOption)
				.WithMany(co => co.CarModels)
				.HasForeignKey(cm => cm.ColorOptionId)
				.OnDelete(DeleteBehavior.Restrict);

			// One-to-many for InteriorOption:
			modelBuilder.Entity<CarModel>()
				.HasOne(cm => cm.InteriorOption)
				.WithMany(io => io.CarModels)
				.HasForeignKey(cm => cm.InteriorOptionId)
				.OnDelete(DeleteBehavior.Restrict);

			// One-to-many for TrimOption:
			modelBuilder.Entity<CarModel>()
				.HasOne(cm => cm.TrimOption)
				.WithMany(to => to.CarModels)
				.HasForeignKey(cm => cm.TrimOptionId)
				.OnDelete(DeleteBehavior.Restrict);

			// One-to-many for WheelOption:
			modelBuilder.Entity<CarModel>()
				.HasOne(cm => cm.WheelOption)
				.WithMany(wo => wo.CarModels)
				.HasForeignKey(cm => cm.WheelOptionId)
				.OnDelete(DeleteBehavior.Restrict);

			// One-to-many for SubModel:
			modelBuilder.Entity<CarModel>()
				.HasOne(cm => cm.SubModel)
				.WithMany(co => co.CarModels)
				.HasForeignKey(cm => cm.SubModelId)
				.OnDelete(DeleteBehavior.Restrict);

			// Many-to-many for FeatureOption:
			modelBuilder.Entity<CarModel>()
				.HasMany(cm => cm.FeatureOptions)
				.WithMany(fo => fo.CarModels)
				.UsingEntity(j => j.ToTable("CarModelFeatureOptions"));

			base.OnModelCreating(modelBuilder);
		}
	}
}
