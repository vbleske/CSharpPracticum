using CSharpPracticum.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level1
{
    [TaskInfo(1)]
    public class task01 : ITask
    {
        public string Title => "Hello, World + текущая дата";
        public string Description => "Вывести приветствие и дату";
        public string[] Requirements => new[]
        {
            "Использовать Console.WriteLine",
            "Дату получить через DateTime.Now, отформатировать как dd.MM.yyyy.",
            "Вывести две строки: приветствие и дату."
        };
        public void Run()
        {
            Console.WriteLine("Hello, world!");
            Console.WriteLine(DateTime.Now.ToString("dd.MM.yyyy"));
        }
        // строка для коммита
    }
}
