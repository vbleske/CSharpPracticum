using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2
{
    internal class task31 : ITask
    {
        public string Title => "IDisposable + using";
        public string Description => "реализовать IDisposable для класса, работающего с файлом.";
        public string[] Requirements => new[]
        {
            "Класс FileWriter с полем StreamWriter.",
            "Реализовать Dispose() (закрыть StreamWriter)..",
            "Продемонстрировать использование через using.",
            "Дополнительно: продемонстрировать using-декларацию (C# 8+, using var).",
        };
        public void Run()
        {
            string path = "test_dispose.txt";
            using var writer = new FileWriter(path);
            writer.Write("Привет, мир!");
            Console.WriteLine("Файл записан и закрыт.");
        }
    }
    public class FileWriter : IDisposable
    {
        private readonly StreamWriter _writer;
        public FileWriter(string path) => _writer = new StreamWriter(path);

        public void Write(string text) => _writer.Write(text);

        public void Dispose()
        {
            _writer?.Dispose();
        }
    }
}
