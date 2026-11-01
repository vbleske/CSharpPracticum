using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1
{
    public class task10 : ITask
    {
        public string Title => "Сортировка пузырьком + вставками";
        public string Description => "отсортировать массив двумя алгоритмами.\r\nТребования:";
        public string[] Requirements => new[]
        {
            "Реализовать BubbleSort и InsertionSort отдельными методами.",
            "Оба — без LINQ и Array.Sort.",
            "Замерить время каждого через Stopwatch на массиве 10 000 элементов.",
            "Вывести оба времени."
        };
        public void Run()
        {
            int[] arr = new int[10000];
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1, 101);
            }
            int[] arrayForBubble = (int[])arr.Clone();
            int[] arrayForInsertion = (int[])arr.Clone();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            BubbleSort(arrayForBubble);
            sw.Stop();
            Console.WriteLine($"bubble:{sw.ElapsedMilliseconds}");
            sw.Restart();
            InsertionSort(arrayForInsertion);
            sw.Stop();
            Console.WriteLine($"insertion:{sw.ElapsedMilliseconds}");
        }
        private void BubbleSort(int[] arr)
        {
            for (int i = 0;i < arr.Length;i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
        private void InsertionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j]; 
                    j--;                 
                }
                arr[j + 1] = key;
                }
            }    
        }
    }


