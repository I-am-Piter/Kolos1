using System.Data.SqlClient;
using GakkoHorizontalSlice.Model;

namespace GakkoHorizontalSlice.Repositories;

public class OrderRepository : IOrderRepository
{
    private IConfiguration _configuration;

    public OrderRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public Order GetOrder(int idOrder)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT Name,Description,CreationDate,IdClient FROM Order WHERE IdOrder=@idOrder";
        cmd.Parameters.AddWithValue("@idOrder", idOrder);
        
        var dr = cmd.ExecuteReader();
        
        if (!dr.Read()) return null;
        
        var order = new Order
        {
            idOrder = idOrder,
            name = dr["Name"].ToString(),
            description = dr["Description"].ToString(),
            creationDate = (DateTime)dr["CreationDate"],
            idClient = (int)dr["IdClient"]
        };
        
        return order;
    }

    public int DeleteOrder(int idOrder)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Order> GetOrdersFromClient(int idClient)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdOrder,Name,Description,CreationDate FROM Order WHERE IdClient=@idClient";
        cmd.Parameters.AddWithValue("@idClient", idClient);
        
        var dr = cmd.ExecuteReader();
        if(!dr.Read()) return null;
        var orders = new List<Order>();
        
        while (dr.Read())
        {
            var order = new Order
            {
                idOrder = (int)dr["IdOrder"],
                name = dr["Name"].ToString(),
                description = dr["Description"].ToString(),
                creationDate = (DateTime)dr["CreationDate"],
                idClient = idClient
            };
            
            orders.Add(order);
        }

        return orders;

    }
}