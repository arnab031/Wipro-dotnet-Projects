using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AzureMvc01.Models;

    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext (DbContextOptions<EmployeeDBContext> options)
            : base(options)
        {
        }

        public DbSet<AzureMvc01.Models.Department>? Department { get; set; }

        public DbSet<AzureMvc01.Models.Employee>? Employee { get; set; }
    }
