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
            Console.SetWindowSize(100,40);
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
                     |__|  |__|  |  | <> |<>| <> |
                     |  |__|  |__|  | <>| <> |<> |  
          SSSSSSSS   |__|__|__|__|  | <> |<>| <> |   ______________
         [| ^ \ ^|]    ___/|        | <>| <> |<> |  |<><><><><><><>|
          |  __, |    [___/         |____|__|____|  |**************|
           \____/    /  /                           |<><><><><><><>|
         ___| |___  /  /                            |**************|
        /    \/   \/  /                             |______________|
        | |      |   /

");
        }
    }
}
