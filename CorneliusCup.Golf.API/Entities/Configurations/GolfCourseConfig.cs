using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CorneliusCup.Golf.API.Entities.Configurations
{
    public class GolfCourseConfig : IEntityTypeConfiguration<GolfCourse>
    {
        public void Configure(EntityTypeBuilder<GolfCourse> builder)
        {
            builder.OwnsMany(x => x.Tees, y =>
                {
                    y.OwnsMany(z => z.HoleDetails);
                    y.Property(x => x.TeeType)
                    .HasConversion(
                        y => y.ToString(),
                        y => (TeeType)Enum.Parse(typeof(TeeType), y));
                });
        }
    }
}
