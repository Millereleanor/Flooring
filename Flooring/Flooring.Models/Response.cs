using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Order OrderInfo { get; set; }
        public List<Order> OrderList { get; set; } 
    }
}
