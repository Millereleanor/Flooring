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
            string first;
            string last;
            Console.Clear();
            do
            {
                Console.Write("Please enter your first name: ");
                first = Console.ReadLine();

                if (first == "")
                {
                    Console.WriteLine("Please enter a valid first name: ");
                }
            } while (first == "");

            do
            {
                Console.Write("Please enter your last name: ");
                last = Console.ReadLine();

                if (last == "")
                {
                    Console.WriteLine("Please enter a valid last name: ");
                }
            } while (last == "");

            do
            {
                Console.WriteLine("Please enter the state abbreviation you are ordering from: ");

                Console.WriteLine("1. Ohio: ");
                Console.WriteLine("2. Pennsylvania: ");
                Console.WriteLine("3. Michigan:  ");
                Console.WriteLine("4. Indiana:  ");
                Console.Write("Please enter your choice: ");
                string statestr = Console.ReadLine();
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
                }
            } while (stateID == 0 && !validstate);

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
                string product = Console.ReadLine();
                Products products;
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
                }

            } while (productID == 0 && !validproduct);

            do
            {
                Console.Write("Please enter the area in square feet you would like to order: ");
                string area = Console.ReadLine();
                if (!int.TryParse(area, out areanum))
                {
                    Console.WriteLine("Please enter a valid number of square feet: ");
                }
            } while (areanum == 0);

            Console.WriteLine();
            Console.WriteLine("NEW ORDER");
            Console.WriteLine("====================================================");
            Console.WriteLine("CUSTOMER NAME: {0},{1}",last, first);
            Console.WriteLine("ORDERING STATE: {0}",((States)stateID).ToString());
            Console.WriteLine("PRODUCT TYPE: {0}", ((Products)productID).ToString());
            Console.WriteLine("AREA ORDERED (in Sq Ft.): {0} Ft^2",areanum);
            Console.WriteLine();
            Console.WriteLine("Press enter to submit order: ");
            Console.ReadLine();
            string ordertemp = String.Format(first + ',' + last + ',' + stateID + ',' + productID + ',' + areanum);
            OrderOperations oop = new OrderOperations(DateTime.Now);
            oop.AddOrder(ordertemp);
            return ordertemp;

        }
    }
}

