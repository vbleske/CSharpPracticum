using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1
{
    public class task12 : ITask
    {
        public string Title => "Палиндром (без учёта регистра/пробелов)";
        public string Description => "проверить, является ли строка палиндромом.";
        public string[] Requirements => new[]
        {
            "Игнорировать регистр (ToLower/ToUpper).",
            "Игнорировать пробелы и знаки пунктуации (или хотя бы пробелы).",
            "Не использовать LINQ Reverse.",
            "Пустая строка и строка из одного символа — палиндром."
        };
        public void Run()
        {
            Console.WriteLine("Введите фразу или слово:");
            string str = Console.ReadLine();
            string lower = str.ToLower();
            string probel = lower.Replace(" ", "");
            if (palindrome(probel))
            {
                Console.WriteLine("Это палиндром!");
            }
            else
            {
                Console.WriteLine("Это НЕ палиндром.");
            }
        }
        private bool palindrome(string n)
        {
            int left = 0;
            int right = n.Length - 1;
            while (left < right)
            {
                if (n[left] != n[right])
                {
                    return false;
                }
                    left++;
                    right--;
            }
            return true;
        }
    }
}
