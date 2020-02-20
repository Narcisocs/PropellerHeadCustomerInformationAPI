using PropellerheadCI.Business.Interfaces;
using PropellerheadCI.Business.Models;
using PropellerheadCI.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropellerheadCI.Business.Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;

        public CustomerService(ICustomerRepository customerRepository,
                               IAddressRepository addressRepository,
                               INotifier notifier) : base(notifier)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
        }

        public async Task Add(Customer customer)
        {
            if (!ExecuteValidation(new CustomerValidations(), customer)
                || !ExecuteValidation(new AddressValidations(), customer.Address)) return;

            if (_customerRepository.Search(c => c.Name == customer.Name && c.Surname == customer.Surname).Result.Any())
            {
                Notify("There is already a customer with that Name and Surname");
                return;
            }

            await _customerRepository.Add(customer);
            return;
        }

        public async Task Remove(Guid id)
        {
            if (_customerRepository.GetAllNotesByCustomer(id).Result.Any())
            {
                Notify("The customer already possess registered notes!");
                return;
            }

            var endereco = await _addressRepository.GetAddressByCustomer(id);

            if (endereco != null)
            {
                await _addressRepository.Delete(endereco.Id);
            }

            await _customerRepository.Delete(id);
            return;
        }

        public async Task Update(Customer customer)
        {
            if (!ExecuteValidation(new CustomerValidations(), customer)) return;

            await _customerRepository.Update(customer);
            return;
        }

        public async Task UpdateAddress(Address address)
        {
            if (!ExecuteValidation(new AddressValidations(), address)) return;

            await _addressRepository.Update(address);
        }

        public void Dispose()
        {
            _customerRepository?.Dispose();
            _addressRepository?.Dispose();
        }
    }
}
