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

            var orders = repo.GetOrdersByDate(date);

            if (orders == null)
            {
                response.Success = false;
                response.Message = String.Format("There were no orders on date {0}.", date.ToShortDateString());
            }
            else
            {
                response.Success = false;
                response.OrderList = orders;
            }

            return response;
        }

        public Response GetSpecificOrder(int orderNumber, DateTime date)
        {
            var repo = new MockFloorRepository();

            var response = new Response();

            var orders = GetOrdersByDate(date);

            foreach (var order in orders)
            {
                if (order.OrderNumber == orderNumber)
                {
                    response.Success = true;
                    response.OrderInfo = order;
                    response.Message = String.Format("Here is the order information for order {0}.\n" +
                                                     "This order was placed on {1}", date.ToShortDateString());
                    return response;
                }
            }

            return response;
        }

        //public Response AddOrder(DateTime date)
        //{
        //    var repo = new MockFloorRepository();

        //    var response = new Response();

        //    return response;
        //}
    }
}
