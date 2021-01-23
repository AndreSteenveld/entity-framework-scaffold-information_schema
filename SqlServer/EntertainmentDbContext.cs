using Microsoft.EntityFrameworkCore;

namespace InformationSchema.SqlServer
{
    public class EntertainmentContext : DbContext, IEntertainmentContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost,1433;Database=entertainment;User=sa;Password=P@55word;Trusted_Connection=False;");
        public DbSet<Production> Productions { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }
}