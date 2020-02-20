using System;
using System.Collections.Generic;
using System.Text;

namespace PropellerheadCI.Business.Models
{
    public class Customer : Entity
    {
        public StatusType Status { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }

        /* EF Relation */
        public Address Address { get; set; }
        public IEnumerable<Note> Notes { get; set; }
    }
}
