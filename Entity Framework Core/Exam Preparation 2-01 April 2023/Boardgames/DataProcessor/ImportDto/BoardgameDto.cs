using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Boardgame")]
    public class BoardgameDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Rating")]
        public double Rating { get; set; }

        [XmlElement("YearPublished")]
        public int YearPublished { get; set; }

        [XmlElement("CategoryType")]
        public int CategoryType { get; set; }

        [XmlElement("Mechanics")]
        public string Mechanics { get; set; }
    }
}
