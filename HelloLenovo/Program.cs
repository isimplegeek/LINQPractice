using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LINQPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            string seperator = GetSeparater(75, '-');
            var lstEmployee = new List<Employee>();
            var lstAddresses = new List<Address>();

            lstEmployee.Add(new Employee { ID = 1, FullName = "Hatim Ali", Location = "Sydney", DateofBirth = new DateTime(1981, 8, 11) });
            lstEmployee.Add(new Employee { ID = 2, FullName = "Mohammad", Location = "Toronto", DateofBirth = new DateTime(1991, 1, 1) });
            lstEmployee.Add(new Employee { ID = 3, FullName = "Hussain Ali", Location = "Ratlam", DateofBirth = new DateTime(1954, 1, 10) });
            lstEmployee.Add(new Employee { ID = 4, FullName = "Tayyab Hussain", Location = "Karachi", DateofBirth = new DateTime(1975, 1, 13) });
            lstEmployee.Add(new Employee { ID = 5, FullName = "M. Abizer Bhai", Location = "Sharjah", DateofBirth = new DateTime(1984, 2, 15) });
            lstEmployee.Add(new Employee { ID = 6, FullName = "Tahir Hatim", Location = "Perth", DateofBirth = new DateTime(2010, 1, 18) });
            lstEmployee.Add(new Employee { ID = 7, FullName = "Burhanuddin Hussain", Location = "Melbourne", DateofBirth = new DateTime(2014, 1, 23) });

            lstAddresses.Add(new Address { Employee = lstEmployee.Find(x => x.ID == 1), FullAddress = "Address 1", POBox = "00001" });
            lstAddresses.Add(new Address { Employee = lstEmployee.Find(x => x.ID == 2), FullAddress = "Address 2", POBox = "00002" });
            lstAddresses.Add(new Address { Employee = lstEmployee.Find(x => x.ID == 3), FullAddress = "Address 3", POBox = "00003" });
            lstAddresses.Add(new Address { Employee = lstEmployee.Find(x => x.ID == 4), FullAddress = "Address 4", POBox = "00004" });
            lstAddresses.Add(new Address { Employee = lstEmployee.Find(x => x.ID == 5), FullAddress = "Address 5", POBox = "00005" });
            lstAddresses.Add(new Address { Employee = lstEmployee.Find(x => x.ID == 6), FullAddress = "Address 61", POBox = "000061" });
            lstAddresses.Add(new Address { Employee = lstEmployee.Find(x => x.ID == 6), FullAddress = "Address 62", POBox = "000062" });

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
                                       select new { FullName = employee.FullName };

            foreach (var employee in lstSearchedEmployees)
                Console.WriteLine($"Search Results: {employee.FullName}");

            Console.WriteLine(seperator);

            // find employees with two names 
            Console.WriteLine("Find Employee with two names - Query format");
            var lstoutput3 = lstEmployee.Where(n => n.FullName.Split(' ').Length > 1);

            foreach (var employee in lstoutput3)
                Console.WriteLine($"Search Results: {employee.FullName}");

            Console.WriteLine(seperator);

            // find employees having atleast two 'a's in their 
            Console.WriteLine("Find Employee with atleast two A's in their name - Query format");
            var lstoutput4 = lstEmployee.Where(n => n.FullName.Where(c => c == (int)'a' || c == (int)'A').Count() > 1);

            foreach (var employee in lstoutput4)
                Console.WriteLine($"Search Results: {employee.FullName}");

            Console.WriteLine(seperator);

            // Group them by City and show the count per results 
            Console.WriteLine("Find Employee with atleast two A's in their name - Query format");
            var lstoutput5 = lstEmployee.GroupBy(n => n.Location);

            foreach (var grouped in lstoutput5)
                Console.WriteLine($"Search Results: {grouped.Key}: Count: {grouped.Count()}");

            Console.WriteLine(seperator);

            // Find who is the eldest
            Console.WriteLine("Eldest - Method format");
            var dblAge = lstEmployee.Max(n => (DateTime.Now - n.DateofBirth).TotalDays / 365.25);

            Console.WriteLine($"Eldest Age is: {dblAge}");

            Console.WriteLine(seperator);

            // Find someone living in Karachi
            Console.WriteLine("Employees from Karachi - Method format");
            var lstOutput6 = lstEmployee.Where(n => n.Location.ToLower() == "karachi");

            foreach (var employee in lstOutput6)
                Console.WriteLine($"Search Results: {employee.FullName}");

            Console.WriteLine(seperator);


            // find all the person born in 80s
            Console.WriteLine("Employees born in 80's - Method format");
            var lstOutput7 = lstEmployee.Where(n => n.DateofBirth.Year >= 1980 && n.DateofBirth.Year < 1990);

            foreach (var employee in lstOutput7)
                Console.WriteLine($"Search Results: {employee.FullName}");

            Console.WriteLine(seperator);

            // Group the ages in the zone of 10s like group people who are in their 10 or 20 and so on
            Console.WriteLine("Employees grouped in age zones - Method format");
            var lstOutput8 = lstEmployee.Select(n => ((DateTime.Now - n.DateofBirth).TotalDays / 365.25) / 10)
                                        .Select(k => (Math.Floor(k) * 10 == 0) ? 10 : Math.Floor(k) * 10)
                                        .OrderBy(k => k)
                                        .GroupBy(g => g);

            foreach (var grouped in lstOutput8)
                Console.WriteLine($"Search Results: {grouped.Key} : Count {grouped.Count()}");

            Console.WriteLine(seperator);

            // find the person with the longest name 
            Console.WriteLine("Person with longest Name - Method format");
            var result9 = lstEmployee.Aggregate((x, y) => (x.FullName.Length > y.FullName.Length) ? x : y);

            Console.WriteLine($"Search Results: {result9.FullName}");

            Console.WriteLine(seperator);


            // find the person with the shortest Name      
            Console.WriteLine("Person with shortest Name - Method format");
            var result10 = lstEmployee.Aggregate((x, y) => (x.FullName.Length < y.FullName.Length) ? x : y);

            Console.WriteLine($"Search Results: {result10.FullName}");

            Console.WriteLine(seperator);

            // left outer join address and employee and list name of each employee along with his address

            var lstOutput10 = lstEmployee.GroupJoin(lstAddresses, x => x.ID, y => y.Employee.ID, (x,y) => new { Employee = x, Addresses = y})
                                          .DefaultIfEmpty()
                                          .Select(s => new { FullName = s.Employee.FullName, Addresses = s.Addresses});


            foreach (var result in lstOutput10)
                Console.WriteLine($"Full Name: {result.FullName}, Address: {result.Addresses.Count()}");

            Console.WriteLine(seperator);

            // use expression tree
            // use Func
            // use both query as well as method syntax for all the above 
            // use lamda as much as possible
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

        public class Address
        {
            public Employee Employee { get; set; }
            public string FullAddress { get; set; }

            public string POBox { get; set; }
        }
    }
}    