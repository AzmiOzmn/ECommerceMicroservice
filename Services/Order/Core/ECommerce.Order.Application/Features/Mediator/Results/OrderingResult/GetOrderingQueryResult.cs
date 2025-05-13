using System;

namespace ECommerce.Order.Application.Features.Mediator.Results.OrderingResult
{
    public record GetOrderingQueryResult
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
