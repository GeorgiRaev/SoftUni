using System;
using System.ComponentModel.DataAnnotations;

public class Archive1950_2023
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Годината е задължителна.")]
    [Range(1950, 2023, ErrorMessage = "Годината трябва да е между 1950 и 2023.")]
    public int Year { get; set; }

    [Required(ErrorMessage = "Името на шампиона е задължително.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Името на шампиона трябва да е между 3 и 50 символа.")]
    public string ChampionName { get; set; }

    [Required(ErrorMessage = "Името на отбора е задължително.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Името на отбора трябва да е между 3 и 50 символа.")]
    public string ChampionTeam { get; set; }

    [Required(ErrorMessage = "Брой състезания е задължителен.")]
    [Range(1, 30, ErrorMessage = "Броят състезания трябва да е между 1 и 30.")]
    public int NumberOfRaces { get; set; }

    // Допълнителни данни, като най-бързата обиколка, шампион по конструктори и др.
    public string AdditionalInfo { get; set; }
}
