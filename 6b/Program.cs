using System;
using System.Diagnostics;

namespace CDC_Lab
{
    class LoopJammingOptimization
    {
        static void Main(string[] args)
        {
            int[] x = new int[1000000];
            int[] y = new int[1000000];


            Stopwatch stopwatch = new Stopwatch();

            // Original loops
            stopwatch.Start();
            for (int k = 0; k < 1000000; k++)
            {
                x[k] = k * 2;
            }

            for (int k = 0; k < 1000000; k++)
            {
                y[k] = k + 3;
            }
            stopwatch.Stop();
            Console.WriteLine($"Time taken for original loops: {stopwatch.ElapsedMilliseconds} ms");

            // Loop jamming
            stopwatch.Reset();
            stopwatch.Start();
            for (int k = 0; k < 1000000; k++)
            {
                x[k] = k * 2;
                y[k] = k + 3;
            }
            stopwatch.Stop();
            Console.WriteLine($"Time taken for loop after jamming: {stopwatch.ElapsedMilliseconds} ms");
            Utility.StudentInfo("6(b)");
        }
    }
}
