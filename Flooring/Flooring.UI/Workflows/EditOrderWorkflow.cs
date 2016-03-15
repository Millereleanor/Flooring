using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Flooring.BLL.OrderOperations;
using Flooring.Models;


namespace Flooring.UI.Workflows
{
    public class EditOrderWorkflow
    {
        public void Execute()
        {
            GetOrderDateFromUser();
            DisplayOrderbyDate();

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
                PrintOrderInformation();

            }
            else
            {
                Console.WriteLine("Error: ");
                Console.WriteLine(response.Message);
                Console.WriteLine("Move along...");
                Console.ReadLine();
            }
        }

        private void PrintOrderInformation()
        {
            Console.Clear();
            Console.WriteLine("Order Information: ");
            Console.WriteLine("=====================================");
            Console.WriteLine("Order Number: {0}", _currentOrder.OrderNumber);
            Console.WriteLine("Customer Name: {0},{1}", _currentOrder.LastName, _currentOrder.FirstName);
            Console.WriteLine("Order State: {0}, ({1})      State Tax Rate: {3}",
                _currentOrder.StateAbbr, _currentOrder.StateFull, _currentOrder.TaxRate);
            Console.WriteLine("Product Type: {0}     Order Area: {1}", _currentOrder.ProductType, _currentOrder.OrderArea);
            Console.WriteLine("Material Cost per Ft^2: {0}        Labor Cost per Ft^2: {1}",
                _currentOrder.CostperSqFt, _currentOrder.LaborperSqFt);
            Console.WriteLine("Order Total: {0}", _currentOrder.Total);
            Console.WriteLine();

        }

          


            //In Edit Method
            //TODO: Ask User for a date
            //TODO: Ask User for order
            //TODO: Check to see if date and # are valid (Possibly in validInput(dateTime, int))
            //TODO: Call GetOrder() in DisplayWorkflow
            //TODO: Display the Order recieved
            //TODO: Displays the variables to be edited (Name, State, Product Type, Area
            //TODO: Asks User if they want to edit or just press enter to keep previous data
            //TODO: Send to BLL passthrough to data with each iteration (in loop)
            //TODO: Display new (After Edited) order
            //TODO: Ask if user would like to edit another order

            return null;

        }

    }

}


