using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Flooring.BLL.OrderOperations;
using Flooring.Models;
using Flooring.UI.Ascii;
using Microsoft.SqlServer.Server;


namespace Flooring.UI.Workflows
{
    public class EditOrderWorkflow
    {
        public int orderNumber;
        public int productID;
        public int areanum;
        public int stateID;
        private int[] products = {1, 2, 3, 4};
        private int[] states = {1, 2, 3, 4};
        private bool validproduct = false;
        private bool validstate = false;
        public DateTime Date;
        string nfirst;
        string nlast;
        string input;
        private Order _currentOrder;

        public void Execute()
        {
            DisplayOrderWorkflow dispdatID = new DisplayOrderWorkflow();
            Date = dispdatID.GetOrderDateFromUser();
            orderNumber = dispdatID.GetOrderNumberFromUser();
            dispdatID.DisplayOrderbyDateID(Date, orderNumber);

            Console.WriteLine("EDIT ORDER MENU: ");
            Console.WriteLine("Press Enter if you want to skip a field");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine();
            Console.Write("Please enter your first name: ");
            input = Console.ReadLine();
            if (input != "")
            {
                nfirst = input;
            }
            Console.Write("Please enter your last name: ");
            input = Console.ReadLine();
            if (input != "")
            {
                nlast = input;
            }
            Console.WriteLine("Please enter the state abbreviation you are ordering from: ");

            Console.WriteLine("1. Ohio: ");
            Console.WriteLine("2. Pennsylvania: ");
            Console.WriteLine("3. Michigan:  ");
            Console.WriteLine("4. Indiana:  ");
            Console.Write("Please enter your choice: ");
            string statestr = Console.ReadLine();
            if (statestr != "")
            {
                do
                {
                    if (!int.TryParse(statestr, out stateID))
                    {
                        Console.WriteLine("Please choose a valid state by number: ");
                    }
                    if (states.Contains(stateID))
                    {
                        validstate = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid state: ");
                    }
                } while (stateID == 0 && !validstate);
            }



            AsciiProductDisplay disp = new AsciiProductDisplay();
            disp.DisplayCatalog(productID);
            Console.WriteLine("Please enter the Product Type you would like to order: ");
            Console.WriteLine("1. Plush Carpet: ");
            Console.WriteLine("2. Shiny Laminant: ");
            Console.WriteLine("3. Gorgeous Tile:  ");
            Console.WriteLine("4. Cherrywood:  ");
            Console.Write("Please enter your choice: ");
            string product = Console.ReadLine();
            if (product != "")
            {
                do
                {
                    if (!int.TryParse(product, out productID))
                    {
                        Console.WriteLine("Please enter a valid product type by number: ");
                    }
                    if (products.Contains(productID))
                    {
                        validproduct = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid product type: ");
                    }

                } while (productID == 0 && !validproduct);
            }


            Console.Write("Please enter the area in square feet you would like to order: ");
            string area = Console.ReadLine();
            if (area != "")
            {
                do
                {
                    if (!int.TryParse(area, out areanum))
                    {
                        Console.WriteLine("Please enter a valid number of square feet: ");
                    }
                } while (areanum == 0);
            }

            string orderedit = String.Format(nfirst + ',' + nlast + ',' + stateID + ',' + productID + ',' + areanum);
            OrderOperations oop = new OrderOperations(Date);
            //oop.EditOrder(ordertemp);


        }
    }



    //    //In Edit Method
    //    //TODO: Ask User for a date
    //    //TODO: Ask User for order
    //    //TODO: Check to see if date and # are valid (Possibly in validInput(dateTime, int))
    //    //TODO: Call GetOrder() in DisplayWorkflow
    //    //TODO: Display the Order recieved
    //    //TODO: Displays the variables to be edited (Name, State, Product Type, Area
    //    //TODO: Asks User if they want to edit or just press enter to keep previous data
    //    //TODO: Send to BLL passthrough to data with each iteration (in loop)
    //    //TODO: Display new (After Edited) order
    //    //TODO: Ask if user would like to edit another order


}

    





