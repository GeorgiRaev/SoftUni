using System.ComponentModel.DataAnnotations;
using static GameZone.Constants.ModelConstants;


namespace GameZone.Data
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GameNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
