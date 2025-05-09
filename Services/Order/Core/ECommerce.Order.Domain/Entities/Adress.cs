namespace ECommerce.Order.Domain.Entities
{
   public class Adress
    {
        public int AdressId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Disctrict { get; set; }
        public string AdressLine { get; set; }
    }
}
