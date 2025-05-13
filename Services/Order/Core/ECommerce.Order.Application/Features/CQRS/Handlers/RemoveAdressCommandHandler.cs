using ECommerce.Order.Application.Features.CQRS.Commands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;

namespace ECommerce.Order.Application.Features.CQRS.Handlers
{
   public class RemoveAdressCommandHandler(IRepository<Adress> repository)
    {
        public async Task Handle(RemoveAdressCommand command)
        {
            await repository.DeleteAsync(command.Id);

        }
    }
}
