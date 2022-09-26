using System.Collections.Generic;
using System.Linq;
using UF.Entity;
using UF.Service;

namespace UF.Web.Test.Mock
{
    public class InventoryServiceTest1Mock : IInventoryService
    {
        private List<Inventory> ds = new List<Inventory>()
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
        };
        public IEnumerable<Inventory> SearchInventory(string partNumber)
        {
            return ds.AsEnumerable();
        }
    }
}
