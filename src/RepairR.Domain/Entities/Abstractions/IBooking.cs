using Microsoft.Azure.Cosmos.Spatial;
using Microsoft.Azure.CosmosRepository;

namespace RepairR.Domain.Entities.Abstractions;

public interface IBooking : IItem
{
    string Reference { get; }
        
    DateTime CreatedUtc { get; }
}