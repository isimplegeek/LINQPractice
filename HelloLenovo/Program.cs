using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            string seperator = GetSeparater(75, '='); 
            var lstEmployee = new List<Employee>();

            lstEmployee.Add(new Employee { ID = 1, FullName = "Hatim Ali", Location = "Sydney", DateofBirth=new DateTime(1981, 8, 11)});
            lstEmployee.Add(new Employee { ID = 2, FullName = "Mohammad", Location = "Toronto", DateofBirth=new DateTime(1991, 1, 1)});
            lstEmployee.Add(new Employee { ID = 3, FullName = "Hussain Ali", Location = "Ratlam", DateofBirth = new DateTime(1954, 1, 10) });
            lstEmployee.Add(new Employee { ID = 4, FullName = "Tayyab Hussain", Location = "Karachi", DateofBirth = new DateTime(1975, 1, 13) });
            lstEmployee.Add(new Employee { ID = 5, FullName = "M. Abizer Bhai", Location = "Sharjah", DateofBirth = new DateTime(1984, 2, 15) });
            lstEmployee.Add(new Employee { ID = 6, FullName = "Tahir Hatim", Location = "Perth", DateofBirth = new DateTime(2010, 1, 18) });
            lstEmployee.Add(new Employee { ID = 7, FullName = "Burhanuddin Hussain", Location = "Melbourne", DateofBirth = new DateTime(2014, 1, 23) });

            // questions:

            // Sort them by Name
            // desc and asc order by 
            Console.WriteLine("Ordering list by Name - Query format");
            var lstSortedEmployees = from employee in lstEmployee
                                     orderby employee.FullName descending
                                     select employee;

            foreach (var employee in lstSortedEmployees)
                Console.WriteLine($"Name: {employee.FullName}, \t\t\t Location: {employee.Location}");

            Console.WriteLine(seperator);

            Console.WriteLine("Ordering list by Name - Method Format");
            var lstOrderbyMethod = lstEmployee.OrderByDescending(x => x.FullName).ThenByDescending(x => x.Location);

            foreach (var employee in lstOrderbyMethod)
                Console.WriteLine($"Name: {employee.FullName}, \t\t\t Location: {employee.Location}");

            Console.WriteLine(seperator);


            // find an employee whose name start with an H
            Console.WriteLine("Find Employee whose name starts with H - Query format");
            var lstSearchedEmployees = from employee in lstEmployee
                                       where employee.FullName.ToLower().StartsWith("h")
                                       select new {FullName = employee.FullName };

            foreach (var employee in lstSearchedEmployees)
                Console.WriteLine($"Search Results: {employee.FullName}");

            Console.WriteLine(seperator);

            // find employees with two names 
            // find employees having atleast two 'a's in their 
            // Group them by City and show the count per results 
            // Find who is the eldest
            // Find someone living in Lahore
            // find all the person born in 80s
            // Group the ages in the zone of 10s like group people who are in their 10 or 20 and so on
            // find the person with the longest name 
            // find the person with the shortest Name      

            // use expression tree
            // use Func
            // use both quesry as well as method syntax for all the above 
            // use lamda as must as possible
            // build more complicated queries using joins 
            // open the linq reference and use as much reference as possible 


            // Select ID and Name and Location and populate it into a new list

            Console.Read();
        }

        public static string GetSeparater(uint length, char c)
        {
            string separater = string.Empty;
            for (int i = 0; i < length; i++)
                separater += c.ToString();
            return separater;
        }

        public class Employee
        {
            public int ID{ get; set; }
            public string FullName { get; set; }
            public string Location { get; set; }
            public DateTime DateofBirth { get; set; }
        }
    }
}    