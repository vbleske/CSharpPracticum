using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3
{
    internal class task39 : ITask
    {
        public string Title => "yield return — генератор чётных чисел";
        public string Description => "реализовать генератор чётных чисел через yield return.";
        public string[] Requirements => new[]
        {
            "Метод IEnumerable<int> GetEvenNumbers(int max) — возвращает чётные числа до max.",
            "Реализовать именно через yield return, без промежуточного списка.",
            "Продемонстрировать работу в foreach.",
            "Дополнительно: показать ленивость — вывести сообщение внутри генератора и убедиться, что оно печатается по одному."
        };
        public void Run()
        {
            Console.WriteLine("Начинаем цикл:");
            foreach (var num in GetEvenNumbers(10))
            {
                Console.WriteLine($"Получено: {num}");
            }
        }
        private IEnumerable<int> GetEvenNumbers(int max)
        {
            for (int i = 0; i <= max; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine($"[Генератор] Подготовлено число {i}");
                    yield return i;
                }
            }
        }
    }
}
