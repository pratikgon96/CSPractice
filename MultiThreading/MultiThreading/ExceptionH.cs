using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class ExceptionH
    {
        public void Something()
        {
            try
            {
                Console.Write("Id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Contact Number: ");
                long contact = Convert.ToInt64(Console.ReadLine());
                Console.Write("Name: ");
                string Name = Console.ReadLine();

                ArrayList list = new ArrayList();
                list.Add(id);
                list.Add(contact);
                list.Add(Name);
                foreach (var r in list)
                {
                    Console.WriteLine(r);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Console.WriteLine("Exception Practice!");
            }
        }
    }
}
