namespace Invoices.DataProcessor
{
    using Invoices.Data;
    using Invoices.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            var clients = context.Clients
                 .Where(c => c.Invoices.Any(i => i.IssueDate > date))
                 .Select(c => new ClientExportDto
                 {
                     Name = c.Name,
                     VatNumber = c.NumberVat,
                     InvoicesCount = c.Invoices.Count(i => i.IssueDate > date),
                     Invoices = c.Invoices
                         .Where(i => i.IssueDate > date)
                         .OrderBy(i => i.IssueDate)
                         .ThenByDescending(i => i.DueDate)
                         .Select(i => new InvoiceExportDto
                         {
                             Number = i.Number.ToString(),
                             Amount = i.Amount,
                             Currency = i.CurrencyType.ToString(),
                             DueDate = i.DueDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture) // Форматиране на датата
                         })
                         .ToList()
                 })
                 .ToArray()
                 .OrderByDescending(c => c.InvoicesCount)
                 .ThenBy(c => c.Name)
                 .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ClientExportDto[]), new XmlRootAttribute("Clients"));
            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, clients, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {
            var products = context.Products
                .Where(p => p.ProductsClients.Any(pc => pc.Client.Name.Length >= nameLength))
                .Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Category = p.CategoryType.ToString(),
                    Clients = p.ProductsClients
                        .Where(pc => pc.Client.Name.Length >= nameLength)
                        .Select(pc => new
                        {
                            Name = pc.Client.Name,
                            NumberVat = pc.Client.NumberVat
                        })
                        .OrderBy(c => c.Name)
                        .ToArray()
                })
                .ToArray()
                .OrderByDescending(p => p.Clients.Length)
                .ThenBy(p => p.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);

        }
    }
}