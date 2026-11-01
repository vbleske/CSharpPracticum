using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2
{
    public class task30 : ITask
    {
        public string Title => "BankAccount + свой Exception";
        public string Description => "реализовать банковский счёт с собственным исключением.";
        public string[] Requirements => new[]
        {
            "Класс BankAccount с приватным балансом.",
            "Методы Deposit(decimal), Withdraw(decimal).",
            "Свой класс InsufficientFundsException : Exception.",
            "Withdraw бросает исключение, если сумма больше баланса.",
            "Продемонстрировать: успешное снятие и попытку снять больше баланса (с try/catch)."
        };
        public void Run()
        {
            var account = new BankAccount(100m);
            try
            {
                account.Withdraw(50m);
                Console.WriteLine($"Снято 50. Остаток: {account.Balance}");
                account.Withdraw(100m);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        public class InsufficientFundsException : Exception
        {
            public InsufficientFundsException(string message) : base(message) { }
        }
        public class BankAccount
        {
            private decimal _balance;
            public decimal Balance => _balance;
            public BankAccount(decimal initialBalance) => _balance = initialBalance;
            public void Deposit(decimal amount) => _balance += amount;

            public void Withdraw(decimal amount)
            {
                if (amount > _balance)
                    throw new InsufficientFundsException($"Недостаточно средств. Баланс: {_balance}, запрошено: {amount}");
                _balance -= amount;
            }
        }
    }
}
