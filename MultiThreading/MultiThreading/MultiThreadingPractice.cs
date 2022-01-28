using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class MultiThreadingPractice
    {
        public static void ForeGroundThread()
        {
            for (int c = 0; c <= 3; c++)
            {

                Console.WriteLine("mythread is in progress!!");
                Thread.Sleep(1000);
            }
            Console.WriteLine("mythread ends!!");
        }

        public static void BackGroundThread()
        {
            Console.WriteLine("In progress thread is: {0}",
                            Thread.CurrentThread.Name);

            Thread.Sleep(2000);

            Console.WriteLine("Completed thread is: {0}",
                              Thread.CurrentThread.Name);
        }

        public static void ThreadState()
        {
            Thread TR1 = new Thread(new ThreadStart(job));
            Thread TR2 = new Thread(new ThreadStart(job));

            Console.WriteLine("ThreadState of TR1 thread" + " is: {0}", TR1.ThreadState);

            Console.WriteLine("ThreadState of TR2 thread" + " is: {0}", TR2.ThreadState);

            TR1.Start();
            Console.WriteLine("ThreadState of TR1 thread " + "is: {0}", TR1.ThreadState);

            TR2.Start();
            Console.WriteLine("ThreadState of TR2 thread" + " is: {0}", TR2.ThreadState);
        }
        public static void job()
        {
            Thread.Sleep(2000);
        }


        public static void PriorityThread()
        {
            Thread THR1 = new Thread(job);
            Thread THR2 = new Thread(job);
            Thread THR3 = new Thread(job);

            // Set the priority of threads
            THR2.Priority = ThreadPriority.Lowest;
            THR3.Priority = ThreadPriority.AboveNormal;
            THR1.Start();
            THR2.Start();
            THR3.Start();
            Console.WriteLine("The priority of Thread 1 is: {0}", THR1.Priority);

            Console.WriteLine("The priority of Thread 2 is: {0}",
                                                  THR2.Priority);

            Console.WriteLine("The priority of Thread 3 is: {0}",
                                                  THR3.Priority);
        }

        public static void JoinThread()
        {

            Thread thr1 = new Thread(new ThreadStart(mythread));
            Thread thr2 = new Thread(new ThreadStart(mythread1));
            thr1.Start();
            thr1.Join();
            thr2.Start();
            Console.WriteLine("Current application domain: {0}", Thread.GetDomain().FriendlyName);
        }

        public static void mythread()
        {
            for (int x = 0; x < 4; x++)
            {
                Console.WriteLine(x);
                Thread.Sleep(100);
            }
        }

        public static void mythread1()
        {
            Console.WriteLine("2nd thread is Working..");
        }


        static object obj1 = new object();
        static object obj2 = new object();
        public static void DeadLock1()
        {
            lock (obj1)
            {
                Console.WriteLine("Thread 1 got locked");
                Thread.Sleep(500);
                lock (obj2)
                {
                    Console.WriteLine("Thread 2 got locked");
                }
            }
        }
        public static void DeadLock2()
        {
            lock (obj2)
            {
                Console.WriteLine("Thread 2 got locked");
                Thread.Sleep(500);
                lock (obj1)
                {
                    Console.WriteLine("Thread 1 got locked");
                }
            }
        }
        public static void Deadlock()
        {
            Thread t1 = new Thread(new ThreadStart(DeadLock1));
            Thread t2 = new Thread(new ThreadStart(DeadLock2));
            t1.Start();
            t2.Start();
            Console.ReadKey();
        }

        static Semaphore obj = new Semaphore(2, 4);
        public static void SemaphoreThread()
        {
            for (int i = 1; i <= 5; i++)
            {
                new Thread(SempStart).Start(i);
            }
            Console.ReadKey();
        }
        static void SempStart(object id)
        {
            Console.WriteLine(id + "-->>Wants to Get Enter");
            try
            {
                obj.WaitOne();
                Console.WriteLine(" Success: " + id + " is in!");
                Thread.Sleep(2000);
                Console.WriteLine(id + "<<-- is Evacuating");
            }
            finally
            {
                obj.Release();
            }
        }

        public static void TaskManagement()
        {
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Statred");
            //Task task1 = Task.Factory.StartNew(PrintCounter);
            //Task task1 = new Task(PrintCounter);
            //task1.Start();
            Task task1 = Task.Run(() => { PrintCounter(); });
            task1.Wait();
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
            Console.ReadKey();
        }

        public static void TaskManagement1()
        {
            Console.WriteLine($"Main Thread Started");
            Task<double> task1 = Task.Run(() =>
            {
                double sum = 0;
                for (int count = 1; count <= 10; count++)
                {
                    sum += count;
                }
                return sum;
            });

            Console.WriteLine($"Sum is: {task1.Result}");
            Console.WriteLine($"Main Thread Completed");
            Console.ReadKey();
        }

        static void PrintCounter()
        {
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
            for (int count = 1; count <= 5; count++)
            {
                Console.WriteLine($"count value: {count}");
            }
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
        }
    }
}
