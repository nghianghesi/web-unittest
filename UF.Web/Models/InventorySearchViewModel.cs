using UF.Entity;

namespace UF.Web.ViewModel{
    public class InventorySearchViewModel {
        public IEnumerable<Inventory> Inventories { get; set; } = new List<Inventory>().AsEnumerable();
    }
}