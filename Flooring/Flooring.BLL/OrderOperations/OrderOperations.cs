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
        private Order _currentOrder;
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

        public Response AddOrder(string[] userInput)
        {

            var repo = new MockFloorRepository();

            var response = new Response();

            Order tempOrder = new Order();

            string[] nameSplit = userInput[0].Split(' ');

            _currentOrder.FirstName = nameSplit[0];
            _currentOrder.LastName = nameSplit[1];
            _currentOrder.StateAbbr = userInput[1];
            
            int orderArea;
            if (!int.TryParse(userInput[3], out orderArea))
            {
                response.Success = false;
                response.Message = "The area {0} is not a number!";
                return response;
            }
            if (orderArea < 0)
            {
                response.Success = false;
                response.Message = "Please enter a positive number for area!";
                return response;
            }
            _currentOrder.OrderArea = orderArea;
            

            return response;
        }

        private decimal CalculateTax(Product p, int area)
        {
            
        }
    }
}
