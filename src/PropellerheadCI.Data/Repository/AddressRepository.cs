using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PropellerheadCI.Business.Interfaces;
using PropellerheadCI.Business.Models;
using PropellerheadCI.Data.Context;

namespace PropellerheadCI.Data.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(PropHeadDbContext context) : base(context) { }

        public async Task<Address> GetAddressByCustomer(Guid customerId)
        {
            return await Db.Addresses.AsNoTracking()
                .FirstOrDefaultAsync(a => a.CustomerId == customerId);
        }
    }
}