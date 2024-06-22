using Microsoft.EntityFrameworkCore;
using MVCAppApi.Models;
using System.Reflection;

namespace MVCAppApi.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<About> Abouts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<Slider>().HasQueryFilter(m => !m.SoftDeleted);
            builder.Entity<Setting>().HasQueryFilter(m => !m.SoftDeleted);
            builder.Entity<About>().HasQueryFilter(m => !m.SoftDeleted);





            base.OnModelCreating(builder);

        }

    }
}
