using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3
{
    public class task36 : ITask
    {
        public string Title => "Дубликаты в List (HashSet + GroupBy)";
        public string Description => "найти дубликаты в списке чисел двумя способами.";
        public string[] Requirements => new[]
        {
            "Способ 1: через HashSet<int> — при добавлении проверять Contains.",
            "Способ 2: через LINQ GroupBy(x => x).Where(g => g.Count() > 1).",
            "Оба способа оформить отдельными методами.",
            "Продемонстрировать на списке с повторяющимися значениями."
        };
        public void Run()
        {
            var numbers = new List<int> { 1, 2, 3, 2, 4, 5, 3, 6, 7, 1 };
            Console.WriteLine($"Исходный список: {string.Join(", ", numbers)}");
            Console.WriteLine("Способ 1 (HashSet): " + string.Join(", ", FindDuplicatesHashSet(numbers)));
            Console.WriteLine("Способ 2 (LINQ):    " + string.Join(", ", FindDuplicatesLinq(numbers)));
        }
        private List<int> FindDuplicatesHashSet(List<int> list)
        {
            var seen = new HashSet<int>();
            var duplicates = new HashSet<int>();
            foreach (var num in list)
            {
                if (!seen.Add(num)) duplicates.Add(num);
            }
            return duplicates.ToList();
        }
        private List<int> FindDuplicatesLinq(List<int> list)
        {
            return list.GroupBy(x => x)
                       .Where(g => g.Count() > 1)
                       .Select(g => g.Key)
                       .ToList();
        }
    }
}
