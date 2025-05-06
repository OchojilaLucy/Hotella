using Hotella.Controllers;
using Hotella.ViewModels;
using Hotella.Services.Services;
using Hotella.Services.Interfaces;
using Hotella.DataBase;

namespace Hotella
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IHotelService, HotelService>();
            builder.Services.AddScoped<HotelsViewModel>();
            builder.Services.AddScoped<HotelController>();
            builder.Services.AddScoped<DbHelper>();
            builder.Services.AddScoped<IBookingService, BookingService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Hotel}/{action=HomePageDisplay}/{id?}");

            app.Run();
        }
    }
}
