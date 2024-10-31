using Infrastructure;
using Infrastructure.RepositoryClasses;
using Infrastructure.RepositoryInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Service.ServiceClasses;
using Service.ServiceInterfaces;
using System.Security.Claims;

namespace App.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("OnlineTicketAndReservationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'OnlineTicketAndReservationDbContextConnection' not found.");

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddMvc();
            builder.Services.AddControllers();
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<DbContext, OnlineTicketAndReservationDbContext>();

            builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<OnlineTicketAndReservationDbContext>().AddDefaultTokenProviders();
            builder.Services.AddScoped<ClaimsPrincipal>();

            builder.Services.ConfigureApplicationCookie(option =>
            {
                option.LoginPath = "/Identity/Account/Login";
            });

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IRoleService, RoleService>();


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

            app.UseAuthentication();
            app.UseAuthorization();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoint.MapRazorPages();
            });

            app.Run();
        }
    }
}
