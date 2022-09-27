
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using UF.Web.Controllers;
using UF.Service;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Moq;
using System.Reflection;
using System.Collections.Generic;
using UF.Entity;

namespace UF.Web.Test;


[TestClass]
public class UnitTest1
{
    private Mock<IInventoryService> _inventoryService;
    private WebApplication app;
    private WebDriver driver;
    [TestInitialize]
    public void setup()
    {
        var builder = WebApplication.CreateBuilder(
            new WebApplicationOptions()
            {
                WebRootPath = "C:\\Users\\nghia\\Source\\Repos\\web-unittest\\UF.Web\\wwwroot",
                ContentRootPath = "C:\\Users\\nghia\\Source\\Repos\\web-unittest\\UF.Web\\wwwroot"
            }
        );

        this._inventoryService = new Mock<IInventoryService>();
        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddMvc()
                .AddApplicationPart(typeof(DemoController).Assembly)
                .AddControllersAsServices();
        builder.Services.AddSingleton(this._inventoryService.Object);

        this.app = builder.Build();

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

        app.RunAsync();
        this.driver = new ChromeDriver("."); // use PhantomJs if run in CICD
    }

    [TestMethod]
    public async Task Test1()
    {
        DemoController ctrl = app.Services.GetService<DemoController>();
        FieldInfo f = typeof(DemoController).GetField("inventoryService", BindingFlags.NonPublic | BindingFlags.Instance);
        this._inventoryService.Setup(inv => inv.SearchInventory(It.IsAny<string>())).Returns(new List<Inventory>()
        {
            new Inventory()
            {
                Supplier = new Supplier() {Name="Test 1"},
                Inventories = new List<PartInventory>()
                {
                    new PartInventory() {
                        Part = new Part() { Number = "Test oem 1"},
                        Amount = 3
                    }
                }
            }
        });
        f.SetValue(ctrl, this._inventoryService.Object);

        driver.Navigate().GoToUrl("https://localhost:5001/demo/index/abcd");
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        var element = wait.Until(driver => driver.FindElement(By.Id("demo-content")));
        Assert.IsNotNull(element);
        Assert.AreEqual(1, element.FindElements(By.ClassName("supplier-name")).Count);



        driver.Dispose();
        await this.app.StopAsync(); // can't use TestCleanup as async doesn't supported.
    }
}