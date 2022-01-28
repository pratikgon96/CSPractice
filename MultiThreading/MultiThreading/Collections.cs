using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class Collections
    {
        public void List()
        {
            Console.WriteLine("---------------------------------------------------");
            List<string> list = new List<string>() { "Good", "Bad", "Ugly" };
            list.ForEach(x => Console.WriteLine(x));

            var numbers = new List<int>() { 1, 2, 3, 4, 5 };
            int x = numbers.Count(i => i > 3);
            Console.WriteLine(x);
            numbers.Where(x => x > 2)
                .ToList()
                .ForEach(x => Console.WriteLine(x));

        }

        public void HashTable()
        {
            Hashtable hashtable = new Hashtable();
            Console.WriteLine("---------HashTable----------");
            hashtable.Add(1, "Pool");
            hashtable.Add(2, "placid");
            hashtable.Add("4", "Pirana");
            hashtable.Add(5, null);
            //hashtable.Add(1, "Plastic");
            foreach (DictionaryEntry de in hashtable)
            {
                Console.WriteLine("Key: {0}, Value: {1}", de.Key, de.Value);
            }
        }
        public void hashSet()
        {
            HashSet<string> myhash1 = new HashSet<string>();

            myhash1.Add("C");
            myhash1.Add("C++");
            myhash1.Add("C#");
            myhash1.Add("Java");
            myhash1.Add("Ruby");

            HashSet<string> myhash2 = new HashSet<string>();

            // Using Add method
            myhash2.Add("PHP");
            myhash2.Add("C++");
            myhash2.Add("Perl");
            myhash2.Add("Java");

            // Using UnionWith method
            Console.WriteLine("-----------Union Output-------");
            myhash1.UnionWith(myhash2);
            foreach (var ele in myhash1)
            {
                Console.WriteLine(ele);
            }
            // Using IntersectionWith method
            Console.WriteLine("-----------Intersection Output-------");
            myhash1.IntersectWith(myhash2);
            foreach (var ele in myhash1)
            {
                Console.WriteLine(ele);
            }

            Console.WriteLine("-----------ExceptionWith Output-------");
            myhash1.ExceptWith(myhash2);
            foreach (var ele in myhash1)
            {
                Console.WriteLine(ele);
            }
        }

        public void Stack()
        {
            Stack myStack = new Stack();
            Console.WriteLine("------------Stack---------");
            myStack.Push("1st Element");
            myStack.Push("2nd Element");
            myStack.Push("3rd Element");
            myStack.Push("4th Element");

            // Creating copy using Clone() method
            Stack myStack3 = (Stack)myStack.Clone();

            // Removing top most element
            myStack3.Pop();
            PrintValues(myStack3);
        }

        public static void PrintValues(IEnumerable myCollection)
        {
            foreach (Object obj in myCollection)
                Console.WriteLine(obj);
        }

        public void Dictionary()
        {
            Dictionary<string, Int16> AuthorList = new Dictionary<string, Int16>();
            Console.WriteLine("-----------Dictionary-------------");
            AuthorList.Add("Pratik Gon", 25);
            AuthorList.Add("Anubhab Barik", 25);
            AuthorList.Add("Argha Gon", 34);
            AuthorList.Add("Subhajoy", 22);
            Console.WriteLine("Count: {0}", AuthorList.Count);

            if (!AuthorList.ContainsKey("Nabanita Maji"))
            {
                AuthorList["Nabanita Maji"] = 20;
            }
            if (!AuthorList.ContainsValue(9))
            {
                Console.WriteLine("Item found");
            }

            Console.WriteLine("Authors: ");
            foreach (KeyValuePair<string, Int16> author in AuthorList)
            {
                Console.WriteLine("Key: {0}, Value: {1}", author.Key, author.Value);
            }
            AuthorList.Remove("Subhajoy");
            Console.WriteLine("Authors after Remove: ");
            foreach (KeyValuePair<string, Int16> author in AuthorList)
            {
                Console.WriteLine("Key: {0}, Value: {1}", author.Key, author.Value);
            }
        }
    }
}
