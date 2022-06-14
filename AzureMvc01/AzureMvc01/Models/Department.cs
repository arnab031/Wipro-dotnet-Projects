using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureMvc01.Models
{
		[Table("tblDepartments")]
		public class Department
		{
			[Key]
			public int Id { get; set; }
			public string DName { get; set; }
			public bool IsActive { get; set; }
			public ICollection<Employee> Employees { get; set; }
		}
	
}

