using System;
using System.Collections.Generic;

namespace EFCoreDatabaseFirstDemo01
{
    public partial class TblEmployee
    {
        public int Id { get; set; }
        public string Ename { get; set; } = null!;
        public string Job { get; set; } = null!;
        public int Salary { get; set; }
    }
}
