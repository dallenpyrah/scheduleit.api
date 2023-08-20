using Microsoft.Extensions.DependencyInjection;
using ScheduleIt.Business.Managers;
using ScheduleIt.DataAccess.Repositories;
using ScheduleIt.Interfaces.Repositories;

namespace ScheduleIt.Business.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCompanyDependenciesToServiceCollection(this IServiceCollection services)
    {
        services.AddScoped<ICompaniesRepository, CompaniesRepository>();
        services.AddScoped<CompaniesManager>();
    }
    
    public static void AddEmployeeDependenciesToServiceCollection(this IServiceCollection services)
    {
        services.AddScoped<IEmployeesRepository, EmployeesRepository>();
        services.AddScoped<EmployeesManager>();
    }
    
    public static void AddAuthDependenciesToServiceCollection(this IServiceCollection services)
    {
        services.AddScoped<AuthManager>();
    }
    
    public static void AddRoleDependenciesToServiceCollection(this IServiceCollection services)
    {
        services.AddScoped<IRolesRepository, RolesRepository>();
        services.AddScoped<RolesManager>();
    }
}