using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CorneliusCup.Golf.API.Entities.Configurations
{
    public class ResortConfig : IEntityTypeConfiguration<Resort>
    {
        public void Configure(EntityTypeBuilder<Resort> builder)
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
