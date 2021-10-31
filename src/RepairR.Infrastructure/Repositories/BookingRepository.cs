using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.CosmosRepository;
using Microsoft.Extensions.Logging;
using RepairR.Application.Interfaces;
using RepairR.Domain.Entities;
using RepairR.Domain.Entities.Abstractions;

namespace RepairR.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly ILogger<BookingRepository> _logger;
    private readonly IRepository<Booking> _bookingCosmosRepository;

    public BookingRepository(ILogger<BookingRepository> logger, IRepository<Booking> bookingCosmosRepository)
    {
        _logger = logger;
        _bookingCosmosRepository = bookingCosmosRepository;
    }

    public async ValueTask<List<IBooking>> Get(string bookingReference, CancellationToken cancellationToken = default)
    {
        var bookings = await _bookingCosmosRepository.GetAsync(l => l.PartitionKey == "Booking" && l.Id == bookingReference, cancellationToken);
        return bookings.Cast<IBooking>().ToList();
    }
    
    public async ValueTask<List<IBooking>> Get(CancellationToken cancellationToken = default)
    {
        var bookings = await _bookingCosmosRepository.GetAsync(l => l.PartitionKey == "Booking", cancellationToken);
        return bookings.Cast<IBooking>().ToList();
    }
}