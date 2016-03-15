using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.BLL.OrderOperations;
using Flooring.Models;

namespace Flooring.UI.Workflows
{
    public class AddOrderWorkFlow
    {
        public int productID;
        public int areanum;
        private int[] products = { 1, 2, 3, 4 };
        private bool validproduct = false;

        public string Execute(Order order)
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
                    Console.Write("Please enter the Product Type you would like to order: ");
                    Console.WriteLine("1. Cherrywood Flooring: ");
                    Console.WriteLine("2. Plush Carpet: ");
                    Console.WriteLine("3. Shiny Laminant:  ");
                    Console.WriteLine("4. Blingy Granite:  ");
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

                string ordertemp = String.Format(first + ',' + last + ',' + productID + ',' + areanum);
                return ordertemp;

        }
    }
}

