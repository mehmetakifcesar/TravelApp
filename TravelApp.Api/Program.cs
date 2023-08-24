using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TravelApp.Api.Middleware;
using TravelApp.Business.Abstract;
using TravelApp.Business.Concrete;
using TravelApp.DAL.Abstract.DataManagement;
using TravelApp.DAL.Concrete.EntityFramework.Context;
using TravelApp.DAL.Concrete.EntityFramework.DataManagement;
using TravelApp.Helper.Globals;

namespace TravelApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddDbContext<TravelAppContext>();
            builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            builder.Services.AddScoped<IUserService,UserManager>();
            builder.Services.AddScoped<ITourService,TourManager>();
            builder.Services.AddScoped<ITourGuideService,TourGuideManager>();
            builder.Services.AddScoped<ITourCompanyService, TourCompanyManager>();
            builder.Services.AddScoped<IDestinationService, DestinationManager>();
            builder.Services.AddScoped<IHotelService, HotelManager>();
            builder.Services.AddScoped<IFlightInformationService, FlightInformationManager>();
            builder.Services.AddScoped<IReservationDetailService, ReservationDetailManager>();
            builder.Services.AddScoped<IReservationService,ReservationManager>();
            builder.Services.AddFluentValidationAutoValidation();
           builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.Configure<JWTExceptURL>(builder.Configuration.GetSection(nameof(JWTExceptURL)));
            var app = builder.Build();
            app.UseExceptionMiddleware();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseApiAuthorizationMiddleware();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}