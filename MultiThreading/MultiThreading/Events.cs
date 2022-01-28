using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    public delegate void Transformer(int x);
    public class Events
    {
        public void EventExmpl()
        {
            Console.WriteLine("Please enter a number: ");
            int i = Convert.ToInt32(Console.ReadLine());
            Transformer t;
            t = Square;
            t += Cube;
            t(i);
            Notification notification = new();
            notification.transformerEvent += User1.handler1;
            notification.transformerEvent += User2.handler2;
            notification.NotifyOnCall(i);

            Console.ReadLine();
        }

        public static void Square(int x)
        {
            Console.WriteLine(x * x);
        }

        public static void Cube(int x)
        {
            Console.WriteLine(x * x * x);
        }
    }
    //publisher
    public class Notification
    {
        public event Transformer transformerEvent;
        public void NotifyOnCall(int x)
        {
            if (transformerEvent != null)
            {
                transformerEvent(x);
            }
        }
    }
    //Subscribers
    public class User1
    {
        public static void handler1(int x)
        {
            Console.WriteLine("Event received by User1 handler!");
            
        }
    }

    public class User2
    {
        public static void handler2(int x)
        {
            Console.WriteLine("Event received by User2 handler!");
        }
    }
}
