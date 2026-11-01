using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3
{
    public class task40 : ITask
    {
        public string Title => "async/await + обработка исключений";
        public string Description => "асинхронный метод с эмуляцией «скачивания».";
        public string[] Requirements => new[]
        {
            "async Task<string> DownloadAsync(string url) — внутри Task.Delay(1000).",
            "Имитировать ошибку: если url пустой — бросить ArgumentException.",
            "В Main вызвать через await внутри try/catch.",
            "Продемонстрировать успешный и ошибочный вызов."

        };
        public void Run()
        {
            RunAsync().GetAwaiter().GetResult();
        }
        private async Task RunAsync()
        {
            try
            {
                Console.WriteLine("Скачиваем...");
                string result = await DownloadAsync("qwe.com");
                Console.WriteLine($"Результат: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        private async Task<string> DownloadAsync(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException("URL не может быть пустым.");
            await Task.Delay(1000);
            return $"Данные с {url}";
        }
    }
}