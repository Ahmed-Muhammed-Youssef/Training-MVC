using Microsoft.EntityFrameworkCore;
using MovieLib.Enities;

namespace MovieLib.Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Movie> Movies {  get; set; }
    public DbSet<Genre> Genres { get; set; }
}
