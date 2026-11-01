using CSharpPracticum.Common;
using CSharpPracticum.Tasks.Level1;
using CSharpPracticum.Tasks.Level2;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Menu
{
        public class MenuRunner
        {

            public void Run()
            {
                var level1Tasks = new List<ITask>();
            level1Tasks.Add(new task01());
            level1Tasks.Add(new task02());
            level1Tasks.Add(new task03());
            level1Tasks.Add(new task04());
            level1Tasks.Add(new task05());
            level1Tasks.Add(new task06());
            level1Tasks.Add(new task07());
            level1Tasks.Add(new task08());
            level1Tasks.Add(new task09());
            level1Tasks.Add(new task10());
            level1Tasks.Add(new task11());
            level1Tasks.Add(new task12());
            level1Tasks.Add(new task13());
            level1Tasks.Add(new task14());
            var level2Tasks = new List<ITask>();
            level2Tasks.Add(new task16());
            level2Tasks.Add(new task17());
            level2Tasks.Add(new task18());
            level2Tasks.Add(new task21());
            level2Tasks.Add(new task22());
            level2Tasks.Add(new task23());
            level2Tasks.Add(new task24());
            level2Tasks.Add(new task25());
            level2Tasks.Add(new task26());
            level2Tasks.Add(new task27());
            level2Tasks.Add(new task28());
            var level1Menu = new LevelMenu("Уровень 1: Базовый", level1Tasks);
            var level2Menu = new LevelMenu("Уровень 2: Средний", level2Tasks);
            while (true)
                {
                    Console.Clear();
                    Console.WriteLine(" === Практикум по C# === ");
                    Console.WriteLine("1. Уровень 1: Базовый (задания 1-15)");
                    Console.WriteLine("2. Уровень 2: Средний (задания 16-35)");
                    Console.WriteLine("3. Уровень 3: Продвинутый (задания 36-50)");
                    Console.WriteLine("0. Выход");
                    Console.WriteLine("Выберите уровень: ");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            level1Menu.Show();
                            break;
                        case "2":
                        level2Menu.Show();
                        break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("В разработке, нажмите Enter");
                            Console.ReadLine();
                            break;

                    }


                }
            }
        }
}
