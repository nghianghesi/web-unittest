using UF.Entity;

namespace UF.Service {
    public interface IInventoryService {
        public IEnumerable<Inventory> SearchInventory(String partNumber);
    }
}