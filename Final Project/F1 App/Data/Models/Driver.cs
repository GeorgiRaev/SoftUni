using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Driver
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Името на пилота е задължително.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Името трябва да е между 3 и 50 символа.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Датата на раждане е задължителна.")]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "Националността е задължителна.")]
    [StringLength(30, ErrorMessage = "Националността не може да надвишава 30 символа.")]
    public string Nationality { get; set; }

    [Required(ErrorMessage = "Отборът е задължителен.")]
    public int TeamId { get; set; }
    public Team Team { get; set; }

    public List<RaceResult> RaceResults { get; set; }
}
