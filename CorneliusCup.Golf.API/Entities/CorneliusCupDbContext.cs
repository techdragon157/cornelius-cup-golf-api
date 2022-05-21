using Microsoft.EntityFrameworkCore;

namespace CorneliusCup.Golf.API.Entities
{
    public class CorneliusCupDbContext : DbContext
    {
        public CorneliusCupDbContext(DbContextOptions<CorneliusCupDbContext> options) : base(options) { }

        public DbSet<Resort> Resorts { get; set; } = default!;
        public DbSet<GolfCourse> GolfCourses { get; set; } = default!;
        public DbSet<Tee> Tees { get; set; } = default!;
        public DbSet<Player> Players { get; set; } = default!;
        public DbSet<Team> Teams { get; set; } = default!;
        public DbSet<Competition> Competitions { get; set; } = default!;
        public DbSet<ScoreCard> ScoreCards { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Find all classes the implements IEntityTypeConfiguration<T>
            modelBuilder.ApplyConfigurationsFromAssembly(assembly: typeof(CorneliusCupDbContext).Assembly);
        }
    }
}
