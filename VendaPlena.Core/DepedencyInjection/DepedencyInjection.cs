using VendaPlena.Domain.v1.Interfaces.Repositories;
using VendaPlena.Domain.v1.Repositories;
using Microsoft.Extensions.DependencyInjection;
using VendaPlena.Domain.v1.Interfaces.Services;
using VendaPlena.Domain.v1.Services;

namespace VendaPlena.Core.DepedencyInjection
{
    public static class DepedencyInjection
    {
        public static void ResolveDepedencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IClienteServices, ClienteServices>();
            services.AddScoped<IDividaServices, DividaServices>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IDividaRepository, DividaRepository>();

        }

    }
}
