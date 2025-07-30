﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieLib.Enities;

public class Genre
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public byte Id { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;
}
