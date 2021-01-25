using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1000Threads
{
    class TaskChain
    {
        public void GetAverage()
        {
            Task<int[]> task = new Task<int[]>(() => GetTenRandomInteger());
            var task2 = task.ContinueWith(x => MultiplieArray(x.Result));
            var task3 = task2.ContinueWith(x => SortAsc(x.Result));
            var task4 = task3.ContinueWith(x => GetArrayAverage(x.Result));
            task.Start();
        }

        private int[] GetTenRandomInteger()
        {
            Console.WriteLine("Get ten random integer");
            var random = new Random();
            int[] output = new int[10];
            for (int i = 0; i < 10; i++)
            {
                output[i] = random.Next(0,100);
                Console.WriteLine(output[i]);
            }

            return output;
        }

        private double GetArrayAverage(int[] array)
        {
            Console.WriteLine("Get average");
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum = sum + array[i];
            }
            double result = (double)sum / 10;

            Console.WriteLine($"Average is: {result}");
            return result;
        }

        private int[] MultiplieArray(int[] array)
        {
            Console.WriteLine("Multiplie this array");
            for (int i = 0; i < 10; i++)
            {
                array[i] = array[i] * (new Random().Next(0,100));
                Console.WriteLine(array[i]);
            }

            return array;
        }

        private int[] SortAsc(int[] array)
        {
            Console.WriteLine("Sort ascending");
            Array.Sort(array);
            for(int i = 0; i<10; i++)
                Console.WriteLine(array[i]);

            return array;
        }
    }
}
