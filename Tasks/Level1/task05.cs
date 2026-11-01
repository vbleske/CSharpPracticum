using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1
{
    public class task05 : ITask
    {
        public string Title => "Таблица умножения 10*10";
        public string Description => "вывести таблицу умножения 10*10.";
        public string[] Requirements => new[]
        {
            "Использовать вложенные циклы for.",
            "Выровнять столбцы.",
            "Заголовки строк/столбцов — не обязательны, но приветствуются.",
        };
        public void Run()
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Console.Write($"{i * j, 2} | "); // shift + \
                }
                Console.WriteLine();
                Console.WriteLine(new string('-', 50));
            }
        }
    }
}
