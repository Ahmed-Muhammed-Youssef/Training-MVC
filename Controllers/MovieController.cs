using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieLib.Database;
using MovieLib.Enities;
using MovieLib.Models;
using System.Threading.Tasks;

namespace MovieLib.Controllers;

public class MovieController : Controller
{
    private readonly ApplicationDbContext dbContext;

    public MovieController(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<ActionResult> Index()
    {
        var movies = await dbContext.Movies.ToListAsync();
        return View(movies);
    }

    public async Task<ActionResult> Create()
    {
        var genreList = await dbContext.Genres.OrderBy(m => m.Name).ToListAsync();
        var genres = new SelectList(genreList, "Id", "Name");
        CreateMovieVM viewModel = new()
        {
            Genres = genres
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateMovieVM viewModel)
    {
        if (!ModelState.IsValid)
        {
            var genreList = await dbContext.Genres.OrderBy(m => m.Name).ToListAsync();
            var genres = new SelectList(genreList, "Id", "Name");
            viewModel.Genres = genres;

            return View(nameof(Create), viewModel);
        }
        
        var movies = new Movie
        {
            Title = viewModel.Title,
            GenreId = viewModel.GenreId,
            Year = viewModel.Year,
            Rate = viewModel.Rate,
            StoryLine = viewModel.StoryLine
        };

        dbContext.Movies.Add(movies);
        await dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var movie = await dbContext.Movies.Include(m => m.Genre).FirstOrDefaultAsync(m => m.Id == id);

        if (movie == null)
            return NotFound();

        return View(movie);
    }

}
