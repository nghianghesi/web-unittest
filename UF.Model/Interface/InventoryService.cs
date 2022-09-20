using UF.Entity;

namespace UF.Service {
    public interface InventoryService {
        public IEnumerable<Inventory> SearchInventory(String partNumber);
    }
}