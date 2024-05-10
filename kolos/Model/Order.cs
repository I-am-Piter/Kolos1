using System.ComponentModel.DataAnnotations;

namespace GakkoHorizontalSlice.Model;

public class Order
{
    [Required]
    public int idOrder { get; set; }
    [Required]
    [MaxLength(200)]
    public String name { get; set; }
    [MaxLength(1000)]
    public String description { get; set; }
    [Required]
    public DateTime creationDate { get; set; }
    public int idClient { get; set; }
    public IEnumerable<Product> Products { get; set; }
    
}