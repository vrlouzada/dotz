using DOTZ.Domain.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.Domain.DTO
{
    public class ExtractDTO
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public ExtractValue Type { get; set; }
    }
}
