using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2
{
    public class task22 : ITask
    {
        public string Title => "params-метод + перегрузка";
        public string Description => "Написать метод суммы с params и его перегрузку.";
        public string[] Requirements => new[]
        {
            "Sum(params int[] numbers) — сумма произвольного числа чисел.",
            "Перегрузка Sum(int[] numbers) — та же логика для массива.",
            "Продемонстрировать: Sum(1, 2, 3), Sum(new[] {1, 2, 3}), Sum()."
        };
        public void Run()
        {
            Console.WriteLine($"Sum(1, 2, 3) = {Sum(1, 2, 3)}");
            Console.WriteLine($"Sum(new[] {{ 1, 2, 3 }}) = {Sum(new[] { 1, 2, 3 })}");
            Console.WriteLine($"Sum() = {Sum()}");
        }

        private static int Sum(params int[] numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum = checked(sum + number);
            }
            return sum;
        }
    }
}