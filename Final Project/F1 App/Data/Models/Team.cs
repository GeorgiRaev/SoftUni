using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Team
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Името на отбора е задължително.")]
    [StringLength(50, ErrorMessage = "Името не може да надвишава 50 символа.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Главният щаб на отбора е задължителен.")]
    [StringLength(100, ErrorMessage = "Главният щаб не може да надвишава 100 символа.")]
    public string Headquarters { get; set; }

    // Списък с пилоти в отбора
    public List<Driver> Drivers { get; set; }
}
