using ECommerce.Order.Application.Features.CQRS.Commands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using Mapster;

namespace ECommerce.Order.Application.Features.CQRS.Handlers
{
    public class CreateAdressCommandHandler(IRepository<Adress> repository)
    {
        public async Task Handle(CreateAdressCommand command)
        {
            var adress = command.Adapt<Adress>();
            await repository.CreateAsync(adress);
        }


    }
}
