using Microsoft.EntityFrameworkCore;

return;

internal enum Rating
{
    Bad,

    Good
}

internal class Movie
{
    public Movie(string title, Rating rating) => (Title, Rating) = (title, rating);

    public int Id { get; set; }

    public string Title { get; set; }

    public Rating Rating { get; set; }
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
        modelBuilder.Entity<Movie>().Property(movie => movie.Rating).HasConversion<string>();

        modelBuilder.Entity<Movie>().HasData(
            new Movie("Some Cartoon", Rating.Good) { Id = 1 },
            new Movie("A Documentary", Rating.Bad) { Id = 2 });
    }
}