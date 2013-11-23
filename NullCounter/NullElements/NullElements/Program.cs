using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace NullElements
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            long length = 100000000;
            int[] array = new int[length];
            Random rand = new Random();
            int t = 0;
            stopWatch.Start();
            while (t < 5)
            {
                for (int i = 0; i < length; i++)
                {
                    array[i] = rand.Next(0, 100);
                }
                t++;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("Time spent to fill the array in seconds is : {0} \n ", ts.TotalSeconds / 10.0);
            stopWatch.Start();
            long counter = array.LongCount(x => x == 0);
            stopWatch.Stop();
            TimeSpan ts1 = stopWatch.Elapsed;
            Console.WriteLine("Time spent to count null elements in seconds is : {0} \n ", ts1.TotalSeconds / 10.0);
            Console.WriteLine("Number of null elements is : {0}", counter);
        }
    }
}
