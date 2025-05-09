using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.CQRS.Results
{
   public class GetAdressByIdQueryResult
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
