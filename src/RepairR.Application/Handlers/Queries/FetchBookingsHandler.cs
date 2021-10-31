using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using RepairR.Application.Interfaces;
using RepairR.Contracts.Dtos;
using RepairR.Contracts.Queries;
using RepairR.Domain.Entities.Abstractions;

namespace RepairR.Application.Handlers.Queries;
public class FetchBookingsHandler : IRequestHandler<FetchBookings, IEnumerable<BookingDto>>
{
    private readonly ILogger<FetchBookingsHandler> _logger;
    private readonly IBookingRepository _bookingRepository;

    public FetchBookingsHandler(ILogger<FetchBookingsHandler> logger, IBookingRepository bookingRepository)
    {
        _logger = logger;
        _bookingRepository = bookingRepository;
    }

    public async Task<IEnumerable<BookingDto>> Handle(FetchBookings request, CancellationToken cancellationToken)
    {
        IEnumerable<IBooking> bookings = await _bookingRepository.Get(cancellationToken);

        _logger.LogInformation("Fetched bookings");

        return bookings.Select(b => new BookingDto(b.Reference, b.CreatedUtc));
    }
}