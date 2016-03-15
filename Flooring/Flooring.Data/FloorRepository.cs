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
    public class FloorRepository
    {
        //todo:convert this to dictionary version

        public Dictionary<DateTime, Order> Decode()
        {
            Dictionary<DateTime, Order> order = new Dictionary<DateTime, Order>();

            string filePath = ConfigurationManager.AppSettings["FileName"];

            var reader = File.ReadAllLines(filePath);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var newOrder = new Order();
                var Name = newOrder.FirstName + " " + newOrder.LastName;
                
                newOrder.OrderNumber = int.Parse(columns[0]);
                newOrder.OrderArea = int.Parse(columns[6]);
                Name = columns[2];
                newOrder.ProductType;
                newOrder.
                //order. = decimal.Parse(columns[3]);

                Order.Add(Order);
            }
            return Order;
        }


    }
    //private static List<Orders> Decode()
    //{
    //    List<Orders> orders = new List<Account>();
    //    string filePath = ConfigurationManager.AppSettings["FileName"];

    //    var reader = File.ReadAllLines(filePath);

    //    for (int i = 1; i < reader.Length; i++)
    //    {
    //        var columns = reader[i].Split(',');
    //        var order = new Order();
    //        order.OrderNumber = int.Parse(columns[0]);
    //        order.FirstName = columns[1];
    //        order.LastName = columns[2];
    //        //order. = decimal.Parse(columns[3]);

    //        Orders.Add(Order);
    //    }
    //    return Orders;
    //}

    //public void WriteToFile(List<Order> orders)
    //{
    //    string filePath = ConfigurationManager.AppSettings["FileName"];
    //    using (StreamWriter writer = new StreamWriter(filePath, false))
    //    {
    //        {
    //            writer.WriteLine("");

    //            foreach (var order in orders)
    //            {
    //                writer.WriteLine("{0},{1},{2},{3}", order.OrderNumber,order.OrderArea,order.OrderDate);
    //            }
    //        }
    ////    }
    //}
}
}
