using Flooring.Data;
using Flooring.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
                response.Message = $"There were no orders on date {date.ToShortDateString()}.";
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
                    response.Message = $"Here is the order information for order {orderNumber}.\n" +
                                       $"This order was placed on {date.ToShortDateString()}";
                    return response;
                }
            }
            response.Message = $"Order {orderNumber} does not exist on {date.ToShortDateString()}.";
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
                response.Message = $"The area {inputSplit[4]} is not a number!";
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
            response.Message = $"Order {tempOrder.OrderNumber} placed on {tempOrder.OrderDate} was updated.";
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
                response.Message = $"ERROR: There were already 0 orders on {date.ToShortDateString()}";
                errors.LogError(response.Message);
                response.OrderList = orders;
                return response;
            }
            repo.RemoveOrder(date, orderNumber);
            response.Message = $"Succesfully removed order {orderNumber} from {date.ToShortDateString()}";
            response.Success = true;
            return response;
        }

        public List<string> GetStateNames()
        {
            ReadStateProduct readText = new ReadStateProduct();
            List<State> stateList = readText.GetStatefromTxt();

            return stateList.Select(state => state.FullName).ToList();
        }

        public List<Product> GetProductNames()
        {
            ReadStateProduct readText = new ReadStateProduct();
            return readText.GetProductfromTxt();
        }

        private Product GetProduct(string productType)
        {
            ReadStateProduct readText = new ReadStateProduct();
            List<Product> products = readText.GetProductfromTxt();

            Product p = new Product();

            for (int i = 1; i <= products.Count; i++)
            {
                if (i.ToString() == productType)
                {
                    p.ProductType = products[i - 1].ProductType;
                    p.CostperSqFt = products[i - 1].CostperSqFt;
                    p.LaborperSqFt = products[i - 1].LaborperSqFt;
                    return p;
                }
            }
            p.ProductType = "";
            p.CostperSqFt = 0m;
            p.LaborperSqFt = 0m;
            return p;
        }

        private State GetState(string state)
        {
            ReadStateProduct readText = new ReadStateProduct();
            List<State> states = readText.GetStatefromTxt();

            State s = new State();

            for (int i = 1; i <= states.Count; i++)
            {
                if (i.ToString() == state)
                {
                    s.FullName = states[i - 1].FullName;
                    s.Abbr = states[i - 1].Abbr;
                    s.TaxRate = states[i - 1].TaxRate;
                    return s;
                }
            }
            s.Abbr = "";
            s.FullName = "";
            s.TaxRate = 0m;
            return s;
        }

        private Product GetProductByType(string productType)
        {
            ReadStateProduct readText = new ReadStateProduct();
            List<Product> products = readText.GetProductfromTxt();

            Product p = new Product();

            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].ProductType == productType)
                {
                    p.ProductType = productType;
                    p.CostperSqFt = products[i].CostperSqFt;
                    p.LaborperSqFt = products[i].LaborperSqFt;
                    return p;
                }
            }
            p.ProductType = "";
            p.CostperSqFt = 0m;
            p.LaborperSqFt = 0m;
            return p;
        }

        private State GetStateByAbbr(string state)
        {
            ReadStateProduct readText = new ReadStateProduct();
            List<State> states = readText.GetStatefromTxt();

            State s = new State();

            foreach (State tempState in states)
            {
                if (tempState.Abbr == state)
                {
                    s.Abbr = tempState.Abbr;
                    s.FullName = tempState.FullName;
                    s.TaxRate = tempState.TaxRate;
                    return s;
                }
            }
            s.Abbr = "";
            s.FullName = "";
            s.TaxRate = 0m;
            return s;
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