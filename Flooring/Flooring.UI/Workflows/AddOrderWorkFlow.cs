using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.BLL.OrderOperations;
using Flooring.Models;
using Flooring.UI.Ascii;

namespace Flooring.UI.Workflows
{
    public class AddOrderWorkFlow
    {
        public int productID;
        public int areanum;
        public int stateID;
        public string area;
        public string input;
        public string first;
        public string last;
        public string statestr;
        public string product;

        public enum Products
        {
            Carpet=1,
            Laminate=2,
            Tile=3,
            Cherrywood=4
        };

        public enum States
        {
            Ohio=1,
            Pennsylvania=2,
            Michigan=3,
            Indiana=4
        };
        private bool validproduct = false;
        private bool validstate = false;

        public string Execute()
        {
                Console.Clear();

                do
                {
                    Console.Write("Please enter your first name: ");
                    input = Console.ReadLine();

                    if (input == "")
                    {
                        Console.WriteLine("Please enter a valid first name: ");
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                    }

                } while (input == "" && input.ToUpper() != "Q");
            if (input.ToUpper() == "Q")
            {
                quit();
            }
                input = first;
                do
                {
                    Console.Write("Please enter your last name: ");
                    input = Console.ReadLine();

                    if (input == "")
                    {
                        Console.WriteLine("Please enter a valid last name: ");
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                    }
                } while (input == "" && input.ToUpper() != "Q");
            if (input.ToUpper() == "Q")
            {
                quit();
            }

            input = last;
                do
                {
                    Console.WriteLine("Please enter the state abbreviation you are ordering from: ");

                    Console.WriteLine("1. Ohio: ");
                    Console.WriteLine("2. Pennsylvania: ");
                    Console.WriteLine("3. Michigan:  ");
                    Console.WriteLine("4. Indiana:  ");
                    Console.Write("Please enter your choice: ");
                    input = Console.ReadLine();
                    if (input != "")
                    {
                        input = statestr;
                        States states;
                        if (!int.TryParse(statestr, out stateID))
                        {
                            Console.WriteLine("Please choose a valid state by number: ");
                        }
                        if (Enum.TryParse<States>(statestr, out states))
                        {
                            validstate = true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid state: ");
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                } while (stateID == 0 && !validstate && input.ToUpper() != "Q");
            if (input.ToUpper() == "Q")
            {
                quit();
            }


            do
            {
                    AsciiProductDisplay disp = new AsciiProductDisplay();
                    disp.DisplayCatalog(productID);
                    Console.WriteLine("Please enter the Product Type you would like to order: ");
                    Console.WriteLine("1. Plush Carpet: ");
                    Console.WriteLine("2. Shiny Laminate: ");
                    Console.WriteLine("3. Gorgeous Tile:  ");
                    Console.WriteLine("4. Cherrywood:  ");
                    Console.Write("Please enter your choice: ");
                    input = Console.ReadLine();
                    Products products;
                    if (input != "")
                    {
                        input = product;
                        if (!int.TryParse(product, out productID))
                        {
                            Console.WriteLine("Please enter a valid product type by number: ");
                        }
                        if (Enum.TryParse<Products>(product, out products))
                        {
                            validproduct = true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid product type: ");
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                } while (productID == 0 && !validproduct && input.ToUpper() != "Q");
            if (input.ToUpper() == "Q")
            {
                quit();
            }


            do
            {
                    Console.Write("Please enter the area in square feet you would like to order: ");
                    input = Console.ReadLine();
                    if (input != "")
                    {
                        input = area;
                        if (!int.TryParse(area, out areanum))
                        {
                            Console.WriteLine("Please enter a valid number of square feet: ");
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                } while (areanum == 0 && input.ToUpper()!="Q");
            if (input.ToUpper() == "Q")
            {
                quit();
            }


            Console.WriteLine();
                Console.WriteLine("NEW ORDER");
                Console.WriteLine("====================================================");
                Console.WriteLine("CUSTOMER NAME: {0},{1}", last, first);
                Console.WriteLine("ORDERING STATE: {0}", ((States) stateID).ToString());
                Console.WriteLine("PRODUCT TYPE: {0}", ((Products) productID).ToString());
                Console.WriteLine("AREA ORDERED (in Sq Ft.): {0} Ft^2", areanum);
                Console.WriteLine();
                Console.WriteLine("Would you like to submit your order? (Y/N): ");
                string uinput = Console.ReadLine();
                if (uinput.ToUpper() == "Y")
                {
                    string ordertemp =
                        String.Format(first + ',' + last + ',' + stateID + ',' + productID + ',' + areanum);
                    OrderOperations oop = new OrderOperations(DateTime.Now);
                    oop.AddOrder(ordertemp);
                    return ordertemp;
                }
                else
                {

                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }
           
            return null;

        }

        public void quit()
        {
            MainMenuDisplay mm = new MainMenuDisplay();
            mm.Display();
            
        }
    }
}

