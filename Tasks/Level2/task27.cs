using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2
{
    public class task27 : ITask
    {
        public string Title => "IComparable / IComparer для Student";
        public string Description => "научить Student сортироваться.";
        public string[] Requirements => new[]
        {
            "Класс Student: Name, AverageGrade",
            "Реализовать IComparable<Student> — сортировка по среднему баллу (по убыванию).",
            "Реализовать IComparer<Student> ByNameComparer — сортировка по имени.",
            "Продемонстрировать обе сортировки на List<Student>."
        };
        public void Run()
        {
            var students = new List<Student>
            {
                new Student("Анна", 4.5),
                new Student("Борис", 3.8),
                new Student("Виктор", 4.9)
            };
            Console.WriteLine("По умолчанию (по баллу, убывание):");
            students.Sort();
            foreach (var s in students) Console.WriteLine(s);
            Console.WriteLine("По имени:");
            students.Sort(new ByNameComparer());
            foreach (var s in students) Console.WriteLine(s);
        }
    }
    public class Student : IComparable<Student>
    {
        public string Name { get; }
        public double AverageGrade { get; }
        public Student(string name, double averageGrade) { Name = name; AverageGrade = averageGrade; }
        public int CompareTo(Student other) => other.AverageGrade.CompareTo(this.AverageGrade);
        public override string ToString() => $"{Name}: {AverageGrade}";
    }
    public class ByNameComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y) => string.Compare(x.Name, y.Name, StringComparison.Ordinal);
    }
}
