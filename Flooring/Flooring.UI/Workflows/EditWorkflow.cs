using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI.Workflows
{
    public class EditWorkflow
    {
        public int productID;
        public int areanum;
        private int[] products = {1, 2, 3, 4};
        private bool validproduct = false;

        public void Execute()
        {


        }

        public string AddOrder()
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

            } while (productID==0 && !validproduct);

            do
            {
                Console.Write("Please enter the area in square feet you would like to order: ");
                string area = Console.ReadLine();
                if (!int.TryParse(area, out areanum))
                {
                    Console.WriteLine("Please enter a valid number of square feet: ");
                }
            } while (areanum == 0);

            string ordertemp = String.Format(first+','+ last +','+ productID + ','+areanum);
            return ordertemp;

        }

       

       

        public void EditOrder()
        {
            //In Edit Method
            //TODO: Ask User for a date
            //TODO: Ask User for order
            //TODO: Check to see if date and # are valid (Possibly in validInput(dateTime, int))
            //TODO: Call GetOrder() in DisplayWorkflow
            //TODO: Display the Order recieved
            //TODO: Displays the variables to be edited (Name, State, Product Type, Area
            //TODO: Asks User if they want to edit or just press enter to keep previous data
            //TODO: Send to BLL passthrough to data with each iteration (in loop)
            //TODO: Display new (After Edited) order
            //TODO: Ask if user would like to edit another order

        }

        public void DeleteOrder()
        {


        }


    }

 
}

