using DOTZ.Domain.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.Domain.DTO
{
    public class OrderStatusResponse
    {
        public string ProductName { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
    }
}
