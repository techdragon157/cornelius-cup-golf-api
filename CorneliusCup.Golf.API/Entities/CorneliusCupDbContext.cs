using Microsoft.EntityFrameworkCore;

namespace CorneliusCup.Golf.API.Entities
{
    public class CorneliusCupDbContext : DbContext
    {
        public CorneliusCupDbContext(DbContextOptions<CorneliusCupDbContext> options) : base(options) { }

        public DbSet<Venue> Venues { get; set; } = default!;
        public DbSet<GolfCourse> GolfCourses { get; set; } = default!;
        public DbSet<Tee> Tees { get; set; } = default!;
        public DbSet<Player> Players { get; set; } = default!;
        public DbSet<Team> Teams { get; set; } = default!;
        public DbSet<Competition> Competitions { get; set; } = default!;
        public DbSet<ScoreCard> ScoreCards { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .Property(x => x.Handicap)
                .HasDefaultValue(54);

            modelBuilder.Entity<GolfCourse>()
                .OwnsMany(x => x.Tees, y =>
                {
                    y.OwnsMany(z => z.HoleDetails);
                    y.Property(x => x.TeeType)
                    .HasConversion(
                        y => y.ToString(),
                        y => (TeeType)Enum.Parse(typeof(TeeType), y));
                });

            modelBuilder.Entity<ScoreCard>()
                .OwnsMany(x => x.Tees, y =>
                {
                    y.OwnsMany(z => z.HoleDetails);
                    y.Property(x => x.TeeType)
                    .HasConversion(
                        y => y.ToString(),
                        y => (TeeType)Enum.Parse(typeof(TeeType), y));
                });

            //modelBuilder.Entity<ScoreCard>()
            //    .Property(x => x.TeeType)
            //        .HasConversion(
            //            y => y.ToString(),
            //            y => (TeeType)Enum.Parse(typeof(TeeType), y));

            //modelBuilder.Entity<ScoreCard>().OwnsMany(x => x.HoleScores);

            //modelBuilder.Entity<ScoreCard>()
            //    .OwnsOne(x => x.Tee, y =>
            //     {
            //         y.OwnsMany(z => z.HoleDetails);
            //         y.Property(x => x.Type)
            //         .HasConversion(
            //             y => y.ToString(),
            //             y => (TeeType)Enum.Parse(typeof(TeeType), y));
            //     });

            //modelBuilder.Entity<GolfCourse>()
            //    .OwnsMany(x => x.Tees, y =>
            //    {
            //        y.WithOwner().HasForeignKey("GolfCourseId");
            //        y.Property<int>("TeeyId");
            //        y.HasKey("TeeyId");
            //        y.OwnsMany(z => z.HoleDetails, a =>
            //        {
            //            y.WithOwner().HasForeignKey("TeezId");
            //            y.Property<int>("HoleDetailsId");
            //            y.HasKey("HoleDetailsId");
            //        });
            //    });

            //modelBuilder.Entity<Tee>()
            //    .Property(x => x.Type)
            //    .HasConversion(
            //        y => y.ToString(),
            //        y => (TeeType)Enum.Parse(typeof(TeeType), y));
        }
    }
}
