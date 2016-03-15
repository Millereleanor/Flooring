using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models;

namespace Flooring.Data
{
    public class FloorRepository : IFloorRepository
    {
        Dictionary<DateTime, List<Order>> orders = new Dictionary<DateTime, List<Order>>();
        //should used dictionary??
        //get file name??
        public FloorRepository()
        {
            ReadOrders();
        }

        private void ReadOrders()
        {
            //todo: Read directory, get all FIles, Match contains 'Order_.txt'
            //todo: Parse out date from file name
            //todo: read file
            string filePath = ConfigurationManager.AppSettings["FileName"];




            var reader = File.ReadAllLines(filePath);
            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var newOrder = new Order();
                string Name = columns[1];
                string[] nameParts = Name.Split(' ');
                newOrder.FirstName = nameParts[0];
                newOrder.LastName = nameParts[1];

                newOrder.OrderNumber = int.Parse(columns[0]);
                newOrder.OrderArea = int.Parse(columns[6]);
                newOrder.ProductType = columns[5];
                newOrder.StateAbbr = columns[2];
                newOrder.StateFull = columns[3];
                newOrder.CostperSqFt = decimal.Parse(columns[7]);
                newOrder.LaborperSqFt = decimal.Parse(columns[8]);
                newOrder.TaxRate = decimal.Parse(columns[4]);

                //todo:randall wtf whyyyyyyyyyy?
                //newOrder.TaxTotal = decimal.Parse(columns[9]);
                newOrder.OrderTotal = decimal.Parse(columns[10]);


                orders.Add(DateTime.Parse("01/14/1992"),newOrder);
            }
        }

        public Order CreateOrder(DateTime date, Order order)
        {
            throw new NotImplementedException();
        }

        Dictionary<DateTime, List<Order>> IFloorRepository.GetAllOrders()
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

        public void RemoveOrder(DateTime date, int orderId)
        {
            throw new NotImplementedException();
        }

        public Dictionary<DateTime, Order> GetAllOrders()
        {


            return orders;
        }

        //dictionary???
        public void WriteToFile(Dictionary<DateTime, Order> Order)
        {
            string filePath = ConfigurationManager.AppSettings["FileName"];
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                {
                    writer.WriteLine("");

                    foreach (var order in Order)
                    {
                        // writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", order, order.OrderArea, order.OrderDate);
                    }
                }
                //    }
            }
        }
    }
}

//todo:how do i write the date as the file name;
    //check if file exit
    //if not then make new one
    //if yes then update file  to a new line
    //do this with dictinary...
    //Order.Add(Order);

//refrence from banking app.....


