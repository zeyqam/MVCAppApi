using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCAppApi.Models;

namespace MVCAppApi.Helpers.EntityConfigurations
{
    public class SliderConfigurations : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(m => m.Title).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Description).IsRequired().HasMaxLength(200);
            builder.Property(m => m.Image).IsRequired();
        }
    }
}
