using System;
using System.ComponentModel.DataAnnotations;

public class RaceResult
{

    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Състезанието е задължително.")]
    public string RaceName { get; set; }

    [Required(ErrorMessage = "Позицията на пилота е задължителна.")]
    [Range(1, 20, ErrorMessage = "Позицията трябва да е между 1 и 20.")]
    public int Position { get; set; }

    [Required(ErrorMessage = "Датата на състезанието е задължителна.")]
    [DataType(DataType.Date)]
    public DateTime RaceDate { get; set; }

    [Required(ErrorMessage = "Пилотът е задължителен.")]
    public int DriverId { get; set; }
    public Driver Driver { get; set; }
}
