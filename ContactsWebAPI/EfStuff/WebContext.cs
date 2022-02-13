using ContactsWebAPI.EfStuff.DbModel;
using Microsoft.EntityFrameworkCore;

namespace ContactsWebAPI.EfStuff
{
    public class WebContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public WebContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasMany(a => a.Texts).WithOne(t => t.Author);
            modelBuilder.Entity<Author>().HasMany(a => a.Photos).WithOne(p => p.Author);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
