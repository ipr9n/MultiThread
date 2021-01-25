using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1000Threads
{
    class FirstThreadTask
    {
        public void Start()
        {
            List<Task> tasks = new List<Task>();

            for (int i = 0; i < 100; i++)
            {
                Task task = new Task(() => Iterator());
                tasks.Add(task);
                task.Start();
            }

            tasks.ForEach(x => x.Wait());
            Console.WriteLine("Все потоки завершились");
        }

        public static void Iterator()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine($"Task {Task.CurrentId} - iteration number {i}");
            }
        }
    }
}
