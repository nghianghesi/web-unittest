
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using UF.Web.Controllers;
using UF.Service;
using UF.Web.Test.Mock;

namespace UF.Web.Test;


[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Test1()
    {
        var builder = WebApplication.CreateBuilder(    
            new WebApplicationOptions() {
                WebRootPath = "C:\\Users\\nghia\\Source\\Repos\\web-unittest\\UF.Web\\wwwroot",
                ContentRootPath = "C:\\Users\\nghia\\Source\\Repos\\web-unittest\\UF.Web\\wwwroot"
            }
        );

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddMvc()
                .AddApplicationPart(typeof(DemoController).Assembly)
                .AddControllersAsServices();
        builder.Services.AddSingleton<IInventoryService>(new InventoryServiceTest1Mock());

        var app = builder.Build();

        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();


        System.Threading.Thread.Sleep(600000);
    }
}