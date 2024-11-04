using System.ComponentModel.DataAnnotations;

namespace Boardgames.Models
{
    public class Creator
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(7, MinimumLength = 2)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(7, MinimumLength = 2)]
        public string LastName { get; set; } = string.Empty;

        public ICollection<Boardgame> Boardgames { get; set; } = new List<Boardgame>();
    }
}
