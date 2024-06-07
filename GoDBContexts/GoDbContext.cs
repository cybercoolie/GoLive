using Microsoft.EntityFrameworkCore;
using Microsoft.Data;

namespace GoLive.GoDBContexts
{
    public class GoDbContext: DbContext
    {
                
        //public GoDbContext(DbContextOptions<GoDbContext> options) : base(options)
        //{
        //}        

        private IConfiguration _config;
        public GoDbContext(IConfiguration config)
        {
            _config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //SQL server
            var SQLServerconnectionString = _config.GetConnectionString("SQLServerconnectionString");
            if (SQLServerconnectionString != null)
            {
               optionsBuilder.UseSqlServer(_config.GetConnectionString("SQLServerconnectionString"));
            }
            //PostgreSQL server
            var PostgreSQlconnectionString = _config.GetConnectionString("PostgreSQLConnection");
            if (PostgreSQlconnectionString != null)
            {
                optionsBuilder.UseNpgsql(_config.GetConnectionString("PostgreSQLConnection"));
            }
            var MySQlconnectionString = _config.GetConnectionString("MySQLConnection");
            if (MySQlconnectionString != null)
            {
                optionsBuilder.UseMySql(MySQlconnectionString, ServerVersion.AutoDetect(MySQlconnectionString));
            }
        }
        public DbSet<Users> Users { get; set; }

    }
}
