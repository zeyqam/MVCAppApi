using Microsoft.EntityFrameworkCore;
using MVCAppApi.Models;
using System.Reflection;

namespace MVCAppApi.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        public DbSet<Slider> Sliders { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<Slider>().HasQueryFilter(m => !m.SoftDeleted);





            base.OnModelCreating(builder);

        }

    }
}
