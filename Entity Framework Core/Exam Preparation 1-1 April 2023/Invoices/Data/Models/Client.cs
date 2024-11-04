using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Invoices.Data.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(15)]
        public string NumberVat { get; set; } = null!;

        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<ProductClient> ProductsClients { get; set; } = new List<ProductClient>();
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
