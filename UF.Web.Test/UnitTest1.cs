
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace UF.Web.Test;


[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Test1()
    {
        var builder = WebApplication.CreateBuilder(    
            new WebApplicationOptions() {
                WebRootPath = "../UF.Web"
            }
        );

        // Add services to the container.
        builder.Services.AddControllersWithViews();

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