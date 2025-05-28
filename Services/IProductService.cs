namespace OrderServices.Services
{
    public interface IProductService
    {
        bool CheckAvailability(int productId);
    }
}
