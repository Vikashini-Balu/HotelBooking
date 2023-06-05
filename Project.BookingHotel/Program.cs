using Microsoft.EntityFrameworkCore;
using Project.BookingHotel.Repository.Context;
using Project.BookingHotel.Repository.Interface;
using Project.BookingHotel.Repository.Repositories;
using Project.BookingHotel.Service.Interface;
using Project.BookingHotel.Service.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HotelBookingContext>(options =>
    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PatientInformation;Trusted_Connection=True;"));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ISignUpRepository, SignUpRepository>();
builder.Services.AddScoped<ISignUpService, SignUpService>();
builder.Services.AddScoped<IHotelRoomDetailRepository, HotelRoomDetailRepository>();
builder.Services.AddScoped<IHotelRoomDetailService, HotelRoomDetailService>();
builder.Services.AddScoped<IRoomBookingDetailRepository, RoomBookingDetailRepository>();
builder.Services.AddScoped<IRoomBookingDetailService, RoomBookingDetailService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
