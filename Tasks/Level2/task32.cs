using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2
{
    public class task32 : ITask
    {
        public string Title => "Свойства с валидацией (Temperature)";
        public string Description => "класс Temperature с валидацией в set.";
        public string[] Requirements => new[]
        {
            "Свойство Celsius с проверкой в set: не ниже −273.15.",
            "При некорректном значении — бросать ArgumentOutOfRangeException.",
            "Вычисляемое свойство Fahrenheit (только get).",
            "Продемонстрировать корректное и некорректное присваивание."

        };
        public void Run()
        {
            var temp = new Temperature();
            temp.Celsius = 25;
            Console.WriteLine($"25°C = {temp.Fahrenheit}°F");
            try
            {
                temp.Celsius = -300;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
    public class Temperature
    {
        private double _celsius;
        public double Celsius
        {
            get => _celsius;
            set
            {
                if (value < -273.15)
                    throw new ArgumentOutOfRangeException(nameof(value), "Температура ниже абсолютного нуля невозможна.");
                _celsius = value;
            }
        }
        public double Fahrenheit => _celsius * 9 / 5 + 32;
    }
}
