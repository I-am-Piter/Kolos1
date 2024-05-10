using System.ComponentModel.DataAnnotations;

namespace GakkoHorizontalSlice.Model;

public class Product
{
    public int IdProduct { get; set; }
    [MaxLength(200)]
    public String Name { get; set; }
    public float price { get; set; }
}