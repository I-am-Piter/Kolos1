using GakkoHorizontalSlice.Repositories;

namespace GakkoHorizontalSlice.Services;

public class ClientService:IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IOrderRepository _orderRepository;
    public int DeleteClient(int idClient)
    {
        var orders = _orderRepository.GetOrdersFromClient(idClient);
        foreach (var order in orders)
        {
            _orderRepository.DeleteOrder(order.idOrder);
        }
        return _clientRepository.DeleteClient(idClient);
    }
}