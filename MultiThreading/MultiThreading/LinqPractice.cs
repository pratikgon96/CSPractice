using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }

    }
    public class LinqPractice
    {
        
        public void LinqList()
        {
            IList<string> stringList = new List<string>() {
                "C# Tutorials",
                "VB.NET Tutorials",
                "Learn C++",
                "MVC Tutorials" ,
                 "Java"
            };

            var result = from s in stringList
                         where s.Contains("Tutorials")
                         select s;

            foreach (var i in result)
            {
                Console.WriteLine(i);
            }

            var resultMethod = stringList.Where(s => s.Contains("Tutorials"));
            resultMethod.ToList().ForEach(x => Console.WriteLine("Mehod course: " + x));


            IList<Student> studentList = new List<Student>() {
                    new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                    new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                    new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                    new Student() { StudentID = 5, StudentName = "Abram" , Age = 21 }
            };

            var groupedResult = studentList.GroupBy(s => s.Age);

            foreach (var ageGroup in groupedResult)
            {
                Console.WriteLine("Age Group: {0}", ageGroup.Key);  //Each group has a key 

                foreach (Student s in ageGroup)  //Each group has a inner collection  
                    Console.WriteLine("Student Name: {0}", s.StudentName);
            }


            IList<string> strList = new List<string>() {
                                            "One",
                                            "Two",
                                            "Three",
                                            "Four",
                                            "Five",
                                            "Six"  };

            var resultList = strList.SkipWhile(s => s.Length < 4);
            //It returns a new collection that includes all the remaining elements once the specified condition becomes false for any element.
            foreach (string str in resultList)
                Console.WriteLine(str);


            IList<string> strList1 = new List<string>() {
                                            "Three",
                                            "Four",
                                            "Five",
                                            "Hundred"  };

            var result1 = strList1.TakeWhile(s => s.Length > 4);

            foreach (string str in result1)
                Console.WriteLine(str);
        }
    }
}
