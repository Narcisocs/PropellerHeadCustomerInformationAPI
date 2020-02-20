using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PropellerheadCI.Api.ViewModels;
using PropellerheadCI.Business.Interfaces;
using PropellerheadCI.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropellerheadCI.Api.Controllers
{
    [Route("api/customers")]
    public class CustomersController : MainController
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepository customerRepository,
                                   ICustomerService customerService,
                                   IMapper mapper,
                                   INotifier notifier) : base(notifier)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerViewModel>> GetAllCustomers()
        {
            return _mapper.Map<IEnumerable<CustomerViewModel>>(await _customerRepository.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CustomerViewModel>> GetFullCustomerDetailById(Guid id)
        {
            var customer = await GetCustomerById(id);

            if (customer == null) return NotFound();

            return customer;
        }

        [HttpGet]
        [Route("AllNotes/{id:guid}")]
        public async Task<IEnumerable<NoteViewModel>> GetNotesByCustomerId(Guid id)
        {
            return  _mapper.Map<IEnumerable<NoteViewModel>>(await _customerRepository.GetAllNotesByCustomer(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerViewModel>> AddCustomer(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _customerService.Add(_mapper.Map<Customer>(customerViewModel));

            return CustomResponse(customerViewModel);
        }

        [HttpPut("{id:guid}/{status:int}")]
        public async Task<ActionResult<CustomerViewModel>> UpdateStatus(Guid id, CustomerViewModel customerViewModel, StatusType status)
        {
            if (id != customerViewModel.Id)
            {
                NotificarErro("The id informed is not the same as the one in the url.");
                return CustomResponse(customerViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            customerViewModel.Status = (int)status;

            await _customerService.Update(_mapper.Map<Customer>(customerViewModel));

            return CustomResponse(customerViewModel);
        }

        public async Task<CustomerViewModel> GetCustomerById(Guid id)
        {
            return _mapper.Map<CustomerViewModel>(await _customerRepository.GetCustomerFullInfo(id));
        }
    }
}
