using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI.Ascii
{
    public class AsciiProductDisplay
    {
        public void DisplayCatalog(int productID)
        {
            Console.WriteLine("Get Floored! Product Catalog: ");
            Console.WriteLine(@"
                                    ________________         __________________         ________________
          ╓╥╥╥╥╥╥╥╥╥╥╥╥╥╥╥╥╖       | ╔══╗ ╔══╗ ╔══╗ |       |/ /\ \/ /\ \/ /\ \|       |   |(@)|   |   |
          |▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒|       | ║ ▌║ ║ ▌║ ║ ▌║ |       | /  \  /  \  /  \ |       |(@)|   |   |(@)|
          |^^^^^^^^^^^^^^^^|       | ╚══╝ ╚══╝ ╚══╝ |       | \  /  \  /  \  / |       |   |___|(@)|___|
          |▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒|       | ╔══╗ ╔══╗ ╔══╗ |       |\ \/ /\ \/ /\ \/ /|       |___|   |___|   |
          |^^^^^^^^^^^^^^^^|       | ║ ▌║ ║ ▌║ ║ ▌║ |       |/ /\ \/ /\ \/ /\ \|       |   |(@)|   |   |
          |▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒|       | ╚══╝ ╚══╝ ╚══╝ |       | /  \  /  \  /  \ |       |(@)|___|(@)|(@)|
          ╙╨╨╨╨╨╨╨╨╨╨╨╨╨╨╨╨╜       |________________|       |_\__/__\__/__\__/_|       |___|___|___|___|
           
              Plush Carpet            Shiny Laminate            Gorgeous Tile             Cherrywood    
Material:    $2.23 per SqFt           $1.75 per SqFt           $3.50 per SqFt           $5.15 per SqFt
Labor:       $2.10 per SqFt           $2.10 per SqFt           $4.15 per SqFt           $4.75 per SqFt
");
            

//            switch (productID)
//            {
//                case 1:
//                    Console.WriteLine(@"





//");
//                    break;
//                case 2:
//                    Console.WriteLine(@"





//");
//                    break;
//                case 3:
//                    Console.WriteLine(@"





//");
//                    break;
//                case 4:
//                    Console.WriteLine(@"





//");
//                    break;
//                default:
//                    break;
            }
        }

    }

