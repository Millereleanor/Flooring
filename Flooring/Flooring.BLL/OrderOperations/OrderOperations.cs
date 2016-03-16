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
        private IFloorRepository repo;

        public OrderOperations()
        {
            repo = new FloorRepository();

        }
        public Response GetOrders(DateTime date)
        {

            var response = new Response();
            
            var orders = repo.GetAllOrderByDate(date);

            if (orders == null)
            {
                response.Success = false;
                response.Message = String.Format("There were no orders on date {0}.", date.ToShortDateString());
            }
            else
            {
                response.Success = true;
                response.OrderList = orders;
            }

            return response;
        }

        public Response GetSpecificOrder(int orderNumber, DateTime date)
        {
            var repo = new MockFloorRepository();

            var response = new Response();

            var orders = repo.GetAllOrderByDate(date);

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

        public Response AddOrder(string userInput)
        {

            var repo = new FloorRepository();

            var response = new Response();

            Order tempOrder = new Order();

            string[] inputSplit = userInput.Split(',');

            _currentOrder.FirstName = inputSplit[0];
            _currentOrder.LastName = inputSplit[1];

            int orderArea;
            if (!int.TryParse(inputSplit[4], out orderArea))
            {
                response.Success = false;
                response.Message = String.Format("The area {0} is not a number!", inputSplit[4]);
                return response;
            }
            if (orderArea < 0)
            {
                response.Success = false;
                response.Message = "Please enter a positive number for area!";
                return response;
            }
            _currentOrder.OrderArea = orderArea;
            
            Product p = GetProduct(inputSplit[3]);
            _currentOrder.ProductType = p.ProductType;
            _currentOrder.CostperSqFt = p.CostperSqFt;
            _currentOrder.LaborperSqFt = p.LaborperSqFt;

            State s = GetState(inputSplit[2]);
            _currentOrder.StateAbbr = s.Abbr;
            _currentOrder.StateFull = s.FullName;
            _currentOrder.TaxRate = s.TaxRate;

            _currentOrder.OrderNumber = repo.GetAllOrders().Count + 1;
            _currentOrder.OrderDate = DateTime.Today;


            return response;
        }

        private Product GetProduct(string productType)
        {
            Product p = new Product();
            switch (productType)
            {
                case "1":
                    p.ProductType="Cherrywood Flooring";
                    p.CostperSqFt = 15.00m;
                    p.LaborperSqFt = 10.00m;
                    return p;
                case "2":
                    p.ProductType="Plush Carpet";
                    p.CostperSqFt = 5.00m;
                    p.LaborperSqFt = 2.00m;
                    return p;
                case "3":
                    p.ProductType="Shiny Laminant";
                    p.CostperSqFt = 3.00m;
                    p.LaborperSqFt = 1.00m;
                    return p;
                case "4":
                    p.ProductType="Blingy Granite";
                    p.CostperSqFt = 30.00m;
                    p.LaborperSqFt = 15.00m;
                    return p;
                default:
                    return null;
            }
        }

        private State GetState(string state)
        {
            State s = new State();
            switch (state)
            {
                case "1":
                    s.FullName = "Ohio";
                    s.Abbr = "OH";
                    s.TaxRate = .07m;
                    return s;
                case "2":
                    s.FullName = "Florida";
                    s.Abbr = "FL";
                    s.TaxRate = .03m;
                    return s;
                case "3":
                    s.FullName = "Illinois";
                    s.Abbr = "IL";
                    s.TaxRate = .09m;
                    return s;
                case "4":
                    s.FullName = "Alaska";
                    s.Abbr = "AK";
                    s.TaxRate = .01m;
                    return s;
                default:
                    return null;
            }
        }

        //private decimal CalculateCost(Product p, int area)
        //{
        //    return (p.CostperSqFt * area) + p.LaborperSqFt * area;
        //}

        //private decimal CalculateTax(decimal total, State state)
        //{
        //    return total * state.TaxRate;
        //}
    }
}
