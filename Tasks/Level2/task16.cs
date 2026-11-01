using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2
{
    internal class task16 : ITask
    {
        public string Title => " Методы расширения для string";
        public string Description => "написать extension-методы для string.";
        public string[] Requirements => new[]
        {
            "Реализовать в статическом классе StringExtensions.",
            "Методы: IsPalindrome(), WordCount(), ReverseString().",
            "Методы должны быть public static с this string первым параметром.",
            "Продемонстрировать вызов на 2–3 строках."
        };
        public void Run()
        {
            Console.WriteLine("Введите фразу или слово: ");
            string word = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine(word.IsPalindrome());
            Console.WriteLine(word.WordCount());
            Console.WriteLine(word.ReverseString());

        }
    }
}
