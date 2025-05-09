using ECommerce.Order.Application.Features.CQRS.Queries;
using ECommerce.Order.Application.Features.CQRS.Results;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using Mapster;

namespace ECommerce.Order.Application.Features.CQRS.Handlers
{
    public class GetAdressByIdQueryHandler(IRepository<Adress> repository)
    {
        public async Task<List<GetAdressByIdQueryResult>> Handle(GetAdressByIdQuery ıdQuery)
        {
            var value = await repository.GetByIdAsync(ıdQuery.Id);
            if (value is null) throw new Exception("No Adress Found");
            return value.Adapt<List<GetAdressByIdQueryResult>>();

        }
    }

}

