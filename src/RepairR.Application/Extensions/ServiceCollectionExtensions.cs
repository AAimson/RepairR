using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace RepairR.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepairStoreApplication(this IServiceCollection services) =>
        services.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);
}