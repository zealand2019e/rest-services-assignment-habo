using System;
using ModelLib;

namespace ConsumeRest
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker w1 = new Worker();
            w1.Start();


            Console.ReadKey();
        }
    }
}
