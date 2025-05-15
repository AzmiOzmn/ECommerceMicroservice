using ECommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using Mapster;
using MediatR;

namespace ECommerce.Order.Application.Features.CQRS.Handlers
{
    public class UpdateOrderingCommandHandler(IRepository<Ordering> repository) : IRequestHandler<UpdateOrderingComment>
    {
        public async Task Handle(UpdateOrderingComment request, CancellationToken cancellationToken)
        {

           var ordering = request.Adapt<Ordering>();
           await repository.UpdateAsync(ordering);
           

        }
    }
}
