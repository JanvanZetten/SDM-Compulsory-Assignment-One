using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Xunit.Abstractions;

namespace SDM_Movie_Rating_SpeedTest
{
    public class Timer
    {
        /// <summary>
        /// Calculates CPU time for action 'passenAction'.
        /// </summary>
        /// <param name="passedAction">Action which is timed</param>
        /// <param name="outputHelper">TestOutputHelper to save Real time and User time to test output</param>
        /// <returns></returns>
        public static double GetUserCPUTime(Action passedAction, ITestOutputHelper outputHelper)
        {
            #region Prevent compiler optimization for more exact timing
            long seed = Environment.TickCount;  // Prevents the JIT Compiler 
                                                // from optimizing Fkt calls away
            long result = 0;
            int count = 100000000;

            Stopwatch watch = new Stopwatch();
            watch.Start();
            while (watch.ElapsedMilliseconds < 1200)  // A Warmup of 1000-1500 mS 
                                                      // stabilizes the CPU cache and pipeline.
            {
                result = TestFunction(seed, count); // Warmup
            }
            watch.Stop();
            watch.Reset();
            #endregion

            watch.Start();
            Process p = Process.GetCurrentProcess();
            double startUserProcessorTm = p.UserProcessorTime.TotalMilliseconds;

            passedAction();

            double endUserProcessorTm = p.UserProcessorTime.TotalMilliseconds;
            watch.Stop();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                startUserProcessorTm /= 100;
                endUserProcessorTm /= 100;
            }

            outputHelper.WriteLine("Real Time: " + watch.Elapsed.TotalMilliseconds + "ms");
            outputHelper.WriteLine("User CPU Time: " + (endUserProcessorTm - startUserProcessorTm) + "ms");

            return endUserProcessorTm - startUserProcessorTm;
        }

        /// <summary>
        /// Function to prevent some compiler optimization.
        /// </summary>
        private static long TestFunction(long seed, int count)
        {
            long result = seed;
            for (int i = 0; i < count; ++i)
            {
                result ^= i ^ seed; // Some useless bit operations
            }
            return result;
        }
    }
}
