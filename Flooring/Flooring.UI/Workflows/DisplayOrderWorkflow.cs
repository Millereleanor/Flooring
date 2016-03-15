using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.BLL.OrderOperations;
using Flooring.Models;

namespace Flooring.UI.Workflows
{
    public class DisplayOrderWorkflow
    {
        public DateTime Date;
        private Order _currentOrder;
       
        public void Execute()
        {
            DateTime Date = GetOrderDateFromUser();
            DisplayOrderbyDate(Date);


        }

        private DateTime GetOrderDateFromUser()
        {
            do
            {
                Console.Clear();
                Console.Write("Please enter the order date: ");
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

        private void DisplayOrderbyDate(DateTime Date)
        {
            var ops = new OrderOperations();
            var response = ops.GetOrders(Date);
            

            if (response.Success)
            {
                _currentOrder = response.OrderInfo;
                PrintOrderInformation(response.OrderList);
                
            }
            else
            {
                Console.WriteLine("Error: ");
                Console.WriteLine(response.Message);
                Console.WriteLine("Move along...");
                Console.ReadLine();
            }
        }

        private void PrintOrderInformation(List<Order>orderList )
        {
            
            Console.Clear();
            foreach (var order in orderList)
            {
                Console.WriteLine("Order Information: ");
                Console.WriteLine("=====================================");
                Console.WriteLine("Order Number: {0}", order.OrderNumber);
                Console.WriteLine("Customer Name: {0},{1}", order.LastName, order.FirstName);
                Console.WriteLine("Order State: {0}, ({1})      State Tax Rate: {2}",
                    order.StateAbbr, order.StateFull, order.TaxRate);
                Console.WriteLine("Product Type: {0}     Order Area: {1}", order.ProductType, order.OrderArea);
                Console.WriteLine("Material Cost per Ft^2: {0}        Labor Cost per Ft^2: {1}",
                    order.CostperSqFt, order.LaborperSqFt);
                Console.WriteLine("Order Total: {0:C}", order.OrderTotal+order.TaxTotal);
                Console.WriteLine();
                Console.ReadLine();
            }
        }


    }
}
