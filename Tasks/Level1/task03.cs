using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1
{
    public class task03 : ITask
    {
        public string Title => "Калькулятор с обработкой деления на ноль";
        public string Description => "принимать два числа и оператор (+ - * /), выводить результат.";
        public string[] Requirements => new[]
        {
            "Оператор обрабатывать через switch.",
            "При делении на ноль — вывести сообщение об ошибке, не ронять приложение.",
            "Некорректный оператор — вывести «Неизвестная операция».",
            "Ввод чисел — через double.Parse или TryParse."
        };
        public void Run()
        {
            Console.WriteLine("Введите первое число:");
            string input = Console.ReadLine();
            bool check = double.TryParse(input, out double num1);
            Console.WriteLine("Введите второе число:");
            string input2 = Console.ReadLine();
            bool check2 = double.TryParse(input, out double num2);
            Console.WriteLine("Введите оператор действия:");
            string oper = Console.ReadLine();
            switch (oper)
            {
                case "+":
                    double plus = num1 + num2;
                    Console.WriteLine($"Результат: {plus}");
                    break;
                case "-":
                    double minus = num1 - num2;
                    Console.WriteLine($"Результат: {minus}");
                    break;
                case "*":
                    double multi = num1 * num2;
                    Console.WriteLine($"Результат: {multi}");
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        Console.WriteLine("На ноль делить нельзя");
                    }
                    else
                    {
                        double del = num1 / num2;
                        Console.WriteLine($"Результат: {del}");
                    }
                    break;
                default:
                    Console.WriteLine("Неизвестная операция");
                    break;

            }
        }
    }
}
