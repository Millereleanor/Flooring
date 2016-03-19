using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
    public class ErrorRepository
    {
        public ErrorRepository ()
        {
            Directory.CreateDirectory("ErrorLog\\");
        }
        public void LogError(string message)
        {
            DateTime errorTime = DateTime.Now;
            StreamWriter sw = new StreamWriter("ErrorLog\\ErrorLog.txt", true);
            sw.WriteLine("{0}  -  {1}",errorTime, message);
            sw.Close();
        }
    }
}
