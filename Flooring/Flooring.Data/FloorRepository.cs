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


            //todo:how do i write the date as the file name;
            //check if file exit
            //if not then make new one
            //if yes then update file  to a new line

            var reader = File.ReadAllLines(filePath);
            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var newOrder = new Order();
               

                newOrder.OrderNumber = int.Parse(columns[0]);
                newOrder.OrderArea = int.Parse(columns[7]);
                //Name = columns[2];
                newOrder.ProductType = columns[6];
                newOrder.StateAbbr = columns[3];
                newOrder.StateFull = columns[4];
                newOrder.CostperSqFt = decimal.Parse(columns[8]);
                newOrder.LaborperSqFt = decimal.Parse(columns[9]);
                newOrder.TaxRate = decimal.Parse(columns[5]);
                //newOrder.TaxTotal = decimal.Parsecolumns[10];
                //newOrder.Total = columns[11];
                

                //do this with dictinary
                //Order.Add(Order);
            }
            return Order;
        }


    }
    

    //refrence from banking app.....
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
