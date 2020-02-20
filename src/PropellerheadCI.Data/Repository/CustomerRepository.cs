using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PropellerheadCI.Business.Interfaces;
using PropellerheadCI.Business.Models;
using PropellerheadCI.Data.Context;
using PropellerheadCI.Data.Repository;

namespace PropellerheadCI.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(PropHeadDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Note>> GetAllNotesByCustomer(Guid id)
        {
            return await Db.Notes.AsNoTracking().Where(c => c.CustomerId == id).ToListAsync();
        }

        public async Task<Customer> GetCustomerFullInfo(Guid id)
        {
            return await Db.Customers.AsNoTracking().Include(c => c.Notes).Include(c => c.Address).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}