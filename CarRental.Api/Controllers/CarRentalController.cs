using CarRental.Api.Dtos;
using CarRental.Application.UseCases.CarPickup;
using CarRental.Application.UseCases.CarReturn;
using CarRental.Application.UseCases.GetCarRentalByBookingNumber;
using CarRental.Domain.Entities;
using CarRental.Domain.Errors;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace CarRental.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CarRentalController : ControllerBase
{
    private readonly ILogger<CarRentalController> _logger;
    private IMediator _mediator;

    public CarRentalController(ILogger<CarRentalController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }


    [HttpPost]
    public async Task<IActionResult> CarPickup([FromBody] RegisterCarPickupCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }


    [HttpPost("return/{bookingNumber}", Name = "CarReturn")]
    public async Task<ActionResult<Rental>> CarReturn([FromRoute] string bookingNumber,
        [FromBody] CarReturnDto carReturnDto)
    {
        //todo: add input validation
        var result =
            await _mediator.Send(new RegisterCarReturnCommand(bookingNumber, carReturnDto.ReturnDateTime,
                carReturnDto.ReturnMeterReading));

        if (result.IsFailed)
        {
            return HandleFailure(result.Errors);
        }

        return Ok();
    }

    [HttpGet("{bookingNumber}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Rental>> GetCarRentalByBookingNumber([FromRoute] string bookingNumber)
    {
        var result = await _mediator.Send(new CarRentalByBookingNumberQuery(bookingNumber));
        if (result.IsFailed)
        {
            return HandleFailure(result.Errors);
        }

        return Ok(result.Value);
    }

    private ObjectResult HandleFailure(List<IError> errors)
    {
        if (errors.Any(x => x is NotFoundError))
            return StatusCode(StatusCodes.Status404NotFound, errors);
        else
        {
            return StatusCode(StatusCodes.Status500InternalServerError, errors);
        }
    }
}