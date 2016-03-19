using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Flooring.BLL.OrderOperations;
using Flooring.Models;

namespace Flooring.UI.Ascii
{
    public class AsciiProductDisplay
    {
        public void DisplayCatalog()
        {
          OrderOperations oop = new OrderOperations();
        List<Product> prodList = oop.GetProductNames();
            Console.WriteLine("Get Floored! Product Catalog: ");
            Console.WriteLine(@"
                                ________________       __________________       _______________
        ╓╥╥╥╥╥╥╥╥╥╥╥╥╥╥╥╥╖     | ╔══╗ ╔══╗ ╔══╗ |     |/ /\ \/ /\ \/ /\ \|     |   |(@)|   |   |
        |▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒|     | ║ ▌║ ║ ▌║ ║ ▌║ |     | /  \  /  \  /  \ |     |(@)|   |   |(@)|
        |^^^^^^^^^^^^^^^^|     | ╚══╝ ╚══╝ ╚══╝ |     | \  /  \  /  \  / |     |   |___|(@)|___|
        |▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒|     | ╔══╗ ╔══╗ ╔══╗ |     |\ \/ /\ \/ /\ \/ /|     |___|   |___|   |
        |^^^^^^^^^^^^^^^^|     | ║ ▌║ ║ ▌║ ║ ▌║ |     |/ /\ \/ /\ \/ /\ \|     |   |(@)|   |   |
        |▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒|     | ╚══╝ ╚══╝ ╚══╝ |     | /  \  /  \  /  \ |     |(@)|___|(@)|(@)|
        ╙╨╨╨╨╨╨╨╨╨╨╨╨╨╨╨╨╜     |________________|     |_\__/__\__/__\__/_|     |___|___|___|___|
");          
            Console.WriteLine("Name:         {0}                {1}                  {2}                    {3}", prodList[0].ProductType, prodList[1].ProductType,prodList[2].ProductType,prodList[3].ProductType);
            Console.WriteLine("Material:     {0:C}                  {1:C}                    {2:C}                   {3:C}",prodList[0].CostperSqFt,prodList[1].CostperSqFt,prodList[2].CostperSqFt,prodList[3].CostperSqFt);
            Console.WriteLine("Labor:        {0:C}                  {1:C}                    {2:C}                   {3:C}",prodList[0].LaborperSqFt,prodList[1].LaborperSqFt,prodList[2].LaborperSqFt,prodList[3].LaborperSqFt);
            }
        }

    }

