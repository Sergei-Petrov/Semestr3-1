using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace TimeCheck
{
    class Program
    {
        /// <summary>
        /// Method used to find out how much time we spent for an action
        /// </summary>
        /// <param name="action">action to do</param>
        /// <param name="array">input array</param>
        /// <returns>time spent</returns>
        private static double Duration(Func<int[], int[]> action, int[] array)
        {
            int n = array.Length / 1000;
            double temp = -1;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            while (n <= array.Length)
            {
                action(array);
                n *= 10;
                temp++;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("Time spent in seconds is: {0} \n", ts.TotalSeconds / temp);
            return ts.TotalSeconds / temp;
        }

        static void Main(string[] args)
        {
            long length = 100000000;
            int[] array = new int[length];

            Func<int[], int[]> func = x =>
            {
                int k = x.Count(y => y == 0);
                return x;
            };

            Func<int[], int[]> func1 = x =>
            {
                Random rand = new Random();
                for (long i = 0; i < x.Length; i++)
                {
                    x[i] = rand.Next(0, 100);
                }
                return x;
            };

            Func<int[], int[]> func2 = x =>
            {
                for (long i = 0; i < x.Length; i++)
                {
                    long counter = 0;
                    if (x[i] == 0)
                        counter++;
                }
                return x;
            };

            Program.Duration(func, array);//counts null elements by lambda expression
            Program.Duration(func2, array);//counts null elements by cycle
            Program.Duration(func1, array);//fills the array
        }
    }
}
