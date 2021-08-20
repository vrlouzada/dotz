using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.Domain.DTO
{
    public class OrderRequest
    {
        public int ProductId { get; set; }
        public int AddressId { get; set; }

    }
}
