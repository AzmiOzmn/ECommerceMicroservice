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

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var ordering = await mediator.Send(new GetOrderingByIdQuery(id));
            if (ordering is null)
            {
                return NotFound($"Ordering with ID {id} not found.");
            }
            return Ok(ordering);
        }

        [HttpPut]

        public async Task<IActionResult> Update(UpdateOrderingComment command)
        {
            if (command is null)
            {
                return BadRequest("Invalid command.");
            }
            await mediator.Send(command);
            return Ok("Order Updated");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Order Deleted");
        }
    }
}