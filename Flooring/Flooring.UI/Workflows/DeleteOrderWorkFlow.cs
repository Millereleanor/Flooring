using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.BLL.OrderOperations;
using Flooring.Models;

namespace Flooring.UI.Workflows
{
    class DeleteOrderWorkFlow
    {
        private OrderOperations op;

        public DeleteOrderWorkFlow()
        {
            op = MainMenuDisplay.GetOps();
        }
        public void DeleteOrder()
        {
            DisplayOrderWorkflow disp = new DisplayOrderWorkflow();
            var Date = disp.GetOrderDateFromUser();

            if (Date == DateTime.MinValue)
            {
                return;
            }

            var OrderNumber = disp.GetOrderNumberFromUser();

            if (OrderNumber == -1)
            {
                return;
            }
            Response response = op.GetSpecificOrder(OrderNumber, Date);
            PrintOrderInformation(response);

            if (response.Success)
            {
                Console.Write("Are you sure you want to delete this order? (Y/N): ");
                string input = Console.ReadLine();
                if (input.ToUpper() == "Y")
                {
                    op.DeleteOrder(OrderNumber, Date);
                    Console.WriteLine("Order succesfully deleted. Press enter to continue...");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    Console.WriteLine("Order Not Deleted!");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    return;
                }
            }

            Console.ReadLine();


        }

        public void PrintOrderInformation(Response response)
        {
            Console.Clear();
            if (response.Success)
            {
                Console.WriteLine("Order Date: {0}", response.OrderInfo.OrderDate.ToShortDateString());
                Console.WriteLine("{0} order(s) found on this date. ", response.OrderList.Count);
                Console.WriteLine("******************************************************");
                Console.WriteLine();
                foreach (var order in response.OrderList)
                {


                    Console.WriteLine();
                    Console.WriteLine("ORDER INFORMATION: ");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("=====================================");
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("ORDER NUMBER: ");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("{0}", order.OrderNumber);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("CUSTOMER NAME: ");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("{0},{1}", order.LastName, order.FirstName);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("ORDER STATE: ");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("{0} ({1})", order.StateAbbr, order.StateFull);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("                STATE TAX RATE: ");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("{0:P}", order.TaxRate);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("PRODUCT TYPE: ");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("{0}", order.ProductType);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("               ORDER AREA: ");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("{0:F}", order.OrderArea);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("MATERIAL COST PER Ft^2: ");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("{0:C}", order.CostperSqFt);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("            LABOR COST PER Ft^2: ");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("{0:C}");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("ORDER TOTAL: ");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("{0:C}", order.OrderTotal + order.TaxTotal);
                    Console.WriteLine();
                    Console.ForegroundColor=ConsoleColor.DarkCyan;

                }
            }
            else
            {
                Console.WriteLine(response.Message);
                Console.WriteLine("Press enter to continue.");
            }
        }
    }
}