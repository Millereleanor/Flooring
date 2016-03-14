using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.UI.Ascii;

namespace Flooring.UI.Workflows
{
    public class MainMenuDisplay
    {
        public void Display()
        {
            string input = "";
            do
            {
                Console.Clear();
                
                Console.WriteLine("\nWelcome to GET FLOORED! Inc.");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("1. Lookup Account");
                Console.WriteLine("2. Create Account");
                Console.WriteLine();
                Console.WriteLine("(Q) to Quit");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Enter Choice: ");

                input = Console.ReadLine();

                if (input.ToUpper() != "Q")
                {
                    ProcessChoice(input);
                }

            } while (input.ToUpper() != "Q");


        }
        private void ProcessChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    LookupWorkFlow lookup = new LookupWorkFlow();
                    lookup.Execute();
                    break;
                case "2":

                    Console.WriteLine("This feature is not implemented yet!");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("{0} is not valid", choice);
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
}
