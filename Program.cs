using System;
using System.Threading;

namespace QUETE_MultiThreading2
{
    class Program
    {
        private static Mutex mutex = new Mutex();
        private const int numIterations = 1;
        private const int numThreads = 6;
        static void Main(string[] args)
        {
            Console.WriteLine("Two horses make a race : Coyote (Number 1), Bipbip (Number 2), Tom (Number 3), Jerry (Number 4), Batman (Number 5) and Superman (Number 6)");

            Program ex = new Program();
            ex.StartThreads();
        }

        private void StartThreads()
        {
            for (int i = 0; i < numThreads; i++)
            {
                Thread newThread = new Thread(new ThreadStart(ThreadProc));
                newThread.Name = String.Format("Horse n°{0}", i + 1);
                newThread.Start();
            }
        }

        private static void ThreadProc()
        {
            for (int i = 0; i < numIterations; i++)
            {
                StartRace();
            }

            for (int i = 0; i < numIterations; i++)
            {
                EndRace();
            }
        }

        private static void StartRace()
        {
            Console.WriteLine("{0} waits to start", Thread.CurrentThread.Name);
            if (mutex.WaitOne(1000))
            {
                Console.WriteLine("{0} starts running",
                    Thread.CurrentThread.Name);

                Thread.Sleep(5000);

                mutex.ReleaseMutex();

                Thread.Sleep(3000);
                Console.WriteLine("We start the last round !");

            }
            else
            {
                Console.WriteLine("{0} is still running",
                                  Thread.CurrentThread.Name);
            }
        }

        private static void EndRace()
        {
            if (mutex.WaitOne(1000))
            {
                Thread.Sleep(4000);
                Console.WriteLine("Oh my gosh ! {0} just broke a leg, it's horrible ! But he's still running ! {0} is incredible !! it's like he doesn't feel the pain !",
                    Thread.CurrentThread.Name);

                Thread.Sleep(5000);

                Console.WriteLine("{0} starts a sprint, blood is flowing abundantly from his leg but he is still running !",
                    Thread.CurrentThread.Name);

                mutex.ReleaseMutex();

                Thread.Sleep(3000);
                Console.WriteLine("Runners approach the finish line  ....");

                Thread.Sleep(3000);
                Console.WriteLine("The race is over ! And the winner is ....");
                Thread.Sleep(4000);
                Console.WriteLine("{0} !!!! (because he started before the other...)",
                                  Thread.CurrentThread.Name);

                Thread.Sleep(4000);

                Console.WriteLine("{0} finally died because he took too many narcotics ...",
                                  Thread.CurrentThread.Name);
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("{0} is still running",
                                  Thread.CurrentThread.Name);
            }
        }

    }
}
