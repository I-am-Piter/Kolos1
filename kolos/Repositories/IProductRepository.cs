using GakkoHorizontalSlice.Model;

namespace GakkoHorizontalSlice.Repositories;

public interface IProductRepository
{
    IEnumerable<Product> getProductsFromOrder(int idOrder);
}