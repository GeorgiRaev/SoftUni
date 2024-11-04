using System;
using System.ComponentModel.DataAnnotations;

public class Schedule2024
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Името на състезанието е задължително.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Името на състезанието трябва да е между 3 и 100 символа.")]
    public string RaceName { get; set; }

    [Required(ErrorMessage = "Датата на състезанието е задължителна.")]
    [DataType(DataType.Date)]
    public DateTime RaceDate { get; set; }

    [Required(ErrorMessage = "Името на пистата е задължително.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Името на пистата трябва да е между 3 и 100 символа.")]
    public string Circuit { get; set; }

    [Required(ErrorMessage = "Мястото е задължително.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Мястото трябва да е между 3 и 100 символа.")]
    public string Location { get; set; }

    // Можеш да добавиш и допълнителна информация като кръг от шампионата или тип състезание (спринт, основно)
    public string AdditionalInfo { get; set; }
}
