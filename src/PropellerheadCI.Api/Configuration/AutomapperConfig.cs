using AutoMapper;
using PropellerheadCI.Api.ViewModels;
using PropellerheadCI.Business.Models;

namespace PropellerheadCI.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Address, AddressViewModel>().ReverseMap();
            CreateMap<Note, NoteViewModel>().ReverseMap();
        }
    }
}