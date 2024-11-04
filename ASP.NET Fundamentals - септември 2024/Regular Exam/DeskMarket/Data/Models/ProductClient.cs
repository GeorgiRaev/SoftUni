using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using static DeskMarket.Common.ValidationConstants;


namespace DeskMarket.Data.Models
{
    public class ProductClient
    {
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public  Product Product { get; set; } = null!;

        public string ClientId { get; set; }= string.Empty;

        [ForeignKey(nameof(ClientId))]
        public virtual IdentityUser Client { get; set; } = null!;


    }
}
