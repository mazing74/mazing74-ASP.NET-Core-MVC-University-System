using BLL.Interfaces;
using BLL.Repository;
using DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace ITI_MVCProj;

public class Program
{
    public static void Main(string[] args)
    {



        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<MyAppDbConext>(Options =>
        {
            Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        }
        );
        builder.Services.AddIdentity<DAL.Models.ApplicationUser, Microsoft.AspNetCore.Identity.IdentityRole>(op=>
        {
            op.Password.RequiredLength = 4;
            op.Password.RequireNonAlphanumeric = false;
            op.Password.RequireUppercase = true;
            op.Password.RequireLowercase = true;
        }
        )
            .AddEntityFrameworkStores<MyAppDbConext>();
        builder.Services.AddScoped<IstudentRepository, StudentRepository>();
        builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();
        app.Run();
    }
}