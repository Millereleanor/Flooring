﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Flooring.BLL.OrderOperations;
using Flooring.Models;


namespace Flooring.UI.Workflows
{
    public class EditOrderWorkflow
    {

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
        public int productID;
        public int areanum;
        private int[] products = {1, 2, 3, 4};
        private bool validproduct = false;

        public void Execute()
        {


        }

        

       


       

    }

 
}

