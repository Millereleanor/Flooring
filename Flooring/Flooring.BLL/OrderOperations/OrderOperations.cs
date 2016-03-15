using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Data;
using Flooring.Models;

namespace Flooring.BLL.OrderOperations
{
    public class OrderOperations
    {
        public Response GetOrders(DateTime date)
        {
            var repo = new MockFloorRepository();

            var response = new Response();

            var orders = repo.GetOrderByDate(date);

            if (orders == null)
            {
                response.Success = false;
                response.Message = String.Format("There were no orders on date {0}.", date.ToShortDateString());
            }
            else
            {
                response.Success = false;
                response.OrderInfo = orders;
            }
        }

        public Response GetSpecificOrder(int orderNumber, DateTime date)
        {
            var repo = new MockFloorRepository();

            var response = new Response();
        }
    }
}
