using MediatR;
using RepairR.Contracts.Dtos;

namespace RepairR.Contracts.Queries;

public record FetchBookings() : IRequest<IEnumerable<BookingDto>>;