using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2
{
    public class task24 : ITask
    {
        public string Title => "ООП: Animal -> Dog/Cat/Bird";
        public string Description => "Построить иерархию животных.";
        public string[] Requirements => new[]
        {
            "Абстрактный класс Animal: свойство Name, абстрактный метод MakeSound(), переопределённый ToString().",
            "Классы Dog, Cat, Bird — наследники, реализуют MakeSound().",
            "Bird дополнительно имеет метод Fly().",
            "Продемонстрировать полиморфизм: List<Animal> с разными животными."
        };
        public void Run()
        {
            List<Animal> animals = new List<Animal>
            {
                new Dog { Name = "бублик" },
                new Cat { Name = "мурзик" },
                new Bird { Name = "кеша" }
            };
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.ToString());
                animal.MakeSound(); 
                if (animal is Bird bird)
                {
                    bird.Fly();
                }
                Console.WriteLine();
            }
        }
    }

    public abstract class Animal
    {
        public string Name { get; set; }

        public abstract void MakeSound();

        public override string ToString()
        {
            return $"Animal: {Name}";
        }
    }
    public class Dog : Animal
    {
        public override void MakeSound() => Console.WriteLine("Гав-гав!");
    }

    public class Cat : Animal
    {
        public override void MakeSound() => Console.WriteLine("Мяу!");
    }

    public class Bird : Animal
    {
        public override void MakeSound() => Console.WriteLine("Чирик!");
        public void Fly() => Console.WriteLine("Я лечу!");
    }
}
