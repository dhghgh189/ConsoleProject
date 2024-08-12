using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Utils
{
    public class Util
    {
        public static void Print(string msg = "", ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(msg);
            Console.ResetColor();
        }

        public static void PrintLine(string msg = "", ConsoleColor color = ConsoleColor.White)
        {
            Print(msg, color);
            Console.WriteLine();
        }
    }
}
