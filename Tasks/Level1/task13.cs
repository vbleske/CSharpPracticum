using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;
using System.Linq;

namespace CSharpPracticum.Tasks.Level1
{
    public class task13 : ITask
    {
        public string Title => "Счётчик вхождений слов в тексте (Dictionary)";
        public string Description => "посчитать, сколько раз каждое слово встречается в тексте";
        public string[] Requirements => new[]
        {
            "Использовать Dictionary<string, int>.",
            "Разбить текст на слова (по пробелам и знакам пунктуации).",
            "Привести слова к нижнему регистру.",
            "Вывести пары «слово → количество», отсортированные по убыванию количества."
        };
        public void Run()
        {
            Console.WriteLine("Введите текст:");
            string text = Console.ReadLine();
            string[] words = text.ToLower().Split(new[] { ' ', ',', '.', '!', '?'}, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> counts = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (counts.ContainsKey(word))
                {
                    counts[word] = counts[word] + 1;
                }
                else
                {
                    counts[word] = 1;
                }
            }
            foreach (var pair in counts.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{pair.Key}: ({pair.Value})");
            }
        }
    }
}
