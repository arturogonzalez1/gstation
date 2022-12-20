using AutoMapper;
using GStation.Core.Models;
using GStation.Core.Mapping;
using GStation.Persistence.EF;
using GStation.Persistence.EF.Seed;
using GStation.Services;
using GStation.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GStation.Persistence.Repositories;
using GStation.Persistence.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:key"])),
            ClockSkew = TimeSpan.Zero
        });

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Lockout.AllowedForNewUsers = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(builder => builder.AddProfiles(new List<Profile>
{
    new UserMapping(),
    new PersonMapping(),
    new CustomerMapping(),
    new AddressMapping(),
    new CustomerAddressMapping(),
}));

builder.Services.AddTransient<IAuthService, AuthService>();

builder.Services.AddTransient<IPersonService, PersonService>();
builder.Services.AddTransient<IPersonRepository, PersonRepository>();

builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

builder.Services.AddTransient<ILocationService, LocationService>();
builder.Services.AddTransient<ILocationRepository, LocationRepository>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Initializing Database
app.Services.InitializeDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
