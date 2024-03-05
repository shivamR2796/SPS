using Microsoft.EntityFrameworkCore;
using SPS.Datafile;

namespace KPS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddAuthentication(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(a => a.LoginPath = "/Home/Login");

            builder.Services.AddSession();

            var res = builder.Services.BuildServiceProvider();
            var s = res.GetRequiredService<IConfiguration>();
            builder.Services.AddDbContext<Data_Base>(z => z.UseSqlServer(s.GetConnectionString("Hello")));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Admin_Login}/{id?}");

            app.Run();
        }
    }
}