using CasgemMicroservice.Services.Order.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemMicroservices.Order.Core.Application.Dtos.OrderingDtos
{
    public class UpdateOrderDto
    {
        public int OrderingID { get; set; }
        public string UserID { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime dateTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
