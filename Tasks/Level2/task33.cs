using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2
{
    public class task33 : ITask
    {
        public string Title => "LINQ: сотрудники (top-3, avg по отделу, фильтр)";
        public string Description => "LINQ-запросы по списку сотрудников.";
        public string[] Requirements => new[]
        {
            "Класс Employee: Name, Age, Salary, Department.",
            "Список из 10+ сотрудников.",
            "Запросы через LINQ",
            "Вывести результаты."
        };
        public void Run()
        {
            var employees = new List<Employee>
            {
                new Employee("Анна", 25, 50000, "IT"),
                new Employee("Борис", 35, 60000, "IT"),
                new Employee("Виктор", 40, 45000, "HR"),
                new Employee("Галина", 28, 55000, "HR"),
                new Employee("Дмитрий", 32, 70000, "IT"),
                new Employee("Елена", 45, 80000, "Sales")
            };
            Console.WriteLine("Топ-3 по зарплате:");
            foreach (var e in employees.OrderByDescending(e => e.Salary).Take(3))
            Console.WriteLine($"{e.Name}: {e.Salary}");
            Console.WriteLine("Средняя по отделам:");
            var avgByDept = employees.GroupBy(e => e.Department)
            .Select(g => new { Dept = g.Key, Avg = g.Average(e => e.Salary) });
            foreach (var item in avgByDept)
            Console.WriteLine($"{item.Dept}: {item.Avg:F0}");
            Console.WriteLine("Старше 30:");
            foreach (var e in employees.Where(e => e.Age > 30))
            Console.WriteLine($"{e.Name} ({e.Age})");
        }
    }
    public class Employee
    {
        public string Name { get; }
        public int Age { get; }
        public decimal Salary { get; }
        public string Department { get; }
        public Employee(string name, int age, decimal salary, string department)
        {
            Name = name; Age = age; Salary = salary; Department = department;
        }
    }
}
