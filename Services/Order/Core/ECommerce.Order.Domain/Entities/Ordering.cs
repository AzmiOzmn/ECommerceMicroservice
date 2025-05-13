namespace ECommerce.Order.Domain.Entities
{
    public class Ordering
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public IList<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>(); // Default olarak boş liste

        public decimal TotalPrice
        {
            get
            {          
                if (OrderDetails == null || !OrderDetails.Any())
                {
                    return 0;
                }

                return OrderDetails.Sum(x => x.ProductPrice * x.Quantity);

            }
        }
    }
}
