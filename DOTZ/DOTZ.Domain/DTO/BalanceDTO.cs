using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.Domain.DTO
{
    public class BalanceDTO
    {
        public double Balance { get; set; }

        public List<ExtractDTO> Extracts { get; set; }

    }
}
