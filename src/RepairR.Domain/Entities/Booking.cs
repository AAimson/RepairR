using Microsoft.Azure.Cosmos.Spatial;
using RepairR.Domain.Entities.Abstractions;

namespace RepairR.Domain.Entities;

public class Booking : Entity, IBooking
{
    const string booking = "Booking";
    public string Reference { get; private set; }

    public Booking(string reference)
    {
        if (string.IsNullOrWhiteSpace(reference))
        {
            throw new Exception("A location must have a name");
        }

        Id = reference;
        Reference = reference;
        PartitionKey = booking;
    }
}