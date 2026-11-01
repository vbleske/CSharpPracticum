using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3
{
    public class task43 : ITask
    {
        public string Title => "Множественные типы исключений, порядок catch";
        public string Description => "продемонстрировать порядок обработки исключений.";
        public string[] Requirements => new[]
        {
            "Метод, который может бросить FormatException, DivideByZeroException или свой CustomException.",
            "Несколько catch-блоков в правильном порядке (от частного к общему).",
            "Продемонстрировать все три сценария.",
            "В конце — finally с выводом «завершено».",
            "Объяснить в комментарии, почему порядок catch важен."

        };
        public void Run()
        {
            TestScenario("abc", 0);
            TestScenario("10", 0);
            TestScenario("10", 2);
        }
        private void TestScenario(string numStr, int divisor)
        {
            try
            {
                int num = int.Parse(numStr);
                if (divisor == 0) throw new DivideByZeroException();
                Console.WriteLine($"Результат: {num / divisor}");
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException (не число)");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("DivideByZeroException (деление на 0)");
            }
            catch (Exception)
            {
                Console.WriteLine("другое исключение");
            }
            finally
            {
                Console.WriteLine("завершено"); // порядок важен потомучто исключения обрабатываются сверху вниз
            }
        }
    }
}