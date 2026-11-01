using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3
{
    public class task38 : ITask
    {
        public string Title => "List<T> vs LinkedList<T> (бенчмарк)";
        public string Description => "сравнить вставку в середину List<T> и LinkedList<T>.";
        public string[] Requirements => new[]
        {
            "Создать List<int> и LinkedList<int> по 100 000 элементов.",
            "Вставить 1000 элементов в середину каждой коллекции.",
            "Замерить время через Stopwatch.",
            "Вывести оба времени и объяснить результат в комментарии."
        };
        public void Run()
        {
            int count = 100000;
            int inserts = 1000;
            var list = new List<int>();
            for (int i = 0; i < count; i++) list.Add(i);
            var linked = new LinkedList<int>();
            for (int i = 0; i < count; i++) linked.AddLast(i);
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < inserts; i++) list.Insert(list.Count / 2, -1);
            sw.Stop();
            Console.WriteLine($"List вставка: {sw.ElapsedMilliseconds} мс");
            sw.Restart();
            var node = linked.Find(linked.Count / 2);
            for (int i = 0; i < inserts; i++) linked.AddBefore(node, -1);
            sw.Stop();
            Console.WriteLine($"LinkedList вставка: {sw.ElapsedMilliseconds} мс"); // лист сдвигает все элементы линкедлист меняет ссылки
        }
    }
}
