using ECommerce.Order.Application.Features.Mediator.Results.OrderingResult;
using MediatR;

namespace ECommerce.Order.Application.Features.Mediator.Queries
{
    public class GetOrderingQuery : IRequest<List<GetOrderingQueryResult>>
    {
    }
}
