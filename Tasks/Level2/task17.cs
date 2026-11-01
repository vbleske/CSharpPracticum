using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2
{
    public class task17 : ITask
    {
        public string Title => "StringBuilder vs конкатенация (замер)";
        public string Description => "сравнить производительность конкатенации через + и StringBuilder.";
        public string[] Requirements => new[]
        {
            "Собрать строку из 10 000 (или 100 000) чисел двумя способами.",
            "Замерить время каждого через Stopwatch.",
            "Вывести оба времени и разницу.",
            "Объяснить в комментарии, почему StringBuilder быстрее."

        };
        public void Run()
        {
            string str = "";
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 10000; i++)
            {
                str += i;
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            StringBuilder sb = new StringBuilder();
            sw.Restart();
            for (int i = 0; i < 10000; i++)
            {
                sb.Append(i);
            }
            string str2 = sb.ToString();
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds); // стрингбилдер изменяемый, сам стринг неизменяемый и при += он каждый раз перезапмсывается используется старые данные
        }
    }
}
