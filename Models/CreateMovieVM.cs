using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MovieLib.Models;

public class CreateMovieVM
{
    [Required, StringLength(250)]
    public string Title { get; set; } = string.Empty;

    public int Year { get; set; }

    [Range(1, 10)]
    public double Rate { get; set; }

    [Required, StringLength(2500)]
    public string StoryLine { get; set; } = string.Empty;

    [Display(Name = "Genre")]
    public byte GenreId { get; set; }

    public SelectList Genres { get; set; } = new SelectList(Enumerable.Empty<SelectListItem>());
}
