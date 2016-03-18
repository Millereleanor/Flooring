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
            var Date =disp.GetOrderDateFromUser();
            OrderOperations op = new OrderOperations(Date);
            var OrderNumber =disp.GetOrderNumberFromUser();
            Response response = op.GetSpecificOrder(OrderNumber,Date);
            disp.DisplayOrderbyDateID(Date,OrderNumber);
           
            Console.Write("Are you sure you want to delete this order? (Y/N): ");
            string input = Console.ReadLine();
            if (input.ToUpper() == "Y")
            {
                op.DeleteOrder(OrderNumber,Date);
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                MainMenuDisplay back = new MainMenuDisplay();
                back.Display();
                return;
            }

            if (input.ToUpper() == "N")     
            {
                return;
            }

            Console.WriteLine("ERROR: That was not a valid input!");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

        }

    }
}
