namespace donuts.Models
{
    public class DonutDbContext : DbContext
    {
        public DonutDbContext(DbContextOptions<DonutDbContext> options) : base(options)
        {
        }

        public DbSet<Donuts> Donuts { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //=> optionsBuilder.UseMySql("name=ConnectionStrings:DefaultConnection", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.39-mysql"));

    }
}
