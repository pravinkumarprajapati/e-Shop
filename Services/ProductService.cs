using OrderServices.Model;

namespace OrderServices.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Inventory> _inventory;

        public ProductService()
        {
            // Initialize inventory from a data source or constructor injection.
            _inventory = new List<Inventory>
        {
            new Inventory { ProductId = 1, Quantity = 10 },
            // Other products and their initial quantities
        };
        }

        public bool CheckAvailability(int productId)
        {
            var inventoryItem = _inventory.FirstOrDefault(i => i.ProductId == productId);
            return inventoryItem?.Quantity > 0;
        }
    }
}
