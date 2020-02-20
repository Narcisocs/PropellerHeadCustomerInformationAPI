using System;
using System.Collections.Generic;
using System.Text;

namespace PropellerheadCI.Business.Models
{
    public class Note : Entity
    {
        public Guid CustomerId { get; set; }
        public string Message { get; set; }

        /* EF Relation */
        public Customer Customer { get; set; }
    }
}
