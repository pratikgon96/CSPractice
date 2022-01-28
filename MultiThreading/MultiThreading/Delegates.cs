using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    public delegate void delmethod(int x, int y);
    public class Delegates
    {
        public void plus_Method1(int x, int y)
        {
            Console.Write("You are in plus_Method");
            int res = (x + y);
            Console.WriteLine(res);
        }

        public void subtract_Method2(int x, int y)
        {
            Console.Write("You are in subtract_Method");
            int res = (x - y);
            Console.WriteLine(res);
        }


        static FileStream fs;
        static StreamWriter sw;
        public delegate void printString(string s);

        public static void WriteToScreen(string str)
        {
            Console.WriteLine("The String is: {0}", str);
        }

        public static void WriteToFile(string s)
        {
            fs = new FileStream(@"F:\New\File.txt",
            FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs);
            sw.WriteLine(s);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        public static void sendString(printString ps)
        {
            ps("Hello World");
        }

    }

    public class PredicateDelegate
    {
        public static bool myfun(string mystring)
        {
            if (mystring.Length < 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
