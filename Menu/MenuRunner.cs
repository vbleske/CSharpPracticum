using CSharpPracticum.Common;
using CSharpPracticum.Tasks.Level1;
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
                var level1Menu = new LevelMenu("Уровень 1: Базовый", level1Tasks);
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
