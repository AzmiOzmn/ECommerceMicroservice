using ECommerce.Order.Application.Features.CQRS.Commands;
using ECommerce.Order.Application.Features.CQRS.Handlers;
using ECommerce.Order.Application.Features.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressesController(
        GetAdressQueryHandler getAdressQueryHandler,
        GetAdressByIdQueryHandler getAdressByIdQueryHandler,
        CreateAdressCommandHandler createAdressCommandHandler,
        UpdateAdressCommandHandler updateAdressCommandHandler,
        RemoveAdressCommandHandler removeAdressCommandHandler



        ) : ControllerBase
    {
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var adresses = await getAdressQueryHandler.Handle();
            return Ok(adresses);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var adress = await getAdressByIdQueryHandler.Handle(new GetAdressByIdQuery(id));
          
            return Ok(adress);

        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateAdressCommand createAdressCommand)
        {
            await createAdressCommandHandler.Handle(createAdressCommand);
            if (createAdressCommand is null) return BadRequest("Adress Not Created");
            return Ok("Adress Created");
        }

        [HttpPut]

        public async Task<IActionResult> Update(UpdateAdressCommand command)
        {
            await updateAdressCommandHandler.Handle(command);
            if (command is null) return BadRequest("Adress Not Updated");
            return Ok("Adress Updated");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            await removeAdressCommandHandler.Handle(new RemoveAdressCommand(id));
            return Ok("Adress Deleted");

        }

    }
}
