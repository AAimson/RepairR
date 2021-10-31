using Microsoft.Azure.CosmosRepository;

namespace RepairR.Domain.Entities.Abstractions;

public abstract class Entity : IItem
{
    public string Id { get; set; }
    public string Type { get; set; }
    public string PartitionKey { get; protected set; }
    public DateTime CreatedUtc { get; }

    protected Entity()
    {
        Id = Guid.NewGuid().ToString();
        Type = GetType().Name;
        PartitionKey = Id;
        CreatedUtc = DateTime.UtcNow;
    }
}