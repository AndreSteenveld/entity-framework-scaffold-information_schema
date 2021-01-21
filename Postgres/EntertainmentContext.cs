using Microsoft.EntityFrameworkCore;

namespace InformationSchema.Postgres
{
    public class EntertainmentContext : DbContext, IEntertainmentContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql("Server=localhost;Port=5432;Database=entertainment;User Id=postgres;Password=P@55word;");

        public DbSet<Production> Productions { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Actor> Actors { get; set; }

    }
}