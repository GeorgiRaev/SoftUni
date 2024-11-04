namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using Boardgames.Data;
    using Boardgames.DataProcessor.ImportDto;
    using Boardgames.Models;
    using Boardgames.Data.Models.Enums;
    using System.Text.Json;


    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(List<CreatorDto>), new XmlRootAttribute("Creators"));
            List<CreatorDto> creatorDtos;

            using (var reader = new StringReader(xmlString))
            {
                creatorDtos = (List<CreatorDto>)serializer.Deserialize(reader);
            }

            var creators = new List<Creator>();

            foreach (var creatorDto in creatorDtos)
            {
                if (string.IsNullOrWhiteSpace(creatorDto.FirstName) || creatorDto.FirstName.Length < 2 || creatorDto.FirstName.Length > 7 ||
                    string.IsNullOrWhiteSpace(creatorDto.LastName) || creatorDto.LastName.Length < 2 || creatorDto.LastName.Length > 7)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var creator = new Creator
                {
                    FirstName = creatorDto.FirstName,
                    LastName = creatorDto.LastName,
                    Boardgames = new List<Boardgame>()
                };

                foreach (var boardgameDto in creatorDto.Boardgames)
                {
                    if (string.IsNullOrWhiteSpace(boardgameDto.Name) || boardgameDto.Name.Length < 10 || boardgameDto.Name.Length > 20 ||
                        boardgameDto.Rating < 1 || boardgameDto.Rating > 10.00 ||
                        boardgameDto.YearPublished < 2018 || boardgameDto.YearPublished > 2023)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var boardgame = new Boardgame
                    {
                        Name = boardgameDto.Name,
                        Rating = boardgameDto.Rating,
                        YearPublished = boardgameDto.YearPublished,
                        CategoryType = (CategoryType)boardgameDto.CategoryType,
                        Mechanics = boardgameDto.Mechanics,
                        Creator = creator
                    };

                    creator.Boardgames.Add(boardgame);
                }

                creators.Add(creator);
                sb.AppendLine(string.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName, creator.Boardgames.Count));
            }

            context.Creators.AddRange(creators);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var sellerDtos = JsonSerializer.Deserialize<List<SellerDto>>(jsonString);
            var sellers = new List<Seller>();

            foreach (var sellerDto in sellerDtos)
            {
                if (!IsValid(sellerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var seller = new Seller
                {
                    Name = sellerDto.Name,
                    Address = sellerDto.Address,
                    Country = sellerDto.Country,
                    Website = sellerDto.Website,
                    BoardgamesSellers = new List<BoardgameSeller>()
                };

                var uniqueBoardgameIds = sellerDto.BoardgameIds.Distinct().ToList();

                foreach (var boardgameId in uniqueBoardgameIds)
                {
                    var boardgame = context.Boardgames.Find(boardgameId);
                    if (boardgame == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var boardgameSeller = new BoardgameSeller
                    {
                        BoardgameId = boardgameId,
                        Seller = seller
                    };

                    seller.BoardgamesSellers.Add(boardgameSeller);
                }

                sellers.Add(seller);
                sb.AppendLine(string.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));
            }

            context.Sellers.AddRange(sellers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
