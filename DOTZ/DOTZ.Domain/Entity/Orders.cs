using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DOTZ.Domain.Entity
{
    [Table("Order")]
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        public int CostumerId { get; set; }
        public int ProductId { get; set; }
        public int AddressId { get; set; }
        public int OrderStatusId { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
