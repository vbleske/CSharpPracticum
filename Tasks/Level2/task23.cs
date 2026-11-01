using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2
{
    public class task23 : ITask
    {
        public string Title => "Nullable-типы, ??, ?.";
        public string Description => "Продемонстрировать работу с nullable.";
        public string[] Requirements => new[]
        {
            "Метод int? FindValue(string key) — возвращает null, если ключа нет.",
            "Использовать ?? для значения по умолчанию.",
            "Использовать ?. для безопасного доступа.",
            "Продемонстрировать на примере с найденным и ненайденным ключом."
        };
        public void Run()
        {
            int? found = FindValue("age");
            int? notFound = FindValue("height");
            int age = found ?? 0; 
            int height = notFound ?? 180; 
            Console.WriteLine($"Age: {age}, Height: {height}");
            Person person = null;
            int? nameLength = person?.Name?.Length;
            Console.WriteLine($"Length of name: {nameLength ?? 0}");
        }
        private int? FindValue(string key)
        {
            if (key == "age") return 25;
            return null;
        }
        private class Person
        {
            public string Name { get; set; }
        }
    }
}
