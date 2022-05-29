using CorneliusCup.Golf.API.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CorneliusCup.Golf.API.Entities.Configurations
{
    public class ScoreCardConfig : IEntityTypeConfiguration<ScoreCard>
    {
        public void Configure(EntityTypeBuilder<ScoreCard> builder)
        {
            builder.OwnsOne(x => x.Tee, y =>
                {
                    y.OwnsMany(z => z.HoleDetails);
                    y.Property(x => x.Type)
                    .HasConversion(
                        y => y.ToString(),
                        y => (TeeType)Enum.Parse(typeof(TeeType), y));
                });
        }
    }
}
