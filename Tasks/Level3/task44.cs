using CSharpPracticum.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CSharpPracticum.Tasks.Level3
{
    public class task44 : ITask
    {
        public string Title => "Мини-проект «Todo List» (классы + JSON)";
        public string Description => "консольное приложение для списка задач с сохранением в JSON.";
        public string[] Requirements => new[]
        {
            "Классы: TaskItem (Id, Title, IsDone), TaskRepository (CRUD), TaskService (бизнес-логика).",
            "CRUD-операции: добавить, вывести все, отметить выполненной, удалить.",
            "Сохранение/загрузка через System.Text.Json (файл tasks.json).",
            "Меню с выбором действий.",
            "Обработка ошибок (некорректный ввод, отсутствующий файл)."
        };
        private const string FilePath = "tasks.json";
        private List<TaskItem> _tasks = new();
        public void Run()
        {
            Load();
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("TODO LIST 1. Показать 2. Добавить 3. Отметить 4. Удалить 5. Убрать отметку 0. Выход");
                Console.Write("Выбор: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        ShowAll();
                        break;
                    case "2":
                        Add();
                        break;
                    case "3":
                        MarkDone();
                        break;
                    case "4":
                        Delete();
                        break;
                    case "5":
                        ToggleDone();
                        break;
                    case "0":
                        Save();
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод.");
                        break;
                }
                if (isRunning)
                {
                    Console.WriteLine("Enter..."); Console.ReadLine();
                }
            }
        }
        private void ShowAll()
        {
            if (!_tasks.Any()) { Console.WriteLine("Список пуст."); return; }
            foreach (var t in _tasks)
                Console.WriteLine($"{(t.IsDone ? "[X]" : "[ ]")} {t.Id}. {t.Title}");
        }
        private void Add()
        {
            Console.Write("Название: ");
            string title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title)) return;

            int id = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1;
            _tasks.Add(new TaskItem { Id = id, Title = title });
        }
        private void MarkDone()
        {
            ShowAll();
            Console.Write("ID для отметки: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var task = _tasks.FirstOrDefault(t => t.Id == id);
                if (task != null) task.IsDone = true;
            }
        }
        private void ToggleDone()
        {
            ShowAll();
            Console.Write("ID для переключения статуса: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var task = _tasks.FirstOrDefault(t => t.Id == id);
                if (task != null)
                {
                    task.IsDone = !task.IsDone;
                }
            }
        }
        private void Delete()
        {
            ShowAll();
            Console.Write("ID для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _tasks.RemoveAll(t => t.Id == id);
            }
        }
        private void Save()
        {
            var json = JsonSerializer.Serialize(_tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        private void Load()
        {
            if (!File.Exists(FilePath)) return;
            try { _tasks = JsonSerializer.Deserialize<List<TaskItem>>(File.ReadAllText(FilePath)) ?? new(); }
            catch { _tasks = new(); }
        }
    }
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }
}