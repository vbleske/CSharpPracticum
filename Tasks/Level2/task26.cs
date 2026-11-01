using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2
{
    public class task26 : ITask
    {
        public string Title => "Паттерн «Стратегия» (скидки)";
        public string Description => "реализовать калькулятор скидок через паттерн «Стратегия».";
        public string[] Requirements => new[] 
        {
            "Интерфейс IDiscountStrategy с методом Apply(decimal price).",
            "Реализации: NoDiscount, VipDiscount (10%), PromoDiscount (20%).",
            "Класс PriceCalculator, принимающий стратегию в конструкторе.",
            "Продемонстрировать расчёт цены с каждой стратегией."
        };
        public void Run()
        {
            decimal price = 1000m;
            Console.WriteLine($"Базовая цена: {price}");
            var calc1 = new PriceCalculator(new NoDiscount());
            Console.WriteLine($"Без скидки: {calc1.Calculate(price)}");
            var calc2 = new PriceCalculator(new VipDiscount());
            Console.WriteLine($"VIP (10%): {calc2.Calculate(price)}");
            var calc3 = new PriceCalculator(new PromoDiscount());
            Console.WriteLine($"Промо (20%): {calc3.Calculate(price)}");
        }
    }
    public interface IDiscountStrategy
    { 
        decimal Apply(decimal price); 
    }
    public class NoDiscount : IDiscountStrategy
    { 
        public decimal Apply(decimal price) => price; 
    }
    public class VipDiscount : IDiscountStrategy 
    {
        public decimal Apply(decimal price) => price * 0.9m; 
    }
    public class PromoDiscount : IDiscountStrategy 
    { 
        public decimal Apply(decimal price) => price * 0.8m; 
    }

    public class PriceCalculator
    {
        private readonly IDiscountStrategy _strategy;
        public PriceCalculator(IDiscountStrategy strategy) => _strategy = strategy;
        public decimal Calculate(decimal price) => _strategy.Apply(price);
    }
}
