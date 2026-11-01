using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpPracticum.Tasks.Level3
{
    public class task41 : ITask
    {
        public string Title => "Task.WhenAll — параллельно 10 задач";
        public string Description => "запустить 10 задач параллельно и сравнить с последовательным выполнением.";
        public string[] Requirements => new[]
        {
            "Метод Task<int> WorkAsync(int id) — Task.Delay(500), возвращает id.",
            "Последовательный запуск 10 задач в цикле с await.",
            "Параллельный запуск через Task.WhenAll.",
            "Замерить время обоих вариантов через Stopwatch.",
            "Вывести оба времени и объяснить разницу."

        };
        public void Run()
        {
            RunAsync().GetAwaiter().GetResult();
        }
        private async Task RunAsync()
        {
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 1; i <= 10; i++) await WorkAsync(i);
            sw.Stop();
            Console.WriteLine($"Последовательно: {sw.ElapsedMilliseconds} мс");
            sw.Restart();
            var tasks = Enumerable.Range(1, 10).Select(i => WorkAsync(i));
            await Task.WhenAll(tasks);
            sw.Stop();
            Console.WriteLine($"Параллельно: {sw.ElapsedMilliseconds} мс");
        }
        private async Task<int> WorkAsync(int id)
        {
            await Task.Delay(500);
            return id;
        }
    }
}
