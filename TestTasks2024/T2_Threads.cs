using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TestsProject")]

namespace TestTasks2024
{
    /// <summary>
    /// There are two threads.
    /// The first one prints "ping", the second one prints "pong".
    /// Write code that synchronizes these two threads and sequentially prints "ping" and "pong".
    /// </summary>
    internal class T2_Threads
    {
        private static readonly AutoResetEvent _autoResetEvent = new AutoResetEvent(false);

        public static void PingPong_Variant_1()
        {
            Thread thread1 = new Thread(() =>
            {
                _autoResetEvent.Set();
                Console.WriteLine("ping");
                Thread.Sleep(1000);
            });

            Thread thread2 = new Thread(() =>
            {
                _autoResetEvent.WaitOne();
                Console.WriteLine("pong");
            });

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("The End of varinat 1.");
        }

        public static void PingPong_Variant_2()
        {
            Thread thread1 = new Thread(() => DoWork("Ping", 1000, 1));
            Thread thread2 = new Thread(() => DoWork("Pong", 10, 2));
            thread1.Start();
            thread1.Join();
            thread2.Start();
            thread2.Join();
            Console.WriteLine("The End of variant 2.");
        }

        private static void DoWork(string word, int timeout, int num)
        {
            Thread.Sleep(timeout);
            Console.WriteLine(word);
        }

        public static async void PingPong_Variant_3()
        {
            await Task.Run(() => Console.WriteLine("let's go!"));

            await Task.Run(() =>
            {
                Task.Delay(1000);
                Console.WriteLine("ping");
            });

            await Task.Run(() => Console.WriteLine("pong"));

            await Task.Run(() => Console.WriteLine("done!"));
        }
    }
}