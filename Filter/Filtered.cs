using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter
{
    // Создаем делегат для фильтрации данных
    delegate bool DataFilterDelegate(string dataItem, string filter);

    class Filtered
    {
        static void Main(string[] args)
        {
            List<string> dataList = new List<string>();

            do
            {
                Console.Write("Введите текст: ");
                string inputText = Console.ReadLine();
                dataList.Add(inputText);

                Console.Write("Продолжить ввод? (Да/Нет): ");
                string continueInput = Console.ReadLine();

                if (continueInput.Trim().ToLower() != "да")
                    break;
            } while (true);

            while (true)
            {
                Console.WriteLine("Выберите фильтр (1 - По дате, 2 - По ключевым словам, 3 - Выход): ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("Введите дату для фильтрации: ");
                    string filter = Console.ReadLine();
                    FilterData(dataList, FilterByDate, filter);
                }
                else if (choice == 2)
                {
                    Console.Write("Введите ключевое слово для фильтрации: ");
                    string filter = Console.ReadLine();
                    FilterData(dataList, FilterByKeyword, filter);
                }
                else if (choice == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный выбор. Попробуйте еще раз.");
                }
            }
        }

        // Метод для фильтрации данных по дате
        static bool FilterByDate(string dataItem, string filter)
        {
            return dataItem.Contains(filter);
        }

        // Метод для фильтрации данных по ключевым словам
        static bool FilterByKeyword(string dataItem, string filter)
        {
            return dataItem.Contains(filter);
        }

        // Метод для применения фильтра к данным с использованием делегата
        static void FilterData(List<string> dataList, DataFilterDelegate filterDelegate, string filter)
        {
            var filteredData = dataList.Where(item => filterDelegate(item, filter)).ToList();

            Console.WriteLine("Результаты фильтрации:");
            foreach (var item in filteredData)
            {
                Console.WriteLine(item);
            }
        }
    }
}
