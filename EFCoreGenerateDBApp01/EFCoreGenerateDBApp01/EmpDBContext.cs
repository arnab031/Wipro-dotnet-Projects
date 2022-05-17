using System;
using Microsoft.EntityFrameworkCore;
namespace EFCoreGenerateDBApp01
{
	//See Employee data using method extensions
    public static class MyExtensions
    {
		public static void SeedEmployee(this ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<EmpModel>().HasData(
				new EmpModel { Id = 1001, EName = "Raj", Job = "Trainer", Salary = 9000 },
				new EmpModel { Id = 1002, EName = "Kiran", Job = "Developer", Salary = 10000 }
				);
		}
    }
	public class EmpDBContext : DbContext
	{
		public EmpDBContext(DbContextOptions<EmpDBContext> options) : base(options)
		{
		}
		public DbSet<EmpModel> Employees{get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
			modelBuilder.SeedEmployee();
        }
    }
}

