
using GakkoHorizontalSlice.Model;
using GakkoHorizontalSlice.Repositories;
using GakkoHorizontalSlice.Services;

public class OrderService:IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    public Order GetOrder(int idOrder)
    {
        var order = _orderRepository.GetOrder(idOrder);
        order.Products = _productRepository.getProductsFromOrder(idOrder);

        return order;
    }

    public int DeleteOrder(int idOrder)
    {
        var affected = _orderRepository.DeleteOrder(idOrder);
        return affected;
    }
}