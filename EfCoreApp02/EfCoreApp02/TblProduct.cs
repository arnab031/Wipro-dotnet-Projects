using System;
using System.Collections.Generic;

namespace EfCoreApp02
{
    public partial class TblProduct
    {
        public int Id { get; set; }
        public string? Pname { get; set; }
        public string? Brand { get; set; }
        public int? Price { get; set; }
    }
}
