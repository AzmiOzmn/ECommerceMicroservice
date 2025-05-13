using ECommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using MediatR;

namespace ECommerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class CreateOrderingCommandHandler(IRepository<Ordering> repository) : IRequestHandler<CreateOrderingCommand>
    {
        public Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
        {
           var ordering = new Ordering
           {
               UserId = request.UserId,
               OrderDate = request.OrderDate
           };
            repository.CreateAsync(ordering);
            return Task.CompletedTask;
        }
    }
}
