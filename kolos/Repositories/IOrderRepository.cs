
using GakkoHorizontalSlice.Model;

namespace GakkoHorizontalSlice.Repositories;

public interface IOrderRepository
{
    Order GetOrder(int idOrder);
    int DeleteOrder(int idOrder);
    IEnumerable<Order> GetOrdersFromClient(int idClient);
}