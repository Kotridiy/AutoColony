using BusinessLogic;
using BusinessLogic.Interfaces;
using System;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Heart heart = new Heart();
            heart.Logger = new ConsoleLogger();
            Thread thread = Initializer.Initialize(heart, DateTime.Now);
            thread.Start();
            while (true)
            {
                Thread.Sleep(1000);
            }
        }

        class ConsoleLogger : ILogger
        {
            public void Log(string text)
            {
                Console.WriteLine(text);
            }
        }
    }
}
