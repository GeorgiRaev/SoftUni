using DeskMarket.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using static DeskMarket.Common.ValidationConstants;

namespace DeskMarket.Models
{
    public class ProductAddViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.DeskMarketTitleMaxLength, MinimumLength = ValidationConstants.DeskMarketTitleMinLength)]
        public string ProductName { get; set; } = null!;

        [Required]
        [StringLength(ValidationConstants.DeskMarketDescriptionMaxLength, MinimumLength = ValidationConstants.DeskMarketDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Range((double)DeskMarketProductMinPrice, (double)DeskMarketProductMaxPrice)]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = null!;

        public int CategoryId { get; set; }

        [Required]
        [RegexStringValidator(@"^\d{4}-\d{2}-\d{2}$")]
        public string AddedOn { get; set; } = string.Empty;

        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
