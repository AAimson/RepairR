using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RepairR.Domain.Entities.Abstractions;

namespace RepairR.Application.Interfaces;

public interface IBookingRepository
{
    ValueTask<List<IBooking>> Get(string bookingReference, CancellationToken cancellationToken = default);

    ValueTask<List<IBooking>> Get(CancellationToken cancellationToken = default);
}