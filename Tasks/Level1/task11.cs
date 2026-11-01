using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1
{
    public class task11 : ITask
    {
        public string Title => "Диагональ матрицы N*N";
        public string Description => "найти сумму элементов главной диагонали матрицы N×N.";
        public string[] Requirements => new[]
        {
            "Размер N вводится пользователем (минимум 2).",
            "Матрица заполняется случайными числами.",
            "Сумма считается без LINQ, в одном цикле for.",
            "Вывести саму матрицу и сумму."
        };
        public void Run()
        {
            Console.Write("Введите размер матрицы N (минимум 2): ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int num) || num < 2)
            {
                Console.WriteLine("Ошибка: нужно ввести число не меньше 2.");
                return;
            }
            int[,] arr = new int[num, num];
            Random rnd = new Random();
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    arr[i, j] = rnd.Next(1, 10);
                    Console.Write($"{arr[i, j], 4}");
                }
                Console.WriteLine();
            }
            int sum = 0;
            for (int i = 0;i < num; i++)
            {
                sum += arr[i, i];
            }
            Console.WriteLine($"Сумма диагонали: {sum}");
        }
    }
}
