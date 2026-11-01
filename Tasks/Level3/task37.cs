using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3
{
    public class task37 : ITask
    {
        public string Title => "Мемоизация Фибоначчи через Dictionary";
        public string Description => "реализовать мемоизированную функцию Фибоначчи.";
        public string[] Requirements => new[]
        {
            "Обычная рекурсивная версия (для сравнения на маленьком N).",
            "Мемоизированная версия с Dictionary<int, long>.",
            "Замерить время обеих на N = 30–35 через Stopwatch.",
            "Вывести оба времени и разницу."
        };
        public void Run()
        {
            int n = 35;
            var sw = new Stopwatch();
            sw.Start();
            long normal = FibNormal(n);
            sw.Stop();
            Console.WriteLine($"Обычная: F({n}) = {normal}, время: {sw.ElapsedMilliseconds} мс");
            var memo = new Dictionary<int, long>();
            sw.Restart();
            long memoized = FibMemo(n, memo);
            sw.Stop();
            Console.WriteLine($"Мемоизация: F({n}) = {memoized}, время: {sw.ElapsedMilliseconds} мс");
        }
        private long FibNormal(int n)
        {
            if (n <= 1) return n;
            return FibNormal(n - 1) + FibNormal(n - 2);
        }
        private long FibMemo(int n, Dictionary<int, long> cache)
        {
            if (n <= 1) return n;
            if (cache.ContainsKey(n)) return cache[n];
            long result = FibMemo(n - 1, cache) + FibMemo(n - 2, cache);
            cache[n] = result;
            return result;
        }
    }
}
