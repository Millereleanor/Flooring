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


        public FloorRepository()
        {
            ReadOrders();
        }

        private void ReadOrders()   //Populates Dictionary Key DATE Value List<Orders>
        {
            //todo: Read directory, get all FIles, Match contains 'Order_.txt'
            //todo: Parse out date from file name
            //todo: read file
            string filePath = ConfigurationManager.AppSettings["FileName"];

            List<Order> orderList = new List<Order>();

            var reader = File.ReadAllLines(filePath);
            for (int i = 1; i < reader.Length; i++)
            {
                var newOrder = new Order();
                var columns = reader[i].Split(',');


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
                orderList.Add(newOrder);

                //newOrder.TaxTotal = decimal.Parse(columns[9]);
                //newOrder.OrderTotal = decimal.Parse(columns[10]);
            }

            orders.Add(DateTime.Parse("01/14/1992"), orderList);

        }

        public Order CreateOrder(Order order)
        {
            //check if date exist
            //if yes update
            //if no create 

            int month = order.OrderDate.Month;
            string monthString = order.OrderDate.Month.ToString();
            if (month <= 9)
            {
                monthString = "0" + month;
            }
            int day = order.OrderDate.Day;
            string dayString = order.OrderDate.Day.ToString();
            if (day <= 9)
            {
                dayString = "0" + day;
            }

            String fileName = "Orders_" + monthString + dayString + order.OrderDate.Year + ".txt";
            
            if (File.Exists(fileName) == true)
            {
                //add to txt
                TextWriter tw = new StreamWriter(fileName);
                tw.WriteLine("{0},{1},{2} {3},{4},{5},{6},{7},{8},{9},{10},{11}", 
                    order.OrderNumber, order.FirstName, order.LastName, order.StateAbbr, order.StateFull,
                    order.TaxRate, order.ProductType, order.OrderArea, order.CostperSqFt, order.LaborperSqFt, order.TaxTotal, order.OrderTotal);
                tw.Close();
            }
            //creat new txt
            if (!File.Exists(fileName)) 
            {
                File.Create(fileName);
                TextWriter tw = new StreamWriter(fileName);
                tw.WriteLine("{0},{1},{2} {3},{4},{5},{6},{7},{8},{9},{10},{11}",order.OrderNumber,order.FirstName,order.LastName,order.StateAbbr,order.StateFull,order.TaxRate,order.ProductType,order.OrderArea,order.CostperSqFt,order.LaborperSqFt,order.TaxTotal,order.OrderTotal);
                tw.Close();
            }
            return null;
        }

        Dictionary<DateTime, List<Order>> IFloorRepository.GetAllOrders()
        {
            //find all txt files
            //run ReadOrders() for all the txt files
            //display files based on catigory of date
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
            throw new NotImplementedException();
        }

        public void UpdateOrder(DateTime date, int orderId, Order updateOrder)
        {
            //need test will it mess up
            //var order = GetAllOrderByDate(date);
            //for (int i = 0; i < order.Count; i++)
            //{
            //    if()
            //}
        }

        public void RemoveOrder(DateTime date, int orderId)
        {

            //deleat file
            throw new NotImplementedException();
        }

        public Dictionary<DateTime, Order> GetAllOrders()
        {

            return null;
            //return orders;
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


