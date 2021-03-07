
using HelloKitty.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloKitty
{
    public sealed class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }
        public DbSet<RegistrationViewModel> Registration { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=2874;Database=Registration;Username=postgres;Password=deadpoets6022");
        }
    }
}