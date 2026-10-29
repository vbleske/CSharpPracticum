using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1
{
    [TaskInfo(2)]
    public class task02 : ITask
    {
        public string Title => "Переменные примитивных типов";
        public string Description => "объявить переменные всех примитивных типов и вывести их значения и типы.";
        public string[] Requirements => new[]
        {
            "Объявить минимум: int, long, double, float, decimal, bool, char, string.",
            "Для каждой переменной вывести значение и GetType().Name.",
            "decimal — с суффиксом m, float — с f."

        };
        public void Run()
        {
            int a = 0;
            long b = 3123;
            double c = 1.12;
            float d = 3.33f;
            decimal e = 2.22m;
            bool f = true;
            char g = 'g';
            string h = "asd";
            Console.WriteLine($"int = {a} {a.GetType().Name}");
            Console.WriteLine($"long = {b} {b.GetType().Name}");
            Console.WriteLine($"double = {c} {c.GetType().Name}");
            Console.WriteLine($"float = {d} {d.GetType().Name}");
            Console.WriteLine($"decimal = {e} {e.GetType().Name}");
            Console.WriteLine($"bool = {f} {f.GetType().Name}");
            Console.WriteLine($"char = {g} {g.GetType().Name}");
            Console.WriteLine($"string = {h} {h.GetType().Name}");
        }
    }
}
