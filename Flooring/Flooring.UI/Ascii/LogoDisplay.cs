using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI.Ascii
{
    public class LogoDisplay
    {
        public void DisplayLogoName()
        {
            Console.SetWindowSize(120,30);
            Console.WriteLine(@"
    #######           #         #######  #                                   ##
  ##          ####  =====      #        # #   ##   ##   #  ##    ####       #    ^TM
  ##  =====# #====#  #         #======  # #  #  # #  #   ##  #  #====#   ####
  ##       # #       #  #      #        #    #  # #  #   #      #       #   # 
   ####### #  ####    ##       #      #  ###  ##   ##   #        ####    #####
                                                            Division of SGCorp*
=================================================================================

");
        }

        public void DisplayLogoPic()
        {
            Console.WriteLine(@"
               ___________
              |  |__|  |__|   ____________   
              |__|  |__|  |  | <>  <>  <> |
              |  |__|  |__|  | <>  <>  <> |  
   SSSSSSSS   |__|__|__|__|  | <>  <>  <> |   ______________
  [| ^ \ ^|]    ___/|        | <>  <>  <> |  |<><><><><><><>|
   |  __, |    [___/         |____________|  |**************|
    \____/    /  /                           |<><><><><><><>|
  ___| |___  /  /                            |**************|
 /   \/    \/  /                             |______________|
 |

");
        }
    }
}
