using System;

namespace TCPBogServer
{
    class Program
    {
        static void Main(string[] args)
        {
          Bogserver worker = new Bogserver();
          worker.Start();

          Console.ReadLine();
        }
    }
}
