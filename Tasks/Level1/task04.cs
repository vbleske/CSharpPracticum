using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1
{
    public class task04 : ITask
    {
        public string Title => "Чётность числа (два способа)";
        public string Description => "определить, чётное ли введённое число.";
        public string[] Requirements => new[]
        {
            "Способ 1: через % 2 == 0.",
            "Способ 2: через тернарный оператор ?",
            "Оба способа реализовать отдельными методами.",
            "Вывести результат обоих способов."
        };
        public void Run()
        {
            Console.WriteLine("Введите число:");
            string input = Console.ReadLine();
            bool check = int.TryParse(input, out int result);
            bool result1 = result % 2 == 0;
            Console.WriteLine($"Первый способ: {result1}");
            bool result2 = result % 2 == 0 ? true : false;
            Console.WriteLine($"Второй способ: {result2}");
        }
    }
}
