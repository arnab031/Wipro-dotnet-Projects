using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureMvc01.Models
{
    [Table("tblEmployees")]
		public class Employee
		{
			[Key]
			public int Id { get; set; }
			[ForeignKey("Department")]
			public int FkDeptId { get; set; }
			public string EName { get; set; }
			public string Job { get; set; }
			public bool IsActive { get; set; }
			public Department Department { get; set; }
		}
	
}

