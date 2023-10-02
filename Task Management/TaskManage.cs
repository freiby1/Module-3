using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_Management
{
    // Создаем делегат для выполнения задач
    delegate void TaskDelegate(string taskName);

    class TaskManage
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить задачу");
                Console.WriteLine("2. Выполнить задачи");
                Console.WriteLine("3. Выход");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите название задачи: ");
                        string taskName = Console.ReadLine();
                        Console.WriteLine("Выберите действие для задачи:");
                        Console.WriteLine("1. Отправить уведомление");
                        Console.WriteLine("2. Записать в журнал");
                        string actionChoice = Console.ReadLine();
                        TaskDelegate taskDelegate = null;

                        switch (actionChoice)
                        {
                            case "1":
                                taskDelegate = SendNotification;
                                break;
                            case "2":
                                taskDelegate = LogToJournal;
                                break;
                            default:
                                Console.WriteLine("Некорректный выбор действия.");
                                break;
                        }

                        if (taskDelegate != null)
                        {
                            taskManager.AddTask(taskName, taskDelegate);
                        }
                        break;
                    case "2":
                        taskManager.ExecuteTasks();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Некорректный выбор действия.");
                        break;
                }
            }
        }

        static void SendNotification(string taskName)
        {
            Console.WriteLine($"Отправка уведомления для задачи: {taskName}");
        }

        static void LogToJournal(string taskName)
        {
            Console.WriteLine($"Запись в журнал для задачи: {taskName}");
        }
    }

    // Класс для управления задачами
    class TaskManager
    {
        public event TaskDelegate TaskExecuted;
        private List<Tuple<string, TaskDelegate>> tasks = new List<Tuple<string, TaskDelegate>>();

        // Добавление задачи и делегата для выполнения
        public void AddTask(string taskName, TaskDelegate taskDelegate)
        {
            tasks.Add(new Tuple<string, TaskDelegate>(taskName, taskDelegate));
            Console.WriteLine($"Задача добавлена: {taskName}");
        }

        // Выполнение всех задач
        public void ExecuteTasks()
        {
            foreach (var task in tasks)
            {
                TaskDelegate taskDelegate = task.Item2;
                taskDelegate.Invoke(task.Item1);
            }
        }
    }
}