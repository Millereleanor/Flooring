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
        private bool validproduct = false;
        private bool validstate = false;

        public string Execute()
        {
            OrderOperations oop = new OrderOperations(DateTime.Now);
            List<Product> prodList=oop.GetProductNames();
            List<string> stateList=oop.GetStateNames();
            Console.Clear();

                do
                {
                Console.WriteLine("Enter \"Q\" to go back to the main menu at any time. ");
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
                first=input;
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

            last = input;
                do
                {
                    Console.WriteLine("Please enter the state you are ordering from: ");
                    for (int i = 1; i <= stateList.Count; i++)
                    {
                    Console.WriteLine("{0}. {1}: ",i,stateList[i-1]);
                        //Console.WriteLine("1. Ohio: ");
                        //Console.WriteLine("2. Pennsylvania: ");
                        //Console.WriteLine("3. Michigan:  ");
                        //Console.WriteLine("4. Indiana:  ");
                        
                    }
                Console.Write("Please enter your choice: ");
                input = Console.ReadLine();
                    if (input != "")
                    {
                        statestr= input;
                       
                        if (!int.TryParse(statestr, out stateID))
                        {
                            Console.WriteLine("Please choose a valid state by number: ");
                        }
                        if (stateID>0 && stateID<=stateList.Count)
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
                for (int i = 1; i <= prodList.Count; i++)
                {
                    Console.WriteLine("{0}. {1}: ",i,prodList[i-1].ProductType);
                }
                
                //Console.WriteLine("1. Plush Carpet: ");
                    //Console.WriteLine("2. Shiny Laminate: ");
                    //Console.WriteLine("3. Gorgeous Tile:  ");
                    //Console.WriteLine("4. Cherrywood:  ");
                    Console.Write("Please enter your choice: ");
                    input = Console.ReadLine();
                  
                    if (input != "")
                    {
                        product = input;
                        if (!int.TryParse(product, out productID))
                        {
                            Console.WriteLine("Please enter a valid product type by number: ");
                        }
                        if (productID>0 && productID<=prodList.Count)
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
                        area =input;
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
                Console.WriteLine("ORDERING STATE: {0}", (stateList[stateID-1]));
                Console.WriteLine("PRODUCT TYPE: {0}", (prodList[productID-1].ProductType));
                Console.WriteLine("AREA ORDERED (in Sq Ft.): {0} Ft^2", areanum);
                Console.WriteLine();
                Console.WriteLine("Would you like to submit your order? (Y/N): ");
                string uinput = Console.ReadLine();
                if (uinput.ToUpper() == "Y")
                {
                    string ordertemp =
                        String.Format(first + ',' + last + ',' + stateID + ',' + productID + ',' + areanum);
                    
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

