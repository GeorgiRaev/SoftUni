namespace Invoices.DataProcessor.ImportDto
{
    using Invoices.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Client")]
    public class ClientImportDto
    {
        [Required]
        [XmlElement("Name")]
        [MaxLength(25)]
        [MinLength(10)]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("NumberVat")]
        [MaxLength(15)]
        [MinLength(10)]
        public string NumberVat { get; set; } = null!;

        [XmlArray("Addresses")]
        public AddressImportDto[] Addresses { get; set; } = null!;
    }

}
