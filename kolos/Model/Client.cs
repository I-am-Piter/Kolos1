using System.ComponentModel.DataAnnotations;

namespace GakkoHorizontalSlice.Model;

public class Client
{
    [Required]
    public int idClient { get; set; }
    [MaxLength(100)]
    public String firstName { get; set; }
    [MaxLength(100)]
    public String lastName { get; set; }
    [MaxLength(100)]
    [EmailAddress]
    public String email { get; set; }
}