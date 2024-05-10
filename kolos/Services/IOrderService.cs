using GakkoHorizontalSlice.Model;

namespace GakkoHorizontalSlice.Services;

public interface IOrderService
{
    Order GetOrder(int idOrder);
    int DeleteOrder(int idOrder);
}