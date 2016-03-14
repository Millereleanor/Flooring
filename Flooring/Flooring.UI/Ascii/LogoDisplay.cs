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
               ____________
              |  |__|  |__|   _____________    
              |__|  |__|  |  | <>  <>  <> |
     ~~~~     |  |__|  |__|  | <>  <>  <> |  
   |S~~~~SSS  |__|__|__|__|  | <>  <>  <> |  ________________
  [| ^ | ^|]    ___/|        | <>  <>  <> |  |^^--^^--^^--^^|
   | ,__, |    [___/         |____________|  |-^^--^^--^^--^|
    \____/    /  /                           |^^--^^--^^--^^| 
  ___| |___  /  /                            |-^^--^^--^^--^|
 /   \/    \/  /                             |______________|
 |

");
        }
    }
}
