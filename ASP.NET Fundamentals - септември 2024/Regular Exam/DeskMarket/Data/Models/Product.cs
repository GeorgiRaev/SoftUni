﻿using DeskMarket.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DeskMarket.Common.ValidationConstants;

namespace DeskMarket.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DeskMarketTitleMaxLength)]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        [MaxLength(DeskMarketDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range((double)DeskMarketProductMinPrice, (double)DeskMarketProductMaxPrice)]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public string SellerId { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(SellerId))]
        public IdentityUser Seller { get; set; } = null!;

        [Required]
        public DateTime AddedOn { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public virtual ICollection<ProductClient> ProductsClients { get; set; } = new List<ProductClient>();










    }
}
