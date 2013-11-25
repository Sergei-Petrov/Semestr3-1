using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace NullElementsCounter
{
    class Program
    {
        /// <summary>
        /// Method used to count null elements by lambda-expression
        /// </summary>
        /// <param name="array">input array</param>
        /// <returns>number of null elements</returns>
        private static long LambdaCounter(int[] array)
        {
            return array.Count(x => x == 0);
        }

        /// <summary>
        /// Method used to count null elements by foreach
        /// </summary>
        /// <param name="array">input array</param>
        /// <returns>number of null elements</returns>
        private static long ForeachCounter(int[] array)
        {
            long temp = 0;
            for (long i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
                    temp++;
            }
            return temp;
        }

        /// <summary>
        /// Method used ti fill array with random numbers
        /// </summary>
        /// <param name="array">input array</param>
        /// <returns>filled array</returns>
        private static int[] ArrayFiller(int[] array)
        {
            Random rand = new Random();
            for (long i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(0, 100);
            }
            return array;
        }

        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            long length = 100000000;
            int t = 0;
            int[] array = new int[length];
            stopWatch.Start();
            while (t < 5)
            {
                Program.ArrayFiller(array);
                t++;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("Time spent to fill array in second is: {0} \n", ts.TotalSeconds / 5.0 );
            stopWatch.Start();
            Program.LambdaCounter(array);
            stopWatch.Stop();
            TimeSpan ts1 = stopWatch.Elapsed;
            Console.WriteLine("Time spent to count null elements in array by lambda-expression in seconds is:  {0} \n", ts1.TotalSeconds / 5.0);
            stopWatch.Start();
            Program.ForeachCounter(array);
            stopWatch.Stop();
            TimeSpan ts2 = stopWatch.Elapsed;
            Console.WriteLine("Time spent to count null elements in array by cycle in seconds is: {0} \n", ts2.TotalSeconds / 5.0);
        }
    }
}
