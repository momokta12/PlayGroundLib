using Microsoft.EntityFrameworkCore;

namespace PlayGroundLib
{
    public class PlayGroundDbContext : DbContext
    {
        public DbSet<PlayGround> PlayGrounds { get; set; }

        public PlayGroundDbContext(DbContextOptions<PlayGroundDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=MOMO;Initial Catalog=PlayGrounds;Integrated Security=True;");
        }
    }
}
