using BusinessLayer;
using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using HtmlAgilityPack;
using System.Xml.XPath;
using DataLayer.Entityes;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {            
            var builder = WebApplication.CreateBuilder(args);
            var connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<EFDBContext>(optionsAction =>
                optionsAction.UseSqlServer(connection, d => d.MigrationsAssembly("DataLayer")));
			builder.Services.AddTransient<IFacultyCRUD, EFFacultyCRUD>();
			builder.Services.AddTransient<IDepartmentCRUD, EFDepartmentCRUD>();
			builder.Services.AddTransient<ISubjectCRUD, EFSubjectCRUD>();
			builder.Services.AddTransient<IQuestionCRUD, EFQuestionCRUD>();
            builder.Services.AddTransient<IAnswerCRUD, EFAnswerCRUD>();
            builder.Services.AddScoped<DataManager>();
            // Add services to the container.
            builder.Services.AddControllersWithViews();

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}