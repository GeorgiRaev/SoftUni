using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ProductClient
{
    [Key, Column(Order = 0)]
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public Product Product { get; set; }

    [Key, Column(Order = 1)]
    public int ClientId { get; set; }
    [ForeignKey("ClientId")]
    public Client Client { get; set; }
}

