using System;
using System.Collections.Generic;
using System.Text;

namespace PropellerheadCI.Business.Models
{
    public class Address : Entity
    {
        public Guid CustomerId { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Additional { get; set; }
        public string ZipCode { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        /* EF Relation */
        public Customer Customer { get; set; }
    }
}
