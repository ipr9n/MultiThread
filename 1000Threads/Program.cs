using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _1000Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstTask = new FirstThreadTask(); // first Task. To start: firstTask.Start();
            var taskChain = new TaskChain();       // Second Task. To start: taskChain.GetAverage();

            firstTask.Start();
              taskChain.GetAverage();
            Console.ReadLine();
        }

      
    }
}
