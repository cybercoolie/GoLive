using Microsoft.EntityFrameworkCore;

namespace GoLive.GoDBContexts
{
    public class GoDbContext: DbContext
    {
        private IConfiguration _config;
        public GoDbContext(IConfiguration  config)
        {
            _config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
        }
        public DbSet<Users> Users { get; set; }

    }
}
