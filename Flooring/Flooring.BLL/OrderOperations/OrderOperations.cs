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
        private ErrorRepository errors;

        public OrderOperations(DateTime orderDate)
        {
            repo = new FloorRepository();
            errors = new ErrorRepository();
        }
        public Response GetOrders(DateTime date)
        {

            var response = new Response();
            response.OrderList = new List<Order>();
            var orders = repo.GetAllOrderByDate(date);

            if (orders.Count == 0)
            {
                response.Success = false;
                response.Message = String.Format("There were no orders on date {0}.", date.ToShortDateString());
                errors.LogError(response.Message);
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
            var repo = new FloorRepository();

            var response = new Response();
            response.OrderList = new List<Order>();
            response.OrderInfo = new Order();
            var orders = repo.GetAllOrderByDate(date);
            List<Order> orderList = new List<Order>();
            foreach (var order in orders)
            {
                if (order.OrderNumber == orderNumber)
                {
                    response.Success = true;
                    response.OrderInfo = order;
                    orderList.Add(order);
                    response.OrderList = orderList;
                    response.Message = String.Format("Here is the order information for order {0}.\n" +
                                                     "This order was placed on {1}",orderNumber, date.ToShortDateString());
                    return response;
                }
            }
            response.Message = String.Format("Order {0} does not exist on {1}.",orderNumber,date.ToShortDateString());
            response.Success = false;
            errors.LogError(response.Message);
            return response;
        }

        public Response AddOrder(string userInput)
        {

            var repo = new FloorRepository();

            var response = new Response();
            response.OrderList = new List<Order>();
            response.OrderInfo = new Order();
            Order tempOrder = new Order();

            string[] inputSplit = userInput.Split(',');

            tempOrder.FirstName = inputSplit[0];
            tempOrder.LastName = inputSplit[1];

            int orderArea;
            if (!int.TryParse(inputSplit[4], out orderArea))
            {
                response.Success = false;
                response.Message = String.Format("The area {0} is not a number!", inputSplit[4]);
                errors.LogError(response.Message);
                return response;
            }
            if (orderArea < 0)
            {
                response.Success = false;
                response.Message = "Please enter a positive number for area!";
                errors.LogError(response.Message);
                return response;
            }
            tempOrder.OrderArea = orderArea;
            
            Product p = GetProduct(inputSplit[3]);
            tempOrder.ProductType = p.ProductType;
            tempOrder.CostperSqFt = p.CostperSqFt;
            tempOrder.LaborperSqFt = p.LaborperSqFt;

            State s = GetState(inputSplit[2]);
            tempOrder.StateAbbr = s.Abbr;
            tempOrder.StateFull = s.FullName;
            tempOrder.TaxRate = s.TaxRate;
            tempOrder.OrderDate = DateTime.Today;

            //if (repo.DictionaryContainsKey(tempOrder.OrderDate)) //fix this
            //{
            //    tempOrder.OrderNumber = 1;
            //}
            //else
            //{
            //    tempOrder.OrderNumber = (repo.GetAllOrderByDate(tempOrder.OrderDate).Count) + 1;
            //}

            repo.CreateOrder(tempOrder);

            return response;
        }

        public Response EditOrder(DateTime date, int orderNumber, string newOrder)
        {
            Response oldOrderResponse = GetSpecificOrder(orderNumber, date);
            if (oldOrderResponse.Success == false)
            {
                return oldOrderResponse;
            }

            Order savedOrder = oldOrderResponse.OrderInfo;

            var repo = new FloorRepository();

            var response = new Response();
            response.OrderList = new List<Order>();
            response.OrderInfo = new Order();
            var tempOrder = PopulateOrder(newOrder);

            if (tempOrder == null)
            {
                response.Success = false;
                response.Message = String.Format("Please enter a posivie number for the area.");
                errors.LogError(response.Message);
                return response;
            }

            if (tempOrder.FirstName == "")
            {
                tempOrder.FirstName = savedOrder.FirstName;
            }
            if (tempOrder.LastName == "")
            {
                tempOrder.LastName = savedOrder.LastName;
            }
            if (tempOrder.StateAbbr == "")
            {
                tempOrder.StateAbbr = savedOrder.StateAbbr;
                tempOrder.StateFull = savedOrder.StateFull;
                tempOrder.TaxRate = savedOrder.TaxRate;
            }
            else
            {
                State s = GetStateByAbbr(tempOrder.StateAbbr);
                tempOrder.StateFull = s.FullName;
                tempOrder.TaxRate = s.TaxRate;
            }
            if (tempOrder.ProductType == "")
            {
                tempOrder.ProductType = savedOrder.ProductType;
                tempOrder.CostperSqFt = savedOrder.CostperSqFt;
                tempOrder.LaborperSqFt = savedOrder.LaborperSqFt;
            }
            else
            {
                Product p = GetProductByType(tempOrder.ProductType);
                tempOrder.ProductType = p.ProductType;
                tempOrder.CostperSqFt = p.CostperSqFt;
                tempOrder.LaborperSqFt = p.LaborperSqFt;
            }
            if (tempOrder.OrderArea == 0)
            {
                tempOrder.OrderArea = savedOrder.OrderArea;
            }

            tempOrder.OrderNumber = savedOrder.OrderNumber;
            tempOrder.OrderDate = savedOrder.OrderDate;
            

            repo.UpdateOrder(date, tempOrder.OrderNumber, tempOrder);
            response.Success = true;
            response.Message = String.Format("Order {0} placed on {1} was updated.", tempOrder.OrderNumber,
                tempOrder.OrderDate);
            response.OrderInfo = tempOrder;
            return response;
        }

        public Response DeleteOrder(int orderNumber, DateTime date)
        {
            var repo = new FloorRepository();

            var response = new Response();
            response.OrderList = new List<Order>();
            response.OrderInfo = new Order();

            var orders = repo.GetAllOrderByDate(date);
            List<Order> orderList = new List<Order>();
            if (orders.Count == 0)
            {
                response.Success = false;
                response.Message = String.Format("ERROR: There were already 0 orders on {0}", date.ToShortDateString());
                errors.LogError(response.Message);
                response.OrderList = orders;
                return response;
            }
            repo.RemoveOrder(date,orderNumber);
            response.Message = String.Format("Succesfully removed order {0} from {1}", orderNumber, date.ToShortDateString());
            response.Success = true;
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
                    p.ProductType = "";
                    p.CostperSqFt = 0m;
                    p.LaborperSqFt = 0m;
                    return p;
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
                    s.Abbr = "";
                    s.FullName = "";
                    s.TaxRate = 0m;
                    return s;
            }
        }

        private Product GetProductByType(string productType)
        {
            Product p = new Product();
            switch (productType)
            {
                case "Cherrywood Flooring":
                    p.ProductType = "Cherrywood Flooring";
                    p.CostperSqFt = 15.00m;
                    p.LaborperSqFt = 10.00m;
                    return p;
                case "Plush Carpet":
                    p.ProductType = "Plush Carpet";
                    p.CostperSqFt = 5.00m;
                    p.LaborperSqFt = 2.00m;
                    return p;
                case "Shiny Laminant":
                    p.ProductType = "Shiny Laminant";
                    p.CostperSqFt = 3.00m;
                    p.LaborperSqFt = 1.00m;
                    return p;
                case "Blingy Granite":
                    p.ProductType = "Blingy Granite";
                    p.CostperSqFt = 30.00m;
                    p.LaborperSqFt = 15.00m;
                    return p;
                default:
                    p.ProductType = "";
                    p.CostperSqFt = 0m;
                    p.LaborperSqFt = 0m;
                    return p;
            }
        }

        private State GetStateByAbbr(string state)
        {
            State s = new State();
            switch (state)
            {
                case "OH":
                    s.FullName = "Ohio";
                    s.Abbr = "OH";
                    s.TaxRate = .07m;
                    return s;
                case "FL":
                    s.FullName = "Florida";
                    s.Abbr = "FL";
                    s.TaxRate = .03m;
                    return s;
                case "IL":
                    s.FullName = "Illinois";
                    s.Abbr = "IL";
                    s.TaxRate = .09m;
                    return s;
                case "AK":
                    s.FullName = "Alaska";
                    s.Abbr = "AK";
                    s.TaxRate = .01m;
                    return s;
                default:
                    s.Abbr = "";
                    s.FullName = "";
                    s.TaxRate = 0m;
                    return s;
            }
        }

        private Order PopulateOrder(string orderInfo)
        {
            FloorRepository repo = new FloorRepository();
            string[] inputSplit = orderInfo.Split(',');
            Order tempOrder = new Order();
            tempOrder.FirstName = inputSplit[0];
            tempOrder.LastName = inputSplit[1];

            int orderArea;
            if (!int.TryParse(inputSplit[4], out orderArea))
            {
                if (inputSplit[4] != "")
                {
                    return null;
                }
            }
            if (orderArea < 0)
            {
                return null;
            }
            if (inputSplit[4] == "")
            {
                orderArea = -1;
            }
            tempOrder.OrderArea = orderArea;

            Product p = GetProduct(inputSplit[3]);
            tempOrder.ProductType = p.ProductType;
            tempOrder.CostperSqFt = p.CostperSqFt;
            tempOrder.LaborperSqFt = p.LaborperSqFt;

            State s = GetState(inputSplit[2]);
            
            tempOrder.StateAbbr = s.Abbr;
            tempOrder.StateFull = s.FullName;
            tempOrder.TaxRate = s.TaxRate;
            tempOrder.OrderDate = DateTime.Today;

            if (repo.DictionaryContainsKey(tempOrder.OrderDate))
            {
                tempOrder.OrderNumber = 1;
            }
            else
            {
                tempOrder.OrderNumber = (repo.GetAllOrderByDate(tempOrder.OrderDate).Count) + 1;
            }
            return tempOrder;
        }
    }
}