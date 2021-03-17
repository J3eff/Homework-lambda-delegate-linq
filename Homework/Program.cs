using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using Homework.Entities;


namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            Console.Write("Enter salary: ");
            double avarageWage = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            List<Employee> list = new List<Employee>();

            using(StreamReader  sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] vact = sr.ReadLine().Split(',');
                    string name = vact[0];
                    string email = vact[1];
                    double salary = double.Parse(vact[2], CultureInfo.InvariantCulture);

                    list.Add(new Employee(name, email, salary));
                }
            }

            Console.WriteLine("Email of people whose salary is more than {0}:", avarageWage.ToString("F2", CultureInfo.InvariantCulture));

            var emails = list.Where(e => e.Salary > avarageWage).OrderBy(e => e.Email).Select(e => e.Email);
            foreach(string email in emails)
            {
                Console.WriteLine(email);
            }

            var sumSalary = list.Where(e => e.Name[0] == 'M').Sum(e => e.Salary);
            Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sumSalary.ToString("F2", CultureInfo.InvariantCulture));
            
        }
    }
}
