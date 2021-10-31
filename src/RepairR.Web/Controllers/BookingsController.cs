using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepairR.Contracts.Dtos;
using RepairR.Contracts.Queries;

namespace RepairR.Web.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly ILogger<BookingsController> _logger;
    private readonly IMediator _mediator;

    public BookingsController(ILogger<BookingsController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    
    /// <summary>
    /// Get list of bookings in date order
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var results = await _mediator.Send(new FetchBookings());
        return Ok(results);
    }
}
