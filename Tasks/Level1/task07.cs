using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1
{
    public class task07 : ITask
    {
        public string Title => "Реверс строки без LINQ";
        public string Description => "перевернуть введённую строку.";
        public string[] Requirements => new[]
        {
            "Не использовать Array.Reverse и LINQ.",
            "Способ 2 (арифметика): цикл while (n > 0) { sum += n % 10; n /= 10; }.",
            "Пустая строка и строка из одного символа — обрабатываются корректно.",
        };
        public void Run()
        {
            Console.WriteLine("Введите строку: ");
            string q = Console.ReadLine();
            string rev = Reverse(q);
            Console.WriteLine(rev);
        }
        private string Reverse(string str)
        {
            if (str.Length == 0)
            {
                return "";
            }
            string result = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                result += str[i];
            }
            return result;
        }
    }
}
