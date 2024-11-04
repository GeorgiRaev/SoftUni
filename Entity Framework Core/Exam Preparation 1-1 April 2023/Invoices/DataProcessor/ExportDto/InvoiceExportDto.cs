using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto
{
    [XmlType("Invoice")]
    public class InvoiceExportDto
    {
        [XmlElement("InvoiceNumber")]
        public string Number { get; set; }

        [XmlElement("InvoiceAmount")]
        public decimal Amount { get; set; }

        [XmlElement("Currency")]
        public string Currency { get; set; }

        [XmlElement("DueDate")]
        public string DueDate { get; set; }
    }
}
