using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EFCoreGenerateDBApp01
{
	[Table("tblEmployees")]
	public class EmpModel
	{
		[Key]
		public int Id { get; set; }

		public string EName { get; set; }

		public string Job { get; set; }
		public int Salary { get; set; }
	}
}

