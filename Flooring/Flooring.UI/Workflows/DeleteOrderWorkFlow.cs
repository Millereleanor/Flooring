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

            OrderOperations op = new OrderOperations();

            Console.Write("Are you sure you want to delete this order? (Yes/No): ");
            string input = Console.ReadLine();
            if (input.ToUpper() == "YES")
            {
                //op.DeleteOrder(order);
                Console.WriteLine("Press enter to continue... Goodbye!");
                Console.ReadLine();
                MainMenuDisplay back = new MainMenuDisplay();
                back.Display();
                return;
            }
            if (input.ToUpper() == "NO")
            {
                return;
            }
            Console.WriteLine("ERROR: That was not a valid input!");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

        }

    }
}
