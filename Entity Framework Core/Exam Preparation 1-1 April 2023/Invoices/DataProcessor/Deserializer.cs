namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";

        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ClientImportDto[]), new XmlRootAttribute("Clients"));

            using StringReader stringReader = new StringReader(xmlString);

            ClientImportDto[] clientsDto = (ClientImportDto[])xmlSerializer.Deserialize(stringReader);

            List<Client> clients = new List<Client>();

            foreach (ClientImportDto clientDto in clientsDto)
            {
                if (!IsValid(clientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client c = new Client()
                {
                    Name = clientDto.Name,
                    NumberVat = clientDto.NumberVat
                };

                foreach (AddressImportDto addressDto in clientDto.Addresses)
                {
                    if (!IsValid(addressDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Address a = new Address()
                    {
                        StreetName = addressDto.StreetName,
                        StreetNumber = addressDto.StreetNumber,
                        PostCode = addressDto.PostCode,
                        City = addressDto.City,
                        Country = addressDto.Country
                    };

                    c.Addresses.Add(a);
                }
                clients.Add(c);
                sb.AppendLine(String.Format(SuccessfullyImportedClients, c.Name));
            }
            context.Clients.AddRange(clients);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }



        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            InvoiceImportDto[] invoicesDtos = JsonConvert.DeserializeObject<InvoiceImportDto[]>(jsonString);

            List<Invoice> invoices = new List<Invoice>();

            foreach (InvoiceImportDto invoiceDto in invoicesDtos)
            {
                if (!IsValid(invoiceDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime issueDate = invoiceDto.IssueDate;
                DateTime dueDate = invoiceDto.DueDate;

                if (issueDate > dueDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!Enum.IsDefined(typeof(CurrencyType), invoiceDto.CurrencyType))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Invoice invoice = new Invoice()
                {
                    Number = invoiceDto.Number,
                    IssueDate = issueDate,
                    DueDate = dueDate,
                    Amount = invoiceDto.Amount,
                    CurrencyType = (CurrencyType)invoiceDto.CurrencyType,
                    ClientId = invoiceDto.ClientId
                };

                invoices.Add(invoice);
                sb.AppendLine(String.Format(SuccessfullyImportedInvoices, invoice.Number));
            }

            context.Invoices.AddRange(invoices);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ProductImportDto[] productsDtos = JsonConvert.DeserializeObject<ProductImportDto[]>(jsonString);

            if (productsDtos == null)
            {
                return "Invalid data!";
            }

            List<Product> products = new List<Product>();

            foreach (ProductImportDto productDto in productsDtos)
            {
                if (!IsValid(productDto))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                if (!Enum.IsDefined(typeof(CategoryType), productDto.CategoryType))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                Product product = new Product()
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    CategoryType = (CategoryType)productDto.CategoryType
                };

                HashSet<int> uniqueClientIds = new HashSet<int>(productDto.Clients);
                List<Client> validClients = new List<Client>();

                foreach (int clientId in uniqueClientIds)
                {
                    Client client = context.Clients.Find(clientId);
                    if (client == null)
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }
                    validClients.Add(client);
                }

                if (validClients.Count == 0)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                product.ProductsClients = validClients.Select(vc => new ProductClient { Product = product, Client = vc }).ToList();
                products.Add(product);
                sb.AppendLine($"Successfully imported product - {product.Name} with {validClients.Count} clients.");
            }

            context.Products.AddRange(products);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }




        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
