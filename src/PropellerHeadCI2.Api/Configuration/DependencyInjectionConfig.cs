using Microsoft.Extensions.DependencyInjection;
using PropellerheadCI.Business.Interfaces;
using PropellerheadCI.Business.Notifications;
using PropellerheadCI.Business.Services;
using PropellerheadCI.Data.Context;
using PropellerheadCI.Data.Repository;

namespace PropellerheadCI.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<PropHeadDbContext>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();

            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<INoteService, NoteService>();

            return services;
        }
    }
}