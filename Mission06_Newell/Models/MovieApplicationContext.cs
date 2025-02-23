using Microsoft.EntityFrameworkCore;

namespace Mission06_Newell.Models;

public class MovieApplicationContext : DbContext
{
    public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options) : base(options)
    {
    }
    
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Category> Categories { get; set; }
}