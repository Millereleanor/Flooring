using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Flooring.BLL.OrderOperations;
using Flooring.Models;
using Flooring.UI.Ascii;

namespace Flooring.UI.Workflows
{
    public class EditOrderWorkflow
    {
        public int OrderNumber;
        public int ProductId;
        public int Areanum;
        public int StateId;
        public string State;
        public string Product;
        private bool _validproduct = false;
        private bool _validstate = false;
        public DateTime Date;
        private string _nfirst;
        private string _nlast;
        private string _input;

        public void Execute()
        {
            DisplayOrderWorkflow dispdatId = new DisplayOrderWorkflow();
            Date = dispdatId.GetOrderDateFromUser();

            if (Date == DateTime.MinValue)
            {
                return;
            }

            OrderOperations oop = new OrderOperations();
            List<Product> prodList = oop.GetProductNames();
            List<string> stateList = oop.GetStateNames();
            OrderNumber = dispdatId.GetOrderNumberFromUser();

            if (OrderNumber == -1)
            {
                return;
            }

            Response validOrderNumber = oop.GetSpecificOrder(OrderNumber, Date);


            if (validOrderNumber.Success)
            {
                PrintOrderInformation(validOrderNumber);
                Console.WriteLine();
                Console.WriteLine("===========================================================================");
                Console.WriteLine("EDIT ORDER MENU: ");
                Console.WriteLine("Press Enter if you want to skip a field");
                Console.WriteLine("Enter \"Q\" to go back to the main menu");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine();
                Console.Write("Please enter your first name: ");
                _input = Console.ReadLine();
                if (_input != "")
                {
                    _nfirst = _input;
                }
                else if (_input.ToUpper() == "Q")
                {
                    return;
                }
                else
                {
                    _nfirst = validOrderNumber.OrderInfo.FirstName;
                }
                Console.Write("Please enter your last name: ");
                _input = Console.ReadLine();
                if (_input != "")
                {
                    _nlast = _input;
                }
                else if (_input.ToUpper() == "Q")
                {
                    return;
                }
                else
                {
                    _nlast = validOrderNumber.OrderInfo.LastName;
                }
                do
                {
                    Console.WriteLine("Please enter the state you are ordering from: ");
                    for (int i = 1; i <= stateList.Count; i++)
                    {
                        Console.WriteLine("{0}. {1} ", i, stateList[i - 1]);
                    }
                    Console.Write("Please enter your choice: ");
                    _input = Console.ReadLine();
                    if (_input.ToUpper() == "Q")
                    {
                        return;
                    }
                    if (_input != "")
                    {

                        if (!int.TryParse(_input, out StateId))
                        {
                            Console.WriteLine("Please choose a valid state by number: ");
                        }
                        if (StateId > 0 && StateId <= stateList.Count)
                        {
                            _validstate = true;
                            State = (stateList[StateId - 1]);
                        }
                        else
                        {
                            _validstate = false;
                            Console.WriteLine("Please enter a valid state: ");
                        }
                    }
                    else
                    {
                        _validstate = true;
                        State = validOrderNumber.OrderInfo.StateFull;
                    }
                } while (!_validstate);
                do
                {
                    AsciiProductDisplay disp = new AsciiProductDisplay();
                    disp.DisplayCatalog(ProductId);
                    Console.WriteLine("Please enter the Product Type you would like to order: ");
                    for (int i = 1; i <= prodList.Count; i++)
                    {
                        Console.WriteLine("{0}. {1} ", i, prodList[i - 1].ProductType);
                    }

                    Console.Write("Please enter your choice: ");
                    _input = Console.ReadLine();

                    if (_input.ToUpper() == "Q")
                    {
                        return;
                    }

                    if (_input != "")
                    {
                        if (!int.TryParse(_input, out ProductId))
                        {
                            _validproduct = false;
                            Console.WriteLine("Please enter a valid product type by number: ");
                        }

                        if (ProductId > 0 && ProductId <= prodList.Count)
                        {
                            _validproduct = true;
                        }
                        else
                        {
                            _validproduct = false;
                            Console.WriteLine("Please enter a valid product type: ");
                        }
                    }
                    else if (_input == "")
                    {
                        _validproduct = true;
                        _input = Product;
                        Product = validOrderNumber.OrderInfo.ProductType;
                    }
                } while (!_validproduct);
                do
                {
                    Console.Write("Please enter the area in square feet you would like to order: ");
                    _input = Console.ReadLine();

                    if (_input.ToUpper() == "Q")
                    {
                        return;
                    }

                    if (_input != "")
                    {
                        if (!int.TryParse(_input, out Areanum))
                        {
                            Console.WriteLine("Please enter a valid number of square feet: ");
                            Console.WriteLine("Press enter to continue..");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Areanum = validOrderNumber.OrderInfo.OrderArea;
                    }
                } while (Areanum <= 0);

                Console.WriteLine();
                Console.WriteLine("EDITED ORDER");
                Console.WriteLine("====================================================");
                Console.WriteLine("CUSTOMER NAME: {0},{1}", _nlast, _nfirst);
                Console.WriteLine("ORDERING STATE: {0}", State);
                Console.WriteLine("PRODUCT TYPE: {0}", Product);
                Console.WriteLine("AREA ORDERED (in Sq Ft.): {0} Ft^2", Areanum);
                Console.WriteLine();
                Console.WriteLine("Would you like to submit your order? (Y/N): ");
                string uinput = Console.ReadLine();
                if (uinput.ToUpper() == "Y")
                {
                    string orderedit =
                        String.Format(_nfirst + ',' + _nlast + ',' + StateId + ',' + ProductId + ',' + Areanum);
                    oop.EditOrder(Date, OrderNumber, orderedit);
                }
            }
            else
            {
                Console.WriteLine(validOrderNumber.Message);
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
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