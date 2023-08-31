using System;
using System.Diagnostics;

namespace CDC_Lab
{
    class LoopOptimization
    {
        static void Main(string[] args)
        {
            // Program 1
            long t1 = RunProgram1();
            Console.WriteLine($"Running time of Program 1: {t1} ms");

            // Program 2
            long t2 = RunProgram2();
            Console.WriteLine($"Running time of Program 2: {t2} ms");

            // Compare running times
            if (t1 < t2)
            {
                Console.WriteLine("Program 1 is faster.");
            }
            else if (t2 < t1)
            {
                Console.WriteLine("Program 2 is faster.");
            }
            else
            {
                Console.WriteLine("Both programs have similar running times.");
            }
            Utility.StudentInfo("6(a)");
        }
        static long RunProgram1()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int a, b = 10, c, d = 20, e = 30, f, g = 40, h = 50;

            for (int i = 0; i < 1000000000; i++)
            {
                a = b + i;
                c = d + e;
                f = g + h;
            }

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        static long RunProgram2()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int a, b = 10, c, d = 20, e = 30, f, g = 40, h = 50;

            c = d + e;
            f = g + h;

            for (int i = 0; i < 1000000000; i++)
            {
                a = b + i;
            }

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}
