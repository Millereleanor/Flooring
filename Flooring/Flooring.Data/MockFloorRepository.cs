using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models;

namespace Flooring.Data
{
    public class MockFloorRepository : IFloorRepository
    {
        private Dictionary<DateTime,List<Order>> orders = new Dictionary<DateTime,List<Order>>();

        public MockFloorRepository()
        {
            MockOrders mockOrders = new MockOrders();
            List<Order> orderList = mockOrders.LoadOrders();
            foreach (var order in orderList)
            {
                if (orders.ContainsKey(order.OrderDate))
                {
                    if (!orders[order.OrderDate].Contains(order))
                    {
                        orders[order.OrderDate].Add(order);
                    }
                }
                else
                {
                    orders.Add(order.OrderDate, new List<Order>() {order});
                }
            }
        }

        public Order CreateOrder(Order order)
        {
            if (orders.ContainsKey(order.OrderDate))
            {
                int nextId = orders[order.OrderDate].Max(O => O.OrderNumber);
                nextId++;
                order.OrderNumber = nextId;
                orders[order.OrderDate].Add(order);
            }
            else
            {
                order.OrderNumber = 1;
                orders.Add(order.OrderDate, new List<Order>() { order });
            }
            return order;
        }

        public bool DictionaryContainsKey(DateTime orderDate)
        {
            if (orders.ContainsKey(orderDate))
            {
                return true;
            }
            return false;
        }

        public Dictionary<DateTime, List<Order>> GetAllOrders()
        {
            return orders;
        }

        public List<Order> GetAllOrderByDate(DateTime date)
        {
            if (orders.ContainsKey(date))
            {
                return orders[date];
            }
            return new List<Order>();
        }

        public Order GetOrderByDateId(DateTime date, int orderId)
        {
            List<Order> orders = GetAllOrderByDate(date);
            var results = from o in orders
                          select o;


            foreach (var result in results)
            {
                if (result.OrderNumber == orderId)
                {
                    return result;
                }
            }
            return null;//why null?
        }

        public void UpdateOrder(DateTime date, int orderId, Order updateOrder)
        {
            for (var i = 0; i < orders[date].Count; i++)
            {
                if (orders[date][i].OrderNumber == orderId)
                {
                    orders[date][i] = updateOrder;
                    break;
                }
            }
        }

        public void RemoveOrder(DateTime date, int orderId)
        {
            orders[date].Remove(orders[date].FirstOrDefault(o => o.OrderNumber == orderId));
        }
    }
}
