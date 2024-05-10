using System.Data.SqlClient;
using GakkoHorizontalSlice.Model;

namespace GakkoHorizontalSlice.Repositories;

public class ProductRepository: IProductRepository
{
    private IConfiguration _configuration;
    
    public ProductRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public IEnumerable<Product> getProductsFromOrder(int idOrder)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT Name,Price from Product inner join Order_Product on Product.IdProduct = Order_Product.IdProduct where Order_Product.IdOrder = @idOrder";
        cmd.Parameters.AddWithValue("@idOrder", idOrder);
        
        var dr = cmd.ExecuteReader();
        var products = new List<Product>();
        while (dr.Read())
        {
            var product = new Product
            {
                Name = dr["Name"].ToString(),
                price = (float)dr["Price"]
            };
            
            products.Add(product);
        }
        
        return products;
    }
}