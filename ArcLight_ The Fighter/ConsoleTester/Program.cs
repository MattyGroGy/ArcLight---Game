using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester
{
    public class Program
    {

        static void Main()
        {
            Console.WriteLine("Console Started!");
            Console.ReadLine();
        }

        public static void SendToConsole(String input)
        {
            Console.WriteLine(input);
            Console.ReadLine();
        }
    }
}
