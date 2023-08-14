using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemMicroservice.Services.Order.Core.Domain.Entities
{
    public class Ordering
    {
        public int OrderingID { get; set; }
        public string UserID { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime dateTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
