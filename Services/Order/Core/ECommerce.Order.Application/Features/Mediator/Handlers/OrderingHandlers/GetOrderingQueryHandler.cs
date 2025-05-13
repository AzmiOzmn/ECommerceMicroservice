using ECommerce.Order.Application.Features.Mediator.Queries;
using ECommerce.Order.Application.Features.Mediator.Results.OrderingResult;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using MediatR;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace ECommerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
        {
            // Siparişleri al
            var values = await _repository.GetAllAsync();

            // Her sipariş için dönüşüm yap
            return values.Select(x => new GetOrderingQueryResult()
            {
                OrderingId = x.OrderingId,    // OrderingId'yi alıyoruz
                UserId = x.UserId,            // Kullanıcı ID'sini alıyoruz
                TotalPrice = x.TotalPrice,    // Toplam fiyatı alıyoruz
                OrderDate = x.OrderDate       // Sipariş tarihini alıyoruz
            }).ToList();
        }
    }
}
