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
        private Order workingOrder = new Order();

        public FloorRepository()
        {
            //ReadOrders();
        }

        public FloorRepository(DateTime orderDate)
        {
            //ReadOrders(orderDate);
        }

        private void ReadOrders(DateTime orderDate)   //Populates Dictionary Key DATE Value List<Orders>
        {
            //todo: Read directory, get all FIles, Match contains 'Order_.txt'
            //todo: Parse out date from file name
            //todo: read file

            if (File.Exists(GetPath(orderDate)))
            {
                string fileName = GetPath(orderDate);
                List<Order> orderList = new List<Order>();

                var reader = File.ReadAllLines(fileName);
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

                orders.Add(orderDate, orderList);
            }
        }

        public Order CreateOrder(Order order)
        {
            //check if date exist
            //if yes update
            //if no create 

            string fileName = GetPath(order.OrderDate);

            if (File.Exists(fileName))
            {
                //add to txt
                TextWriter tw = new StreamWriter(fileName, true);
                //can make toString()
                tw.WriteLine("{0},{1} {2},{3},{4},{5},{6},{7},{8},{9},{10},{11}",
                    order.OrderNumber, order.FirstName, order.LastName, order.StateAbbr, order.StateFull,
                    order.TaxRate, order.ProductType, order.OrderArea, order.CostperSqFt, order.LaborperSqFt, order.TaxTotal, order.OrderTotal);
                tw.Close();
            }
            //creat new txt
            if (!File.Exists(fileName))
            {
                TextWriter tw = new StreamWriter(fileName);
                tw.WriteLine("OrderNumber,Customer Name,State Abbreviation,State Name,TaxRate,Product type, Area, Cost/SQFT,Labor Cost/SQFT,Tax,and total");
                //can make todString()
                tw.WriteLine("{0},{1} {2},{3},{4},{5},{6},{7},{8},{9},{10},{11}",
                    order.OrderNumber, order.FirstName, order.LastName, order.StateAbbr, order.StateFull,
                    order.TaxRate, order.ProductType, order.OrderArea, order.CostperSqFt, order.LaborperSqFt, order.TaxTotal, order.OrderTotal);
                tw.Close();
            }
            return null;
        }

        private string GetPath(DateTime OrderDate)
        {
            int month = OrderDate.Month;
            string monthString = OrderDate.Month.ToString();
            if (month <= 9)
            {
                monthString = "0" + month;
            }
            int day = OrderDate.Day;
            string dayString = OrderDate.Day.ToString();
            if (day <= 9)
            {
                dayString = "0" + day;
            }
            string folderName = ConfigurationManager.AppSettings["FileName"];
            string fileName = folderName + "Orders_" + monthString + dayString + OrderDate.Year + ".txt";
            return fileName;
        }

        public bool DictionaryContainsKey(DateTime orderDate)
        {
            if (orders.ContainsKey(orderDate))
            {
                return true;
            }
            return false;
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
            ReadOrders(date);
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
            return null;
        }

        public void UpdateOrder(DateTime date, int orderId, Order updateOrder)
        {
            Order orderToUpdate = GetOrderByDateId(date, orderId);
            //take old order and convert to string
            //take each spot in oreder and check if they are the same
            //string oldOrder = order
            return;
            ////need test will it mess up
            //var orderlist = GetAllOrderByDate(date);
            //for (int i = 0; i < orderlist.Count ; i++)
            //{
            //    if (orderlist[i].OrderNumber == orderId)
            //    {
            //        //write there input to file
            //        if ()
            //        {

            //        }
            //        break;
            //    }
            //}
        }

        public void RemoveOrder(DateTime date, int orderId)
        {
            //todo:may not work
            Order orderToRemove = GetOrderByDateId(date,orderId);
            string orderToDeleat = orderToRemove.ToString();
            string file = GetPath(date);

            var linesInFile = File.ReadAllLines(file);
            var keepLines = linesInFile.Where(line => !line.Contains(orderToDeleat));
            File.WriteAllLines(file,keepLines);
            //file .close?????
            if (keepLines.Count() <= 1)
            {
             File.Delete(file);   
            }
        }

        public Dictionary<DateTime, Order> GetAllOrders()
        {
            //todo:take this out its a duplicate
            return null;
            //return orders;
        }

        //dictionary???
        public void WriteToFile(Dictionary<DateTime, Order> Order)
        {

            //todo:take out interface???

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


