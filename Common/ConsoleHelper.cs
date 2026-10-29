using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Common
{
    public static class ConsoleHelper
    {
        public static void PrintTaskHeader(int number, ITask task)
        {
            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"Задание {number}. {task.Title}");
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"Описание: {task.Description}");
            foreach (string req in task.Requirements)
            {
                Console.WriteLine(req);
            }
            Console.WriteLine();
        }
        public static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Нажмите Enter для возврата в меню");
            Console.ReadLine();
        }
    }
}
