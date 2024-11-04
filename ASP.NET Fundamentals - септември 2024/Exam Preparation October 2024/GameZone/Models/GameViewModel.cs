﻿using GameZone.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using static GameZone.Constants.ModelConstants;
namespace GameZone.Models
{
    public class GameViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(GameTitleMaxLength, MinimumLength = GameTitleMinLength)]
        public string Title { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }

        [Required]
        [StringLength(GameDescriptionMaxLength, MinimumLength = GameDescriptionMinLength)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string ReleasedOn { get; set; }= DateTime.Today.ToString(GameReleasedOnFormat);
        [Required]
        public int GenreId { get; set; }
        public List<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();
    }
}
//title,ImageUrl,description,ReleasedOn,genreId,genre