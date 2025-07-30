using System.ComponentModel.DataAnnotations;

namespace MovieLib.Enities;

public class Movie
{
    public int Id { get; set; }
    [Required, MaxLength(250)]
    public string Title { get; set; } = string.Empty;
    public int Year { get; set; }
    public double Rate { get; set; }
    [Required, MaxLength(2500)]
    public string StoryLine { get; set; } = string.Empty;
    public Genre? Genre { get; set; }
    public byte GenreId { get; set; }
}
