using System;
using Microsoft.EntityFrameworkCore;

namespace EFCoreApp03
{
    public class CollegeDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public CollegeDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("cs1"));
        }

        public DbSet<StudentModel> Students { get; set; }
    }
}

