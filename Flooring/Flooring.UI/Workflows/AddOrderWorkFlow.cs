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
        private int[] products = {1, 2, 3, 4};
        private int[] states = {1, 2, 3, 4};
        private bool validproduct = false;
        private bool validstate = false;

        public string Execute()
        {
            string first;
            string last;
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

            do
            {
                AsciiProductDisplay disp = new AsciiProductDisplay();
                disp.DisplayCatalog(productID);
                Console.WriteLine("Please enter the Product Type you would like to order: ");
                Console.WriteLine("1. Plush Carpet: ");
                Console.WriteLine("2. Shiny Laminant: ");
                Console.WriteLine("3. Gorgeous Tile:  ");
                Console.WriteLine("4. Cherrywood:  ");
                Console.Write("Please enter your choice: ");
                string product = Console.ReadLine();
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

            do
            {
                Console.Write("Please enter the area in square feet you would like to order: ");
                string area = Console.ReadLine();
                if (!int.TryParse(area, out areanum))
                {
                    Console.WriteLine("Please enter a valid number of square feet: ");
                }
            } while (areanum == 0);

            string ordertemp = String.Format(first + ',' + last + ',' + stateID + ',' + productID + ',' + areanum);
            OrderOperations oop = new OrderOperations(DateTime.Now);
            oop.AddOrder(ordertemp);
            return ordertemp;

        }
    }
}

