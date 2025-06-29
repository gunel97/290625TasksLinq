using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static _290625Task.Program;

namespace _290625Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // List of numbers
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 15, 20, 25, 30 };

            // List of strings
            var cities = new List<string> { "New York", "London", "Tokyo", "Paris", "Berlin", "Sydney", "Toronto", "Mumbai", "Barcelona" };

            // List of employees
            var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "John Smith", Department = "IT", Salary = 75000, Age = 28 },
                new Employee { Id = 2, Name = "Sarah Johnson", Department = "HR", Salary = 65000, Age = 32 },
                new Employee { Id = 3, Name = "Mike Wilson", Department = "IT", Salary = 85000, Age = 35 },
                new Employee { Id = 4, Name = "Emily Davis", Department = "Finance", Salary = 70000, Age = 29 },
                new Employee { Id = 5, Name = "David Brown", Department = "IT", Salary = 95000, Age = 40 },
                new Employee { Id = 6, Name = "Lisa Garcia", Department = "Marketing", Salary = 60000, Age = 26 },
                new Employee { Id = 7, Name = "Robert Taylor", Department = "Finance", Salary = 80000, Age = 38 },
                new Employee { Id = 8, Name = "Jennifer Lee", Department = "HR", Salary = 55000, Age = 24 }
            };

            // List of orders
            var orders = new List<Order>
            {
            new Order { Id = 1, CustomerName = "Alice", Amount = 150.50m, OrderDate = new DateTime(2024, 1, 15) },
            new Order { Id = 2, CustomerName = "Bob", Amount = 89.99m, OrderDate = new DateTime(2024, 2, 10) },
            new Order { Id = 3, CustomerName = "Alice", Amount = 200.00m, OrderDate = new DateTime(2024, 1, 25) },
            new Order { Id = 4, CustomerName = "Charlie", Amount = 75.25m, OrderDate = new DateTime(2024, 3, 5) },
            new Order { Id = 5, CustomerName = "Bob", Amount = 120.75m, OrderDate = new DateTime(2024, 2, 20) },
            new Order { Id = 6, CustomerName = "Diana", Amount = 300.00m, OrderDate = new DateTime(2024, 1, 30) }
            };


            //TASK 1
            Console.WriteLine("*****TASK 1*****");
            var evenNumbersTask1 = numbers.Where(x => x % 2 == 0);
            evenNumbersTask1.Print();

            //TASK 2

            Console.WriteLine("*****TASK 2*****");
            var citiesTask2 = cities.Where(x => x.StartsWith("L") || x.StartsWith("T"));
            citiesTask2.Print();

            //TASK3
            Console.WriteLine("*****TASK 3*****");
            var employeesTask3 = employees.Where(x => x.Salary > 70000);
            employeesTask3.Print();

            //TASK4
            Console.WriteLine("*****TASK 4*****");
            var employeesTask4 = employees.Where(x => x.Age < 30);
            employeesTask4.Print();

            //TASK5
            Console.WriteLine("*****TASK 5*****");
            var listSquaresTask5 = numbers.Select(x => x * x);
            listSquaresTask5.Print();

            //TASK6
            Console.WriteLine("*****TASK 6*****");
            var citiesLengthTask6 = cities.Select(x => new
            {
                city = x,
                length = x.Length,
            });

            foreach (var item in citiesLengthTask6)
            {
                Console.WriteLine($"{item.city} , {item.length}");
            }

            //TASK7
            Console.WriteLine("*****TASK 7*****");
            var employeeNames = employees.Select(x => x.Name).ToList();
            employeeNames.Print();

            //TASK8
            Console.WriteLine("*****TASK 8*****");
            var averageSalary = employees.Select(x => x.Salary).Average();

            var employeesSalaryAveTask8 = employees.Select(x => new
            {
                name = x.Name,
                department = x.Department,
                IsAbove = (x.Salary > averageSalary)
            });

            foreach (var item in employeesSalaryAveTask8)
            {
                Console.WriteLine($"{item.name} ({item.department}) - Above Average: {item.IsAbove}");
            }

            //TASK9
            Console.WriteLine("*****TASK 9*****");
            var citiesSortedTask9 = cities.Order();
            citiesSortedTask9.Print();

            //TASK10
            Console.WriteLine("*****TASK 10*****");
            var employeesSortedTask10 = employees.OrderByDescending(x => x.Salary);
            employeesSortedTask10.Print();

            //TASK11    
            Console.WriteLine("*****TASK 11*****");
            var employeesSortedTask11 = employees.OrderBy(x => x.Department).ThenBy(x => x.Age);
            employeesSortedTask11.Print();

            //TASK12
            Console.WriteLine("*****TASK 12*****");
            var numbersSortedTask12 = numbers.OrderDescending();
            numbersSortedTask12.Print();

            //TASK13
            Console.WriteLine("*****TASK 13*****");
            var groupEmployeesTask13 = employees.GroupBy(x => x.Department);

            foreach (var item in groupEmployeesTask13)
            {
                Console.WriteLine($"{item.Key}: {item.Count()} employees");
            }

            //TASK14

            Console.WriteLine("*****TASK 14*****");

            var orderGroupedTask14 = orders.GroupBy(x => x.CustomerName);

            foreach (var item in orderGroupedTask14)
            {
                Console.WriteLine($"{item.Key}: ${item.Sum(x => x.Amount)} total");
            }

            //TASK15
            Console.WriteLine("*****TASK 15*****");
            var numbersGroupedOdd = from number in numbers
                                    group number by number % 2;

            foreach (var item in numbersGroupedOdd)
            {
                Console.Write(item.Key == 0 ? "\nEven:" : "\nOdd:");
                foreach (int i in item)
                {
                    Console.Write($"{i}, ");
                }
                Console.WriteLine();
            }


            //TASK16
            Console.WriteLine("*****TASK 16*****");
            var averageSalaryTask16 = employees.Select(x => x.Salary).Average();
            Console.WriteLine("$ " + averageSalaryTask16);

            //TASK17
            Console.WriteLine("*****TASK 17*****");

            var groupEmployeesTask17 = employees.GroupBy(x => x.Department);

            foreach (var item in groupEmployeesTask13)
            {
                Console.WriteLine($"{item.Key}: {item.Count()} employees, average salary: ${item.Average(x => x.Salary)} ");
            }

            //TASK18
            Console.WriteLine("*****TASK 17*****");
            var sumTask18 = numbers.Select(x => x).Sum();
            var CompareTask18 = numbers.Where(x => x > 5).Count();

            Console.WriteLine($"Sum: {sumTask18}, Count>5: {CompareTask18}");

            //Task19
            Console.WriteLine("*****TASK 19*****");
            var oldestAgeTask19 = employees.Select(x => x.Age).Max();
            var youngestAgeTask19 = employees.Select(x => x.Age).Min();

            Console.WriteLine($"Youngest: {youngestAgeTask19}, Oldest: {oldestAgeTask19}");

            //TASK20
            Console.WriteLine("*****TASK 20*****");

            var Task20 = employees.Select(x => x);
            foreach (var item in Task20)
            {
                Console.WriteLine($"{item.Name} works in {item.Department} earning ${item.Salary}");
            }

            //TASK21
            Console.WriteLine("*****TASK 21*****");

            var employeesTask21 = employees.Where(x => x.Department.ToLower() == "it" && x.Salary > 80000);

            Console.WriteLine("IT employees earning >$80000");
            employeesTask21.Print();

            //TASK22
            Console.WriteLine("*****TASK 22*****");

            var employeesTask22 = employees.Where(x => (x.Name.Contains("e") || x.Name.Contains("a"))
                                  && (x.Department.ToLower() == "it" || x.Department.ToLower() == "finance"));
            employeesTask22.Print();

            //TASK23
            Console.WriteLine("*****TASK 23*****");

            var ordersTask23 = orders.Where(x => x.OrderDate > new DateTime(2024, 1, 1) && x.OrderDate < new DateTime(2024, 2, 1)).OrderBy(x => x.Amount);
            ordersTask23.Print();

            //TASK24
            Console.WriteLine("*****TASK 24*****");
            var employeesGroupTask24 = employees.GroupBy(x => x.Department);

            //.SelectMany(g => g.OrderByDescending(x=>x.Salary).Take(3));

            foreach (var item in employeesGroupTask24)
            {
                Console.WriteLine(item.Key);
                var selectTop3 = item.OrderBy(x => x.Salary).Take(3);
                selectTop3.Print();
            }

            //TASK25
            Console.WriteLine("*****TASK 25*****");
            var ordersGroupedTask25 = orders.GroupBy(x => x.CustomerName);

            foreach (var item in ordersGroupedTask25)
            {
                Console.Write($"{item.Key}: {item.Count()} orders, ");

                Console.WriteLine($"${item.Select(x => x.Amount).Sum()} total, ${item.Select(x => x.Amount).Average()} avg");
            }

            //TASK26
            Console.WriteLine("*****TASK 26*****");

            var averageSalaryTask26 = employees.Select(x => x.Salary).Average();

            var result = employees.GroupBy(g => g.Department).Where(x => x.Average(x => x.Salary) > averageSalaryTask26);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key}: ${item.Average(x => x.Salary)}");
            }

            //TASK 27
            Console.WriteLine("*****TASK 27*****");

            var secondHighestTask26 = employees.Where(x => x.Department.ToLower() == "it").OrderBy(x => x.Salary).Skip(1).Take(1);
            secondHighestTask26.Print();

            //TASK28
            Console.WriteLine("*****TASK 28*****");
            //internetden gosterdiyiniz metod
            var employeePairs = employees.SelectMany(e1 => employees
            .Where(e2 => e1.Department == e2.Department && e1.Salary != e2.Salary && e1.Id < e2.Id)
            .Select(e2 => new
            {
                Emp1 = e1.Name,
                Emp2 = e2.Name,
                Dep = e1.Department
            }));

            foreach(var item in employeePairs)
            {
                Console.WriteLine($"{item.Emp1} & {item.Emp2} in {item.Dep}");
            }

        }


        // Employee class
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
            public decimal Salary { get; set; }
            public int Age { get; set; }

            public override string ToString()
            {
                return $"ID: {Id}, Name: {Name}, Department: {Department}, Salary: {Salary}, Age: {Age}";
            }
        }

        // Order class
        public class Order
        {
            public int Id { get; set; }
            public string CustomerName { get; set; }
            public decimal Amount { get; set; }
            public DateTime OrderDate { get; set; }

            public override string ToString()
            {
                return $"ID: {Id}, CustomerName: {CustomerName}, Amount: {Amount}, OrderDate: {OrderDate}";
            }
        }
    }

    public static class Extensions
    {
        public static void Print<T>(this IEnumerable<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }


    }
}
