using PropellerheadCI.Business.Interfaces;
using PropellerheadCI.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PropellerheadCI.Business.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetCustomerFullInfo(Guid id);
        Task<IEnumerable<Note>> GetAllNotesByCustomer(Guid id);
    }
}
