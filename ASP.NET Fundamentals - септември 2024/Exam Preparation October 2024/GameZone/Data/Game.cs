using static GameZone.Constants.ModelConstants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Data
{
    public class Game
    {
        [Key]
        [Comment("Unique Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(GameTitleMaxLength)]
        [Comment("Game Title")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(GameDescriptionMaxLength)]
        [Comment("Game Description")]
        public string Description { get; set; } = null!;

        [Comment("The Url of The image")]
        public string? ImageUrl { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Publisher))]
        public string PublisherId { get; set; } = null!;

        [Required]
        public IdentityUser Publisher { get; set; } = null!;

        [Required]
        public DateTime ReleasedOn { get; set; }

        [Required]
        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }

        [Required]
        public Genre Genre { get; set; } = null!;

        public ICollection<GamerGame> GamersGames { get; set; } = new List<GamerGame>();

        [Comment("Shows wether game is deleted or not")]
        public bool IsDeleted { get; set; }
    }
}
/*
 	Id – a unique integer, Primary Key
	Title – a string with min length 2 and max length 50 (required)
	Description – string with min length 10 and max length 500 (required)
	ImageUrl – nullable string
	PublisherId – string (required)
	Publisher – IdentityUser (required)
	ReleasedOn– DateTime with format " yyyy-MM-dd" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one)
	GenreId – integer, foreign key (required)
	Genre – Genre (required)
	GamersGames – a collection of type GamerGame

 */
