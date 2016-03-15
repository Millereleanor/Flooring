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
       // Dictionary<date,string> orders = new Dictionary<date,string>();

        //creat a dictionary using the key==date from the data file


        //get dictionary list 
                //group by date then print out orderinfo

        public Order CreateOrder(DateTime date, Order order)
        {
            throw new NotImplementedException();
        }

        public Dictionary<DateTime, List<Order>> GetAllOrders()
        {
            throw new NotImplementedException();
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

        public void RemoteOrder(DateTime date, int orderId)
        {
            throw new NotImplementedException();
        }

        public void WriteToFile(Dictionary<DateTime, Order> Order)
        {
            throw new NotImplementedException();
        }
    }

    
}
