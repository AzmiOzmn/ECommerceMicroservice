namespace ECommerce.Order.Application.Features.CQRS.Commands
{
  public record UpdateAdressCommand
    {

        public int AdressId { get; init; }
        public string UserId { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public string City { get; init; }
        public string Disctrict { get; init; }
        public string AdressLine { get; init; }
    }
}
