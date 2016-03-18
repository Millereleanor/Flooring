using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
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
            var files = Directory.GetFiles(ConfigurationManager.AppSettings["FileName"], "Orders_*.txt",
                SearchOption.TopDirectoryOnly);
            foreach (string file in files)
            {
                ReadOrders(file);
            }
            
        }

        public FloorRepository(DateTime orderDate)
        {
            //ReadOrders(orderDate);
        }

        private void ReadOrders(string orderDate)   //Populates Dictionary Key DATE Value List<Orders>
        {
            // Read directory, get all FIles, Match contains 'Order_.txt'
            //Parse out date from file name
            // read file
            CultureInfo provider = CultureInfo.InvariantCulture;
            if (File.Exists(orderDate))
            {
                string fileName =orderDate;
                List<Order> orderList = new List<Order>();

                var reader = File.ReadAllLines(fileName);
                var file = Path.GetFileName(fileName);
                DateTime od = DateTime.ParseExact(file.Substring(7, 8),"MMddyyyy", provider);
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

                orders.Add(od, orderList);
            }

        }

        public Order CreateOrder(Order order)
        {
            //check if date exist
            //if yes update
            //if no create 
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
            this.WriteToFile(orders);

            return order;
        }

        private string GetPath(DateTime OrderDate)
        {
      
            string folderName = ConfigurationManager.AppSettings["FileName"];
            string fileName = folderName + "Orders_" + OrderDate.ToString("MMddyyyy") + ".txt";
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
            //ReadOrders(date);
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

            for (var i = 0; i < orders[date].Count; i++)
            {
                if (orders[date][i].OrderNumber == orderId)
                {
                    orders[date][i] = updateOrder;
                    break;
                }
            }
            WriteToFile(orders);
            //string oldOrder = orderToUpdate.ToString();
            //string newOrderInfo = updateOrder.ToString();
            //string file = GetPath(date);

            //for (int i = 0; i < oldOrder.Length; i++)
            //{
            //    if (oldOrder[i] != newOrderInfo[i])
            //    {
            //        File.
            //        //replace that info
            //    }
            //}


        
        }

        public void RemoveOrder(DateTime date, int orderId)
        {

            orders[date].Remove(orders[date].FirstOrDefault(o => o.OrderNumber == orderId));
            WriteToFile(orders);
           

            //what elle had before...
            //Order orderToRemove = GetOrderByDateId(date, orderId);
            //string orderToDeleat = orderToRemove.ToString();
            //string file = GetPath(date);

            //var linesInFile = File.ReadAllLines(file);
            //var keepLines = linesInFile.Where(line => !line.Contains(orderToDeleat));
            //File.WriteAllLines(file, keepLines);
            
            //if (keepLines.Count() <= 1)
            //{
            //    File.Delete(file);
            //}
         

        }

        public Dictionary<DateTime, Order> GetAllOrders()
        {
            //todo:take this out its a duplicate
            return null;
            //return orders;
        }

        //dictionary???
        public void WriteToFile(Dictionary<DateTime, List<Order>> Order)
        {



            foreach (var key in orders.Keys)
            {

                string fileName = GetPath(key);
                TextWriter tw = new StreamWriter(fileName);
                tw.WriteLine(
                            "OrderNumber,Customer Name,State Abbreviation,State Name,TaxRate,Product type, Area, Cost/SQFT,Labor Cost/SQFT,Tax,and total");
                foreach (Order order in orders[key])
                {
                    
                    tw.WriteLine(order.ToString());

                }
                tw.Close();
            }

        }
    }
}

