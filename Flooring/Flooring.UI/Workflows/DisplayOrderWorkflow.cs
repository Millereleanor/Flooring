using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Flooring.BLL.OrderOperations;
using Flooring.Models;

namespace Flooring.UI.Workflows
{
    public class DisplayOrderWorkflow
    {
        public DateTime Date;
        public int orderNumber;
        private Order _currentOrder;
       
        public void Execute()
        {
            DateTime Date = GetOrderDateFromUser();
            
            DisplayOrderbyDate(Date);


        }

        public DateTime GetOrderDateFromUser()
        {
            do
            {
                Console.Clear();
                Console.Write("Please enter the order date(MM/DD/YYYY or MM-DD-YYYY): ");
                string dateoforder = Console.ReadLine();

                if (DateTime.TryParse(dateoforder, out Date))
                {
                    return Date;
                }
                Console.WriteLine("That is not a valid date");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            } while (true);
        }

        public int GetOrderNumberFromUser()
        {
            do
            {
                Console.Clear();
                Console.Write("Please enter the order number: ");
                string numberoforder = Console.ReadLine();

                if (int.TryParse(numberoforder, out orderNumber))
                {
                    return orderNumber;
                }
                Console.WriteLine("That is not a valid order number");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            } while (true);
        }

        public void DisplayOrderbyDate(DateTime Date)
        {
            var ops = new OrderOperations(Date);
            var response = ops.GetOrders(Date);


            if (response.Success)
            {
                _currentOrder = response.OrderInfo;
                
                
                PrintOrderInformation(response);

            }
            else
            {
                Console.WriteLine("Error: ");
                Console.WriteLine(response.Message);
                Console.WriteLine("Move along...");
                Console.ReadLine();
            }
        }

        public void DisplayOrderbyDateID(DateTime Date, int orderNumber)
        {
            var ops = new OrderOperations(Date);
            var response = ops.GetSpecificOrder(orderNumber, Date);


            if (response.Success)
            {
                _currentOrder = response.OrderInfo;
                PrintOrderInformation(response);

            }
            else
            {
                Console.WriteLine("Error: ");
                Console.WriteLine(response.Message);
                Console.WriteLine("Move along...");
                Console.ReadLine();
            }
        }


        private static Random _randomColor = new Random();

        private static ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(_randomColor.Next(0, 5));
        }

        public void PrintOrderInformation(Response response)
        {
            
            Console.Clear();
            Console.WriteLine("Order Date: {0}", Date.ToShortDateString());
            Console.WriteLine("{0} order(s) found on this date. ",response.OrderList.Count);
            Console.WriteLine("******************************************************");
            Console.WriteLine();
            foreach (var order in response.OrderList)
            {
                Console.ForegroundColor = GetRandomConsoleColor();
                
                Console.WriteLine();
                Console.WriteLine("ORDER INFORMATION: ");
                Console.WriteLine("=====================================");
                Console.WriteLine("ORDER NUMBER: {0}", order.OrderNumber);
                Console.WriteLine("CUSTOMER NAME: {0},{1}", order.LastName, order.FirstName);
                Console.WriteLine("ORDER STATE: {0} ({1})          STATE TAX RATE: {2:P}",
                    order.StateAbbr, order.StateFull, order.TaxRate);
                Console.WriteLine("PRODUCT TYPE: {0}                  ORDER AREA: {1}", order.ProductType, order.OrderArea);
                Console.WriteLine("MATERIAL COST PER Ft^2: {0}        LABOR COST PER Ft^2: {1}",
                    order.CostperSqFt, order.LaborperSqFt);
                Console.WriteLine("ORDER TOTAL: {0:C}", 
                    order.OrderTotal+order.TaxTotal);
                Console.WriteLine();
                
                
            }
            
            Console.WriteLine("Please press enter to continue...");
            Console.ReadLine();
            Console.ResetColor();
            Console.Clear();
        }


    }
}
