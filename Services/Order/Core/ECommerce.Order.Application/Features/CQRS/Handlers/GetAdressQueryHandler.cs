using ECommerce.Order.Application.Features.CQRS.Results;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using Mapster;

namespace ECommerce.Order.Application.Features.CQRS.Handlers
{
   public class GetAdressQueryHandler(IRepository<Adress> repository)
    {
        public async Task<List<GetAdressQueryResult>> Handle ()
        {
            var values = await repository.GetAllAsync();
            if (values == null) throw new Exception("No Adress Found");
            return values.Adapt<List<GetAdressQueryResult>>();


        }
    }
}
