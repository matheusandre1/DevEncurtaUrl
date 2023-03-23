using DevEncurtaUrl.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevEncurtaUrl.Persistence
{
    public class DevEncurtaURLDBContext : DbContext
    {


        public DevEncurtaURLDBContext(DbContextOptions<DevEncurtaURLDBContext> options)
            : base(options)
        {

        }

        public DbSet<ShortenedCustomLink> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ShortenedCustomLink>(e =>
            {
                e.HasKey(l => l.Id);
            });
        }

       
    }

}
