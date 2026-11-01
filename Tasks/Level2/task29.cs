using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2
{
    public class task29 : ITask
    {
        public string Title => "Паттерн «Фабрика» (уведомления)";
        public string Description => "реализовать фабрику уведомлений..";
        public string[] Requirements => new[]
        {
            "Интерфейс INotification с методом Send(string message).",
            "Реализации: EmailNotification, SmsNotification, PushNotification.",
            "NotificationFactory.Create(NotificationType type) — возвращает нужную реализацию.",
            "enum NotificationType { Email, Sms, Push }.",
            "Продемонстрировать создание и отправку через фабрику."
        };
        public void Run()
        {
            var email = NotificationFactory.Create(NotificationType.Email);
            email.Send("Привет!");

            var sms = NotificationFactory.Create(NotificationType.Sms);
            sms.Send("Код: 1234");

            var push = NotificationFactory.Create(NotificationType.Push);
            push.Send("Новое сообщение");
        }
    }
    public enum NotificationType { Email, Sms, Push }
    public interface INotification { void Send(string message); }

    public class EmailNotification : INotification
    {
        public void Send(string message) => Console.WriteLine($"Email: {message}"); 
    }
    public class SmsNotification : INotification
    { 
        public void Send(string message) => Console.WriteLine($"SMS: {message}"); 
    }
    public class PushNotification : INotification
    { 
        public void Send(string message) => Console.WriteLine($"Push: {message}");
    }

    public static class NotificationFactory
    {
        public static INotification Create(NotificationType type)
        {
            return type switch
            {
                NotificationType.Email => new EmailNotification(),
                NotificationType.Sms => new SmsNotification(),
                NotificationType.Push => new PushNotification(),
                _ => throw new ArgumentException("Неизвестный тип")
            };
        }
    }
}