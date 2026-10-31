using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1
{
    public class task06 : ITask
    {
        public string Title => "Сумма цифр числа (строка + арифметика)";
        public string Description => "найти сумму цифр введённого числа (например, 1234 → 10).";
        public string[] Requirements => new[]
        {
            "Способ 1 (строка): число → ToString() → пройти по символам → int.Parse каждой цифры.",
            "Способ 2 (арифметика): цикл while (n > 0) { sum += n % 10; n /= 10; }.",
            "Оба способа оформить отдельными методами.",
            "Отрицательные числа — брать модуль."
        };
        public void Run()
        {
            Console.WriteLine("Введите число:");
            string input = Console.ReadLine();
            bool check = int.TryParse(input, out int numb);
            string numb1 = Math.Abs(numb).ToString();
            int result = sposob1(numb1);
            Console.WriteLine(result);
            int result2 = sposob2(int.Parse(numb1));
            Console.WriteLine(result2);
        }
        private int sposob1(string num)
        {
            int sum = 0;
            foreach (char c in num)
            {
                sum += int.Parse(c.ToString());
            }
            return sum;
        }
        private int sposob2(int num2)
        {
            int sum = 0;
            num2 = Math.Abs(num2);
            while (num2 > 0)
            {
                sum += num2 % 10;
                num2 /= 10;
            }
            return sum;
        }
    }
}
