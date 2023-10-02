using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notice
{
    // Класс для уведомлений
    public class Notice
    {
        // Объявляем делегат для события
        public delegate void NotificationHandler(string message);

        // Определяем события для разных типов уведомлений
        public event NotificationHandler MessageEvent;
        public event NotificationHandler CallEvent;
        public event NotificationHandler EmailEvent;

        // Метод для отправки сообщения
        public void SendMessage(string message)
        {
            Console.WriteLine("Отправка сообщения: " + message);
            
            MessageEvent?.Invoke(message); // Вызываем событие для сообщений
        }

        // Метод для отправки звонка
        public void MakeCall(string message)
        {
            Console.WriteLine("Звонок: " + message);
            
            CallEvent?.Invoke(message); // Вызываем событие для звонков
        }

        // Метод для отправки электронной почты
        public void SendEmail(string message)
        {
            Console.WriteLine("Отправка электронной почты: " + message);
            
            EmailEvent?.Invoke(message); // Вызываем событие для электронной почты
        }
    }

    class Noticed
    {
        static void Main(string[] args)
        {
            Notice notificationSystem = new Notice(); // Создаем экземпляр класса Notice

            // Регистрируем обработчики событий
            notificationSystem.MessageEvent += MessageHandler;
            notificationSystem.CallEvent += CallHandler;
            notificationSystem.EmailEvent += EmailHandler;

            while (true)
            {
                Console.WriteLine("Выберите тип уведомления (1 - сообщение, 2 - звонок, 3 - электронная почта, 4 - выход):");
                string choice = Console.ReadLine();

                if (choice == "4")
                {
                    break;
                }

                Console.WriteLine("Введите текст уведомления:");
                string message = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        notificationSystem.SendMessage(message);
                        break;
                    case "2":
                        notificationSystem.MakeCall(message);
                        break;
                    case "3":
                        notificationSystem.SendEmail(message);
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Пожалуйста, выберите 1, 2, 3 или 4.");
                        break;
                }
            }
        }

        // Обработчик для сообщений
        static void MessageHandler(string message)
        {
            Console.WriteLine("Обработчик для сообщений: " + message);
        }

        // Обработчик для звонков
        static void CallHandler(string message)
        {
            Console.WriteLine("Обработчик для звонков: " + message);
        }

        // Обработчик для электронной почты
        static void EmailHandler(string message)
        {
            Console.WriteLine("Обработчик для электронной почты: " + message);
        }
    }
}
