using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MP.ApiDotNet6.Application.Mappings;
using MP.ApiDotNet6.Application.Services;
using MP.ApiDotNet6.Application.Services.Interfaces;
using MP.ApiDotNet6.Domain.Repositories;
using MP.ApiDotNet6.Infra.Data.Context;
using MP.ApiDotNet6.Infra.Data.Repositories;

namespace MP.ApiDotNet6.Infra.IoC
{
    public static class DependencyInjection
    {
        // Se criar um único método também funciona, o importante é montar corretamente para ambos na API
        
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Injetar o DB e o Repositories
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("")));

            services.AddScoped<IPersonRepository, PersonRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<IPersonService, PersonService>();
            return services;
        }
        // Método injetar os Serviços
    }
}
