using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;
using CSharpPracticum.Tasks;
using CSharpPracticum.Tasks.Level1;

namespace CSharpPracticum.Menu
{
    public class LevelMenu
    {
        private string _title;
        private List<ITask> _tasks;
        public LevelMenu(string title, List<ITask> tasks)
        {
            _title = title;
            _tasks = tasks;
        }
        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"---{_title}---");
                for (int i =  0; i < _tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_tasks[i].Title}");
                }
                Console.WriteLine("0. Назад");
                Console.WriteLine("Выберите задание: ");
                string input = Console.ReadLine();
                if (input == "0")
                {
                    return;
                }
                if (int.TryParse(input, out int choice))
                {
                    if (choice >= 1 && choice <= _tasks.Count)
                    {
                        ITask selectedTask = _tasks[choice - 1];
                        Console.Clear();
                        ConsoleHelper.PrintTaskHeader(choice, selectedTask);
                        selectedTask.Run();
                        ConsoleHelper.Pause();
                    }
                    else
                    {
                        Console.WriteLine("Нет такого задания. Нажмите Enter");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Введите число. Нажмите Enter");
                    Console.ReadLine();
                }
            }    
        }
    }
}
