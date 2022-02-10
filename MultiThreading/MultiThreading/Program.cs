using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using static MultiThreading.Delegates;

namespace MultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            //Generics();

            //ExceptionMethod();

            //WriteBinaryFile();
            //ReadBinaryFile();

            //LinqPractice linqPractice = new();
            //linqPractice.LinqList();

            //ThreadingMethods();

            //CollectionMethods();

            //Console.WriteLine("---------------Delegate Method-------------------");
            //DelegateCall();
            //DelegateCall2();

            //Console.WriteLine("---------------Events------------");
            //Events events = new();
            //events.EventExmpl();

            Console.WriteLine("------------------------------Ado.Net-----------------------------");
            AdoDotNet ado = new();
            ado.Options();


        }

        static void ExceptionMethod()
        {
            Console.WriteLine("---------------Exception Handling-----------");
            ExceptionH exception = new ExceptionH();
            try
            {
                exception.Something();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("---------------Exception Handling 2-----------");
            try
            {
                throw new MyException();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occoured! " + e.ToString());
            }
        }

        static void WriteBinaryFile()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(@"F:\New\File.txt", FileMode.Create)))
            {

                writer.Write(12.5);
                writer.Write("this is string data");
                writer.Write(true);
            }
        }
        static void ReadBinaryFile()
        {
            using (BinaryReader reader = new BinaryReader(File.Open(@"F:\New\File.txt", FileMode.Open)))
            {
                Console.WriteLine("Double Value : " + reader.ReadDouble());
                Console.WriteLine("String Value : " + reader.ReadString());
                Console.WriteLine("Boolean Value : " + reader.ReadBoolean());
            }
        }

        public static void Generics()
        {
            Console.WriteLine("------------------------Generics------------------------");
            bool eq = AreEqual<Int32>(Convert.ToInt32(10), Convert.ToInt32(10));
            if (eq)
            {
                Console.WriteLine("Passed");
            }
            else
            {
                Console.WriteLine("Failed");
            }

            bool eq1 = AreEqual<string>("passion", "passion");
            Console.WriteLine(eq1);
        }
        static bool AreEqual<T>(T value1, T value2)
        {
            bool eq = value1.Equals(value2);
            return eq;
        }

        static bool AreEqual(object value1, object value2)
        {
            bool eq = value1.Equals(value2);
            return eq;
        }

        public static void CollectionMethods()
        {
            Collections collections = new Collections();
            Console.WriteLine("------------------------HashSet-----------------------");
            collections.hashSet();
            Console.WriteLine("-----------------------------Stack--------------------------------");
            collections.Stack();
            Console.WriteLine("-----------------------------Dictionary--------------------------------");
            collections.Dictionary();
            Console.WriteLine("-----------------------------List--------------------------------");
            collections.List();
            Console.WriteLine("-----------------------------HashTable--------------------------------");
            collections.HashTable();
            Console.WriteLine("-----------------NameValueCollection---------------------");
            collections.NameValueCollection();
        }

        public static void ThreadingMethods()
        {
            //Console.WriteLine("-------------------------------BackGround Thread----------------------------------");
            //MultiThreadingPractice.BackGroundThread();//Thread which stop functioning when main thread completes its work.
            //Console.WriteLine("-------------------------------ForeGround Thread----------------------------------");
            //MultiThreadingPractice.ForeGroundThread();// Doesn't depend on main thread, it keep running until it completes it execution.
            //Console.WriteLine("-------------------------------Thread State----------------------------------");
            //MultiThreadingPractice.ThreadState();
            //Console.WriteLine("-------------------------------Priority Thread----------------------------------");
            //MultiThreadingPractice.PriorityThread();
            //Console.WriteLine("-------------------------------Join Thread----------------------------------");
            //MultiThreadingPractice.JoinThread();
            //Console.WriteLine("-------------------------------Deadlock in threading----------------------------------");
            //MultiThreadingPractice.Deadlock();
            //Console.WriteLine("-------------------------------Semaphore in threading----------------------------------");
            //MultiThreadingPractice.SemaphoreThread();

            Console.WriteLine("-------------------------------Task----------------------------------");
            MultiThreadingPractice.TaskManagement();


            Console.WriteLine("-------------------------------Task with return type----------------------------------");
            MultiThreadingPractice.TaskManagement1();
        }

        public static void DelegateCall()
        {
            Delegates delegates = new();
            delmethod del = new delmethod(delegates.plus_Method1);
            del(43, 17);
            del.Invoke(12, 15);
            //Multicast Delegate
            del += delegates.subtract_Method2;
            del(43, 17);

            del -= delegates.plus_Method1;
            del(17, 11);

            Action<int, int> val = delegates.plus_Method1;
            val(12, 15);
        }

        public static void DelegateCall2()
        {
            printString p1 = new(WriteToScreen);
            printString p2 = new(WriteToFile);
            sendString(p1);
            sendString(p2);
        }
    }
    //can create our own exception class by inheriting system.exception class.
    class MyException : Exception
    {
        public MyException()
        {
            Console.WriteLine("User defined exception");
        }
    }
}
