using LabWeb.Models;
using System;

namespace LabConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            var tw = new TwentyWays();
            tw.GenerateWord();

            Console.WriteLine($"result : {tw}");


        }
    }
}
