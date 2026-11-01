using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1
{
    public class task14 : ITask
    {
        public string Title => "Возраст по дате рождения";
        public string Description => "по дате рождения вычислить точный возраст в годах, месяцах и днях.";
        public string[] Requirements => new[]
        {
            "Ввод даты через DateTime.TryParse (или TryParseExact).",
            "Учесть, что день рождения в этом году мог ещё не наступить.",
            "Вывести «X лет, Y месяцев, Z дней».",
            "Некорректная дата — сообщение об ошибке, не падать."
        };
        public void Run()
        {
            Console.WriteLine("Введите вашу дату рождения в формате день.месяц.год: ");
            string input = Console.ReadLine();
            if (!DateTime.TryParse(input, out DateTime birthDate))
            {
                Console.WriteLine("Ошибка: некорректный формат даты.");
                return;
            }
            if (birthDate > DateTime.Today)
            {
                Console.WriteLine("Дата рождения не может быть в будущем.");
                return;
            }
            int age = DateTime.Today.Year - birthDate.Year;
            if (DateTime.Today < birthDate.AddYears(age))
            {
                age--;
            }
            DateTime lastBirthday = birthDate.AddYears(age);
            int months = 0;
            DateTime tempDate = lastBirthday;
            while (tempDate.AddMonths(1) <= DateTime.Today)
            {
                tempDate = tempDate.AddMonths(1);
                months++;
            }
            TimeSpan diff = DateTime.Today - tempDate;
            int days = diff.Days;
            Console.WriteLine($"Ваш возраст: {age} лет, {months} месяцев, {days} дней.");
        }
    }
}
