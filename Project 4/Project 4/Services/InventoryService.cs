namespace Project_4.Services
{
    public class InventoryService
    {
        private List<Inventory> inventories = new List<Inventory>();

        public InventoryService()
        {
            // Temporary sample data used to test inventory loading and transfer logic
            inventories.Add(new Inventory(1, 1, 1, 50, 10, DateTime.Now.AddDays(7)));
            inventories.Add(new Inventory(2, 1, 2, 20, 10, DateTime.Now.AddDays(7)));
            inventories.Add(new Inventory(3, 2, 1, 15, 5, DateTime.Now.AddDays(4)));
        }

        public List<Inventory> GetInventory()
        {
            return inventories;
        }
    }
}
