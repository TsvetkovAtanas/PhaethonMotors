using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PhaethonMotors_Backend.Data;
using PhaethonMotors_Backend.Repository;
using PhaethonMotors_Backend.Services;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Database Connection
builder.Services.AddDbContext<PhaethonDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.
builder.Services.AddScoped<CarModelsRepository>();
builder.Services.AddScoped<ColorRepository>();
builder.Services.AddScoped<InteriorRepository>();
builder.Services.AddScoped<WheelRepository>();
builder.Services.AddScoped<TrimRepository>();
builder.Services.AddScoped<FeatureRepository>();
builder.Services.AddScoped<AuthRepository>();
builder.Services.AddScoped<UserProfileRepository>();

builder.Services.AddScoped<CarModelsService>();
builder.Services.AddScoped<ColorService>();
builder.Services.AddScoped<InteriorService>();
builder.Services.AddScoped<WheelService>();
builder.Services.AddScoped<TrimService>();
builder.Services.AddScoped<FeatureService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserProfileService>();

builder.Services.AddControllers();

builder.Configuration
	.SetBasePath(Directory.GetCurrentDirectory())
	.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
	.AddEnvironmentVariables();

// Configure JWT authentication
var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:Secret"]);
builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
	options.RequireHttpsMetadata = false; // Set true in production
	options.SaveToken = true;
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(key),
		ValidateIssuer = false, // set true and provide valid issuer in production
		ValidateAudience = false, // set true and provide valid audience in production
		RoleClaimType = ClaimTypes.Role
	};
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
	});


builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowFrontend",
		policy =>
		{
			policy.WithOrigins("http://localhost:5173")
				  .AllowAnyHeader()
				  .AllowAnyMethod()
				  .AllowCredentials()
				  .WithExposedHeaders("Authorization");
		});
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	var context = services.GetRequiredService<PhaethonDbContext>();

	var initialSeed = new InitialSeed(context);
	await initialSeed.AddInitialCarModels();
}

app.UseCors("AllowFrontend");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
