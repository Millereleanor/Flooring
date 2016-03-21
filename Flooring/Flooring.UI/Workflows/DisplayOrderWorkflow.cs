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
        public int OrderNumber;
        private string _dateoforder;
        private OrderOperations ops;

        public DisplayOrderWorkflow()
        {
            ops = MainMenuDisplay.GetOps();
        }
        public void Execute()
        {
            DateTime Date = GetOrderDateFromUser();
            if (Date == DateTime.MinValue)
            {
                return;
            }
            DisplayOrderbyDate(Date);


        }

        public DateTime GetOrderDateFromUser() //fix q
        {
            do
            {
                Console.Clear();
                Console.Write("Please enter the order date(MM/DD/YY or MM-DD-YY) or \"Q\" to quit: ");
                _dateoforder = Console.ReadLine();
                if (_dateoforder.ToUpper() == "Q")
                {
                    return DateTime.MinValue;
                }
                if (DateTime.TryParse(_dateoforder, out Date))
                {
                    return Date;
                }
                if (_dateoforder.ToUpper() == "Q")
                {
                    MainMenuDisplay mm = new MainMenuDisplay();
                    mm.Display();
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
                if (numberoforder.ToUpper() == "Q")
                {
                    return -1;
                }

                if (int.TryParse(numberoforder, out OrderNumber))
                {
                    return OrderNumber;
                }
                Console.WriteLine("That is not a valid order number");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            } while (true);
        }

        public void DisplayOrderbyDate(DateTime Date)
        {
            var getOrdersResponse = ops.GetOrders(Date);


            if (getOrdersResponse.Success)
            {         
                PrintOrderInformation(getOrdersResponse);
            }
            else
            {
                Console.WriteLine("Error: ");
                Console.WriteLine(getOrdersResponse.Message);
                Console.WriteLine("Move along...");
                Console.ReadLine();
            }
        }

        public void DisplayOrderbyDateID(DateTime Date, int orderNumber)
        {
            var response = ops.GetSpecificOrder(orderNumber, Date);


            if (response.Success)
            {
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
                Console.ForegroundColor=ConsoleColor.DarkBlue;
                Console.WriteLine("=====================================");
                Console.BackgroundColor=ConsoleColor.Gray;
                Console.ForegroundColor=ConsoleColor.Black;
                Console.Write("ORDER NUMBER: ");   
                Console.ForegroundColor=ConsoleColor.DarkMagenta;
                Console.WriteLine("{0}",order.OrderNumber);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("CUSTOMER NAME: ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine( "{0},{1}", order.LastName, order.FirstName);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("ORDER STATE: ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("{0} ({1})", order.StateAbbr,order.StateFull);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("                STATE TAX RATE: ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("{0:P}", order.TaxRate);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("PRODUCT TYPE: ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("{0}",order.ProductType);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("               ORDER AREA: ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("{0:F}",order.OrderArea);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("MATERIAL COST PER Ft^2: ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("{0:C}",order.CostperSqFt);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("            LABOR COST PER Ft^2: ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("{0:C}");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("ORDER TOTAL: ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("{0:C}",order.OrderTotal+order.TaxTotal);
                Console.WriteLine();
           


            }
            
            Console.WriteLine("Please press enter to continue...");
            Console.ReadLine();
            Console.BackgroundColor= ConsoleColor.Gray;
            Console.ForegroundColor=ConsoleColor.DarkCyan;
            Console.Clear();
        }

       
    }
}