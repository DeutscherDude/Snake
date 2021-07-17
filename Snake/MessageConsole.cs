using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    static class MessageConsole
    {
        static public void LogMessage (string message)
        {
            DateTime current = DateTime.Now;

            Console.WriteLine(current.ToString() + " " + message);
        }
    }
}
