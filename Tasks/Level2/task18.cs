using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2
{
    public class task18 : ITask
    {
        public string Title => "TryParse vs try/catch";
        public string Description => "сравнить два способа обработки некорректного ввода числа.";
        public string[] Requirements => new[]
        {
            "Способ 1: int.TryParse — вернуть bool + значение через out.",
            "Способ 2: int.Parse внутри try/catch — ловить FormatException.",
            "Оба оформить отдельными методами.",
            "Продемонстрировать на корректном и некорректном вводе."

        };
        public void Run()
        {
            string validInput = "123";
            Console.WriteLine($"Тестируем корректный ввод: {validInput}");
            if (sposob1(validInput, out int result1))
            {
                Console.WriteLine($"Число: {result1}");
            }
            if (sposob2(validInput))
            {
                Console.WriteLine($"Число корректное.");
            }
            Console.WriteLine();
            string invalidInput = "abc";
            Console.WriteLine($"Тестируем некорректный ввод: '{invalidInput}'");
            if (!sposob1(invalidInput, out _))
            {
                Console.WriteLine("Ошибка ввода");
            }
            if (!sposob2(invalidInput))
            {
                Console.WriteLine("поймано исключение");
            }
        }
        private bool sposob1(string n, out int result)
        {
            return int.TryParse(n, out result);
        }
        private bool sposob2(string n2)
        {
            try
            {
                int.Parse(n2);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
