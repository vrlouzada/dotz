using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DOTZ.Domain.Entity
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public int CostumerId { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string PostalCode { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
