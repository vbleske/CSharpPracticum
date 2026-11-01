using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1
{
    public class task08 : ITask
    {
        public string Title => "FizzBuzz 1–100";
        public string Description => "вывести числа от 1 до 100 с заменами.";
        public string[] Requirements => new[]
        {
            "Кратно 3 → Fizz.",
            "Кратно 5 → Buzz.",
            "Оба способа оформить отдельными методами.",
            "Иначе — само число.",
            "Порядок проверок: сначала 15, потом 3 и 5"
        };
        public void Run()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 15 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
               else  if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }    
            }
        }
    }
}
