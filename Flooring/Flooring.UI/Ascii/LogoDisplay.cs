﻿using System;
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
            Console.SetWindowSize(120,40);
            Console.BackgroundColor=ConsoleColor.Gray;
            Console.ForegroundColor=ConsoleColor.DarkCyan;
            Console.Clear();
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
                     |  |__|  |__|   ___________   
                     |__|  |__|  |  |   |   |   |
                     |  |__|  |__|  |░░░|░░░|░░░|  
          ««««»»»»   |__|__|__|__|  |###|###|###|   ╓╥╥╥╥╥╥╥╥╥╥╥╥╥╖
         [| ^ \ ^|]    ___/|        |▒▒▒|▒▒▒|▒▒▒|   |<><><><><><><|
          |  __, |    [___/         |▒▒▒|▒▒▒|▒▒▒|   | ╪ ╪ ╪ ╪ ╪ ╪ |
           \__w_/    /  /           ╙╨╨╨╨╨╨╨╨╨╨╨╜   |<><><><><><><|
         ___| |___  /  /                            | ╪ ╪ ╪ ╪ ╪ ╪ |
        /    \/   \/  /                             ╙╨╨╨╨╨╨╨╨╨╨╨╨╨╜
        | |      |   /

");
        }
    }
}
