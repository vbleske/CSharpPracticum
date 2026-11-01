using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSharpPracticum.Common;


namespace CSharpPracticum.Tasks.Level3
{
    public class task42 : ITask
    {
        public string Title => "CancellationToken — отмена через 2 сек";
        public string Description => " реализовать долгую операцию с поддержкой отмены.";
        public string[] Requirements => new[]
        {
            "async Task LongOperationAsync(CancellationToken token) — цикл с Task.Delay(500, token) 10 раз.",
            "В Main создать CancellationTokenSource, запустить операцию, отменить через 2 секунды.",
            "Обработать OperationCanceledException.",
            "Вывести «операция отменена»."

        };
        public void Run()
        {
            RunAsync().GetAwaiter().GetResult();
        }
        private async Task RunAsync()
        {
            using var cts = new CancellationTokenSource();
            cts.CancelAfter(2000);
            try
            {
                await LongOperationAsync(cts.Token);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Операция отменена.");
            }
        }
        private async Task LongOperationAsync(CancellationToken token)
        {
            for (int i = 1; i <= 10; i++)
            {
                token.ThrowIfCancellationRequested();
                Console.WriteLine($"Шаг {i}...");
                await Task.Delay(500, token);
            }
        }
    }
}
