using Microsoft.Extensions.DependencyInjection;
using RepairR.Application.Interfaces;
using RepairR.Domain.Entities;
using RepairR.Infrastructure.Repositories;

namespace RepairR.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    private const string PartitionKeyValue = "/partitionKey";
    private const string BookingsContainer = "bookings";

    public static IServiceCollection AddRepairStoreInfrastructure(this IServiceCollection services) =>
        services.AddCosmosRepository(options =>
                    options.ContainerBuilder
                        .Configure<Booking>(builder =>
                            builder
                                .WithContainer(BookingsContainer)
                                .WithManualThroughput(400)
                                .WithPartitionKey(PartitionKeyValue)
                                .WithSyncableContainerProperties())
                /*.Configure<GlobalPackingAreaLookupItem>(builder =>
                    builder
                        .WithContainer(BookingsContainer)
                        .WithManualThroughput()
                        .WithPartitionKey(PartitionKeyValue)
                        .WithSyncableContainerProperties())
                .Configure<Location>(builder =>
                    builder
                        .WithContainer(BookingsContainer)
                        .WithManualThroughput()
                        .WithPartitionKey(PartitionKeyValue)
                        .WithSyncableContainerProperties())
                .Configure<GlobalLocationLookupItem>(builder =>
                    builder
                        .WithContainer(BookingsContainer)
                        .WithManualThroughput()
                        .WithPartitionKey(PartitionKeyValue)
                        .WithSyncableContainerProperties())*/
            )
            // add service bus
            //.AddPublishedPackAreaServiceEvents()
            .AddSingleton<IBookingRepository, BookingRepository>();
    //.AddSingleton<ILocationsRepository, LocationsRepository>();

    // private static IServiceCollection AddPublishedPackAreaServiceEvents(this IServiceCollection services) =>
    //     services.AddWhdsServiceBusMessage<PackingAreaEvent>(options =>
    //     {
    //         options.Name = $"{PackAreaServiceConstants.Name}/{PackAreaServiceConstants.Events.PackingAreaEvent}";
    //         options.Type = MessageType.Topic;
    //     });
}