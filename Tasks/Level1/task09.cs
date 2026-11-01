using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1
{
    public class task09 : ITask
    {
        public string Title => "Массивы: min/max/sum/avg";
        public string Description => "для массива чисел найти минимум, максимум, сумму и среднее.";
        public string[] Requirements => new[]
        {
            "Заполнить массив (например, случайными числами 1–100, размер 20).",
            "Реализовать без LINQ (Min/Max/Sum/Average запрещены).",
            "Оформить 4 отдельных метода.",
            "Пустой массив — обработать (вернуть ошибку или 0, но не падать)."
        };
        public void Run()
        {
            int[] arr = new int[20];
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1, 101);
            }
            Console.WriteLine(string.Join(", ", arr));
            if (arr.Length == 0 )
            {
                Console.WriteLine();
            }
            Console.WriteLine($"Минимум: {min(arr)}");
            Console.WriteLine($"Максимум: {max(arr)}");
            Console.WriteLine($"Сумма: {sum(arr)}");
            Console.WriteLine($"Среднее: {avg(arr)}");
        }
        private int min(int[] arr)
        {
            int minimum = int.MaxValue;
            foreach (int i in arr)
            {
                if (i < minimum) minimum = i;
            }
            return minimum;
        }
        private int max(int[] arr)
        {
            int maximum = int.MinValue;
            foreach (int i in arr)
            {
                if (i > maximum) maximum = i;
            }
            return maximum;
        }
        private int sum(int[] arr)
        {
            int sum = 0;
            foreach (int i in arr)
            {
                sum += i;
            }
            return sum;
        }
        private double avg(int[] arr)
        {
            double summa = (double)sum(arr);
            double avg1 = summa / arr.Length;
            return avg1;
        }
    }
}

