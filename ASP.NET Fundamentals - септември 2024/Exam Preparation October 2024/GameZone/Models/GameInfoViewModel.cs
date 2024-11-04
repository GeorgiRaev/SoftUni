
namespace GameZone.Models
{
    public class GameInfoViewModel
    {
        internal bool IsPublisher;

        public int Id { get; set; }
        public required string Title { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public required string Genre { get; set; } = null!;

        public required string ReleasedOn { get; set; }

        public required string Publisher { get; set; } = null!;
    }
}