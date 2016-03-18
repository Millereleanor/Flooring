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

        //creat a dictionary using the key==date from the data file


        //get dictionary list 
                //group by date then print out orderinfo

        public Order CreateOrder(Order order)
        {
            orders[order.OrderDate].Add(order);
            return order;
        }

        public Dictionary<DateTime, List<Order>> GetAllOrders()
        {
            
        }

        public List<Order> GetAllOrderByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderByDateId(DateTime date, int orderId)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(DateTime date, int orderId, Order updateOrder)
        {
            throw new NotImplementedException();
        }

        public void RemoveOrder(DateTime date, int orderId)
        {
            throw new NotImplementedException();
        }
        
    }

    
}
