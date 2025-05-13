using ECommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;
using ECommerce.Order.Application.Features.Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
          var orderings = await mediator.Send(new GetOrderingQuery());
            if (orderings is null || !orderings.Any())
            {
                return NotFound("No orderings found.");
            }
            return Ok(orderings);
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateOrderingCommand command)
        {
            if (command is null)
            {
                return BadRequest("Invalid command.");
            }

            await mediator.Send(command);
            
            return Ok("Order Created");

        }
    }
}
