using ProperTea.Company.Api.DomainEvents;
using ProperTea.Company.Application.Company.Commands;
using ProperTea.Company.Application.Company.Models;
using ProperTea.Company.Application.Company.Queries;
using ProperTea.Company.Application.Core;
using ProperTea.Company.Domain.Company;
using ProperTea.Company.Domain.Core;
using ProperTea.Company.Infrastructure.Company.Data;
using ProperTea.Company.Infrastructure.Core;

namespace ProperTea.Company.Api.Setup
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddGeneralServices(this IServiceCollection services,
            IConfiguration configuration)
        {            
            services.AddScoped<IDomainEventDispatcher, RecursiveDomainEventDispatcher>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddCompanyServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICompanyRepository, CompanyRepository>();

            services.AddTransient<ICompanyDomainService, CompanyDomainService>();

            services.AddTransient<IQueryHandler<GetCompanyByIdQuery, CompanyModel>, GetCompanyByIdQueryHandler>();
            services.AddTransient<IQueryHandler<GetCompaniesByFilterQuery, IEnumerable<CompanyModel>>, GetCompaniesByFilterQueryHandler>();

            services.AddTransient<ICommandHandler<CreateCompanyCommand, Guid>, CreateCompanyCommandHandler>();
            services.AddTransient<ICommandHandler<DeleteCompanyCommand>, DeleteCompanyCommandHandler>();
            services.AddTransient<ICommandHandler<ChangeCompanyNameCommand>, ChangeCompanyNameCommandHandler>();

            return services;
        }
    }
}
