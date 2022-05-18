using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CorneliusCup.Golf.API.Entities.Configurations
{
    public class VenueConfig : IEntityTypeConfiguration<Venue>
    {
        public void Configure(EntityTypeBuilder<Venue> builder)
        {
            //builder.Property(x => x.Name)
            //    .HasMaxLength(256)
            //    .IsRequired();

            //builder.HasIndex(x => x.Name)
            //    .IsUnique();

            //builder.HasMany(x => x.GolfCourses)
            //    .WithOne(x => x.Venue)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
