using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.UI.Ascii;
using Flooring.Models;

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
                LogoDisplay logo = new LogoDisplay();
                logo.DisplayLogoName();
                logo.DisplayLogoPic();
                Console.WriteLine("\nWelcome to GET FLOORED! Inc.");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("1. Display Order: ");
                Console.WriteLine("2. Add Order: ");
                Console.WriteLine("3. Edit Order:  ");
                Console.WriteLine("4. Remove Order:  ");
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
                    DisplayOrderWorkflow orderDisplay = new DisplayOrderWorkflow();
                    orderDisplay.Execute();
                    break;
                case "2":
                    //AddOrderWorkflow 
                    
                    
                case "3":
                    
                case "4":
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

