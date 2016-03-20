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
        public int ProductId;
        public decimal Areanum;
        public int StateId;
        public string Area;
        public string Input;
        public string First;
        public string Last;
        public string Statestr;
        public string Product;
        private bool _validproduct = false;
        private bool _validstate = false;
        private OrderOperations oop;

        public AddOrderWorkFlow()
        {
            oop = MainMenuDisplay.GetOps();
        }
        public void Execute()
        {
            List<Product> prodList = oop.GetProductNames();
            List<string> stateList = oop.GetStateNames();
            Console.Clear();

            do
            {
                Console.WriteLine("Enter \"Q\" to go back to the main menu at any time. ");
                Console.Write("Please enter your first name: ");

                Input = Console.ReadLine();
                Input = Input?.Replace(",", "");

                if (Input == "")
                {
                    Console.WriteLine("Please enter a valid first name: ");
                    Console.WriteLine("Must have 1 one or more characters and no commas!");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }


            } while (Input == "" && Input.ToUpper() != "Q");
            if (Input.ToUpper() == "Q")
            {
                return;
            }
            First = Input;
            do
            {
                Console.Write("Please enter your last name: ");
                Input = Console.ReadLine();
                Input = Input?.Replace(",", "");

                if (Input == "")
                {
                    Console.WriteLine("Please enter a valid last name: ");
                    Console.WriteLine("Must have 1 one or more characters and no commas!");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (Input == "" && Input.ToUpper() != "Q");
            if (Input.ToUpper() == "Q")
            {
                return;
            }

            Last = Input;

            do
            {
                Console.WriteLine("Please enter the state you are ordering from: ");

                for (int i = 1; i <= stateList.Count; i++)
                {
                    Console.WriteLine("{0}. {1} ", i, stateList[i - 1]);
                }

                Console.Write("Please enter your choice: ");
                Input = Console.ReadLine();

                if (Input.ToUpper() == "Q")
                {
                    return;
                }

                if (Input != "")
                {
                    Statestr = Input;

                    if (!int.TryParse(Statestr, out StateId))
                    {
                        _validstate = false;
                    }
                    if (StateId > 0 && StateId <= stateList.Count)
                    {
                        _validstate = true;
                    }
                }
                if (!_validstate)
                {
                    _validstate = false;
                    Console.WriteLine("Please enter a valid state by number..");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (!_validstate && Input.ToUpper() != "Q");


            do
            {
                AsciiProductDisplay disp = new AsciiProductDisplay();
                disp.DisplayCatalog();
                Console.WriteLine("Please enter the Product Type you would like to order: ");
                for (int i = 1; i <= prodList.Count; i++)
                {
                    Console.WriteLine("{0}. {1} ", i, prodList[i - 1].ProductType);
                }

                Console.Write("Please enter your choice: ");
                Input = Console.ReadLine();

                if (Input.ToUpper() == "Q")
                {
                    return;
                }

                if (Input != "")
                {
                    Product = Input;
                    if (!int.TryParse(Product, out ProductId))
                    {
                        Console.WriteLine("Please enter a valid product type by number: ");
                        _validproduct = false;
                    }
                    if (ProductId > 0 && ProductId <= prodList.Count)
                    {
                        _validproduct = true;
                    }
                    else
                    {
                        _validproduct = false;
                        Console.WriteLine("Please enter a valid product type: ");
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
            } while (!_validproduct && Input.ToUpper() != "Q");

            do
            {
                Console.Write("Please enter the area in square feet you would like to order: ");
                Input = Console.ReadLine();

                if (Input.ToUpper() == "Q")
                {
                    return;
                }

                if (Input != "")
                {
                    Area = Input;
                    if (!decimal.TryParse(Area, out Areanum)||Areanum<=0)
                    {
                        Console.WriteLine("Please enter a positive number of square feet..");
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
            } while (Areanum <= 0 && Input.ToUpper() != "Q");

            Console.WriteLine();
            Console.WriteLine("NEW ORDER");
            Console.WriteLine("====================================================");
            Console.WriteLine("CUSTOMER NAME: {0},{1}", Last, First);
            Console.WriteLine("ORDERING STATE: {0}", (stateList[StateId - 1]));
            Console.WriteLine("PRODUCT TYPE: {0}", (prodList[ProductId - 1].ProductType));
            Console.WriteLine("AREA ORDERED (in Sq Ft.): {0:F} Ft^2", Areanum);
            Console.WriteLine();
            Console.WriteLine("Would you like to submit your order? (Y/N): ");
            string uinput = Console.ReadLine();
            if (uinput.ToUpper() == "Y")
            {
                string ordertemp =
                    String.Format(First + ',' + Last + ',' + StateId + ',' + ProductId + ',' + Areanum);

                oop.AddOrder(ordertemp);
                return;
            }
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
          

        }

    }
}

