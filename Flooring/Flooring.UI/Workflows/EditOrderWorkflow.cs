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
        public string state;
        public string product;

        public enum Products
        {
            Carpet = 1,
            Laminate = 2,
            Tile = 3,
            Cherrywood = 4
        };

        public enum States
        {
            Ohio = 1,
            Pennsylvania = 2,
            Michigan = 3,
            Indiana = 4
        };

        private bool validproduct = false;
        private bool validstate = false;
        public DateTime Date;
        string nfirst;
        string nlast;
        string input;

        public void Execute()
        {
            DisplayOrderWorkflow dispdatID = new DisplayOrderWorkflow();
            Date = dispdatID.GetOrderDateFromUser();
            OrderOperations oop = new OrderOperations(Date);
            orderNumber = dispdatID.GetOrderNumberFromUser();
            Response validOrderNumber = oop.GetSpecificOrder(orderNumber, Date);
            PrintOrderInformation(validOrderNumber);
           
                if (validOrderNumber.Success)
                {
                    Console.WriteLine();
                    Console.WriteLine("===========================================================================");
                    Console.WriteLine("EDIT ORDER MENU: ");
                    Console.WriteLine("Press Enter if you want to skip a field");
                    Console.WriteLine("Enter \"Q\" to go back to the main menu");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine();
                    Console.Write("Please enter your first name: ");
                    input = Console.ReadLine();
                    if (input != "")
                    {
                        nfirst = input;
                    }
                    else if (input.ToUpper()=="Q")
                    {
                      quit();  
                    }
                    else
                    {
                        nfirst = validOrderNumber.OrderInfo.FirstName;
                    }
                    Console.Write("Please enter your last name: ");
                    input = Console.ReadLine();
                    if (input != "")
                    {
                        nlast = input;
                    }
                    else if (input.ToUpper() == "Q")
                    {
                        quit();
                    }
                    else
                    {
                        nlast = validOrderNumber.OrderInfo.LastName;
                    }
                    Console.WriteLine("Please enter the state abbreviation you are ordering from: ");

                    Console.WriteLine("1. Ohio: ");
                    Console.WriteLine("2. Pennsylvania: ");
                    Console.WriteLine("3. Michigan:  ");
                    Console.WriteLine("4. Indiana:  ");
                    Console.Write("Please enter your choice: ");
                    input = Console.ReadLine();
                    if (input.ToUpper() == "Q")
                    {
                        quit();
                    }
                    States states;
                    if (input != "")
                    {
                        do
                        {
                            if (!int.TryParse(input, out stateID))
                            {
                                Console.WriteLine("Please choose a valid state by number: ");
                            }
                            if (Enum.TryParse<States>(input, out states))
                            {
                                validstate = true;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid state: ");
                            }
                            state = ((States) stateID).ToString();
                        } while (stateID == 0 && !validstate);
                    }
                    else
                    {
                        state = validOrderNumber.OrderInfo.StateFull;
                    }

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
                    if (input.ToUpper() == "Q")
                    {
                        quit();
                    }
                    if (input != "")
                    {
                        do
                        {
                            if (!int.TryParse(input, out productID))
                            {
                                Console.WriteLine("Please enter a valid product type by number: ");
                            }

                            if (Enum.TryParse<Products>(input, out products))
                            {
                                validproduct = true;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid product type: ");
                            }

                        } while (productID == 0 && !validproduct);
                    }
                    else
                    {
                        input = product;
                        product = validOrderNumber.OrderInfo.ProductType;
                    }

                    Console.Write("Please enter the area in square feet you would like to order: ");
                    input = Console.ReadLine();
                    if (input.ToUpper() == "Q")
                    {
                        quit();
                    }
                    if (input != "")
                    {
                        do
                        {
                            if (!int.TryParse(input, out areanum))
                            {
                                Console.WriteLine("Please enter a valid number of square feet: ");
                            }
                        } while (areanum == 0);
                    }
                    else
                    {
                        areanum = validOrderNumber.OrderInfo.OrderArea;
                    }
                    Console.WriteLine();
                    Console.WriteLine("EDITED ORDER");
                    Console.WriteLine("====================================================");
                    Console.WriteLine("CUSTOMER NAME: {0},{1}", nlast, nfirst);
                    Console.WriteLine("ORDERING STATE: {0}", state);
                    Console.WriteLine("PRODUCT TYPE: {0}", product);
                    Console.WriteLine("AREA ORDERED (in Sq Ft.): {0} Ft^2", areanum);
                    Console.WriteLine();
                    Console.WriteLine("Would you like to submit your order? (Y/N): ");
                    string uinput = Console.ReadLine();
                    if (uinput.ToUpper() == "Y")
                    {
                        string orderedit =
                            String.Format(nfirst + ',' + nlast + ',' + stateID + ',' + productID + ',' + areanum);
                        oop.EditOrder(Date, orderNumber, orderedit);
                    }
                    else
                    {

                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                    }

                }
            



        }

        public void PrintOrderInformation(Response response)
        {

            Console.Clear();
            Console.WriteLine("Order Date: {0}", Date.ToShortDateString());
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
        public void quit()
        {
            MainMenuDisplay mm = new MainMenuDisplay();
            mm.Display();

        }
    }
}