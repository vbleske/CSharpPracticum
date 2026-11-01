using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2
{
    public class task34 : ITask
    {
        public string Title => "LINQ: группировка слов по первой букве";
        public string Description => "сгруппировать слова по первой букве.";
        public string[] Requirements => new[]
        {
            "Взять список слов (10+).",
            "Сгруппировать через LINQ GroupBy(w => w[0]).",
            "Отсортировать группы по первой букве.",
            "Внутри группы — отсортировать слова",
            "Вывести «Буква: слово1, слово2, ...»."
        };
        public void Run()
        {
            var words = new List<string> { "яблоко", "арбуз", "банан", "авокадо", "брусника", "ягода", "абрикос" };
            var groups = words.GroupBy(w => w[0]).OrderBy(g => g.Key);
            foreach (var group in groups)
            {
                var sorted = group.OrderBy(w => w);
                Console.WriteLine($"{group.Key}: {string.Join(", ", sorted)}");
            }
        }
    }
}
