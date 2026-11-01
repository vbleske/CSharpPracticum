using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3
{
    public class task45 : ITask
    {
        public string Title => "Мини-проект «Библиотека» + юнит-тесты";
        public string Description => "классы библиотеки + тесты.";
        public string[] Requirements => new[]
        {
            "Классы: Book (Title, Author, IsAvailable), Reader (Name, BorrowedBooks), Library (выдача/возврат).",
            "Логика: выдача книги читателю, возврат, лимит (не больше 3 книг на читателя).",
            "Обработка: книгу уже выдали, лимит превышен — бросать исключения.",
            "Написать 5+ юнит-тестов (xUnit/NUnit) на ключевые сценарии.",
            "Все тесты должны проходить."
        };
        public void Run()
        {
            var lib = new Library();
            var b1 = new Book("1984"); var b2 = new Book("Мастер"); var b3 = new Book("Преступление"); var b4 = new Book("Война");
            lib.AddBooks(b1, b2, b3, b4);
            var ivan = new Reader("Иван");
            var maria = new Reader("Мария");
            Console.WriteLine("тесты");
            int passed = 0;
            lib.Borrow(b1, ivan);
            if (!b1.IsAvailable) { Console.WriteLine("Выдача"); passed++; }
            lib.Return(b1, ivan);
            if (b1.IsAvailable) { Console.WriteLine("Возврат"); passed++; }
            lib.Borrow(b2, ivan);
            try { lib.Borrow(b2, maria); } catch { Console.WriteLine("Занятая книга"); passed++; }
            lib.Borrow(b3, ivan); lib.Borrow(b4, ivan);
            var b5 = new Book("Пятая"); lib.AddBook(b5);
            try { lib.Borrow(b5, ivan); } catch { Console.WriteLine("Лимит"); passed++; }
            try { lib.Return(b2, maria); } catch { Console.WriteLine("Чужая книга"); passed++; }
            Console.WriteLine($"Пройдено: {passed} из 5");
        }
    }
    public class Book
    {
        public string Title { get; }
        public bool IsAvailable { get; set; } = true;
        public Book(string title) => Title = title;
    }
    public class Reader
    {
        public string Name { get; }
        public List<Book> Books { get; } = new();
        public Reader(string name) => Name = name;
    }
    public class Library
    {
        private readonly List<Book> _books = new();
        public void AddBook(Book book) => _books.Add(book);
        public void AddBooks(params Book[] books) => _books.AddRange(books);
        public void Borrow(Book book, Reader reader)
        {
            if (!_books.Contains(book) || !book.IsAvailable || reader.Books.Count >= 3)
                throw new Exception("Ошибка выдачи");
            book.IsAvailable = false;
            reader.Books.Add(book);
        }
        public void Return(Book book, Reader reader)
        {
            if (!reader.Books.Contains(book)) throw new Exception("Ошибка возврата");
            book.IsAvailable = true;
            reader.Books.Remove(book);
        }
    }
}