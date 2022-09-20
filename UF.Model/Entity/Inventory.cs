namespace UF.Entity {
    public class PartInventory {
        public Part Part {get; set;} = default!;
        public int Amount {get; set;} = default!;
    }

    public class Inventory {
        public Supplier Supplier { get; set; } = default!;

        public List<PartInventory> Inventories { get; set; } = default!;
    }
}