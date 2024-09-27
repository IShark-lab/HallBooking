
using HallBooking.BLL.Interfaces;
using HallBooking.BLL.Mapper;
using HallBooking.BLL.Services;
using HallBooking.DLA.EF;
using HallBooking.DLA.Entities;
using HallBooking.DLA.Interfaces;
using HallBooking.DLA.Repository;
using HallBooking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace HallBooking.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();


            var connectionString = builder.Configuration.GetConnectionString("HallBooking");

            builder.Services.AddDbContext<HallBookingContext>(options => options.UseSqlServer(connectionString));


            DependencyConfiguration(builder.Services);


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
        }

        private static void DependencyConfiguration(IServiceCollection services)
        {
            services.AddScoped<IMapperServices, ServiceMapper>();
            services.AddScoped<IConferenceRoomRepository, ConferenceRoomRepository>();
            services.AddScoped<IConferenceRoomService, ConferenceRoomService>();
            services.AddScoped<IMapper<ConferenceRoomDto, ConferenceRoom>, ConfereceRoomMapper>();

            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IMapper<BookingDto, Booking>, BookingMapper>();

            services.AddScoped<IServiceRepository, ServicesRepository>();
            services.AddScoped<IServicesService, ServicesService>();

            services.AddScoped<IMapper<ServiceDto, Service>, ServiceMapper>();

            services.AddScoped<IPriceStrategy, PeakHoursStrategy>();
            services.AddScoped<IPriceStrategy, MorningHoursStrategy>();
            services.AddScoped<IPriceStrategy, EveningHoursStrategy>();
            services.AddScoped<IPriceStrategy, StandardHoursStrategy>();

            services.AddScoped<RentalPriceCalculator>();
        }
    }
}
