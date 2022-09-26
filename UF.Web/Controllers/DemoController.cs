using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UF.Web.Models;
using UF.Web.ViewModel;
namespace UF.Web.Controllers;

public class DemoController : Controller {
    private Service.IInventoryService inventoryService;

    public DemoController(Service.IInventoryService inventoryService) {
        this.inventoryService = inventoryService;
    }

    public IActionResult index(string partNumber)
    {
        return View(new InventorySearchViewModel { Inventories = this.inventoryService.SearchInventory(partNumber) });
    }
}