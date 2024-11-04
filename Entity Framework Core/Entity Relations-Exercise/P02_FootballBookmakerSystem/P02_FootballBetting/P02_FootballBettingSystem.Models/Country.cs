using P02_FootballBetting.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBettingSystem.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        [MaxLength(ValidationConstants.CountryNameMaxLength)]
        public string Name { get; set; }
    }
}
