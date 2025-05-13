using ECommerce.Order.Application.Features.CQRS.Commands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using Mapster;

namespace ECommerce.Order.Application.Features.CQRS.Handlers
{
   public class UpdateAdressCommandHandler(IRepository<Adress> repository)
    {
        public async Task Handle(UpdateAdressCommand command)
        {
            var adress = command.Adapt<Adress>();
            await repository.UpdateAsync(adress);
        }
    }
}
