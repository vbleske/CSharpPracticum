using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2
{
    public class task28 : ITask
    {
        public string Title => "Equals / GetHashCode для Point";
        public string Description => "переопределить Equals и GetHashCode для класса Point(x, y).";
        public string[] Requirements => new[]
        {
            "Переопределить Equals(object) и GetHashCode().",
            "Реализовать IEquatable<Point>.",
            "Проверить: две точки с одинаковыми координатами равны.",
            "Проверить в HashSet<Point>: добавление дубликата не увеличивает Count."
        };
        public void Run()
        {
            var p1 = new Point(5, 10);
            var p2 = new Point(5, 10);
            var p3 = new Point(1, 1);
            Console.WriteLine($"p1 == p2: {p1.Equals(p2)}");
            Console.WriteLine($"p1 == p3: {p1.Equals(p3)}");
            var set = new HashSet<Point> { p1, p2, p3 };
            Console.WriteLine($"Уникальных точек: {set.Count}");
        }
    }
    public class Point : IEquatable<Point>
    {
        public int X { get; }
        public int Y { get; }
        public Point(int x, int y) { X = x; Y = y; }
        public bool Equals(Point other) => other is not null && X == other.X && Y == other.Y;
        public override bool Equals(object obj) => Equals(obj as Point);
        public override int GetHashCode() => HashCode.Combine(X, Y);
    }
}
