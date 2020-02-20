using PropellerheadCI.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PropellerheadCI.Business.Interfaces
{
    public interface ICustomerService : IDisposable
    {
        Task Add(Customer customer);
        Task Update(Customer customer);        
        Task Remove(Guid id);        
        Task UpdateAddress(Address address);
    }
}
