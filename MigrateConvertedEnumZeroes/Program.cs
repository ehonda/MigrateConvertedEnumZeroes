using Microsoft.EntityFrameworkCore;

return;

internal class Movie
{
    public Movie(string title) => Title = title;
    
    public int Id { get; set; }

    public string Title { get; set; }
}

internal class MoviesDbContext : DbContext
{
    public DbSet<Movie> Movies => Set<Movie>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=movies.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().HasData(
            new Movie("Some Cartoon") { Id = 1 },
            new Movie("A Documentary") { Id = 2 });
    }
}