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
        public void DeleteOrder()
        {
            DisplayOrderWorkflow disp = new DisplayOrderWorkflow();
            var Date = disp.GetOrderDateFromUser();
            OrderOperations op = new OrderOperations(Date);
            var OrderNumber = disp.GetOrderNumberFromUser();
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
                    MainMenuDisplay back = new MainMenuDisplay();
                    back.Display();
                    return;
                }

                if (input.ToUpper() == "N")
                {
                    return;
                }
            }
           
            Console.ReadLine();


        }

        public void PrintOrderInformation(Response response)
        {
            Console.Clear();
            if(response.Success)
            {
                Console.WriteLine("Order Date: {0}", response.OrderInfo.OrderDate.ToShortDateString());
                Console.WriteLine("{0} order(s) found on this date. ", response.OrderList.Count);
                Console.WriteLine("******************************************************");
                Console.WriteLine();
                foreach (var order in response.OrderList)
                {


                    Console.WriteLine();
                    Console.WriteLine("ORDER INFORMATION: ");
                    Console.WriteLine("=====================================");
                    Console.WriteLine("ORDER NUMBER: {0}", order.OrderNumber);
                    Console.WriteLine("CUSTOMER NAME: {0},{1}", order.LastName, order.FirstName);
                    Console.WriteLine("ORDER STATE: {0} ({1})          STATE TAX RATE: {2:P}",
                        order.StateAbbr, order.StateFull, order.TaxRate);
                    Console.WriteLine("PRODUCT TYPE: {0}                  ORDER AREA: {1}", order.ProductType,
                        order.OrderArea);
                    Console.WriteLine("MATERIAL COST PER Ft^2: {0}        LABOR COST PER Ft^2: {1}",
                        order.CostperSqFt, order.LaborperSqFt);
                    Console.WriteLine("ORDER TOTAL: {0:C}",
                        order.OrderTotal + order.TaxTotal);
                    Console.WriteLine();


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