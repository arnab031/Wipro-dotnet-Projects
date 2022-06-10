using System;
using System.Collections.Generic;

namespace EFCoreApp05.Models
{
    public partial class TblCourse
    {
        public int Id { get; set; }
        public string? CourseName { get; set; }
        public string? Hod { get; set; }
        public int? Fee { get; set; }
    }
}
