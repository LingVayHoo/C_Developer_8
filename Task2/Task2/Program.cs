using System;
using System.Collections.Generic;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary <int, string> phoneBook = new Dictionary <int, string> ();

            CreateNote(phoneBook);
            FindNote(phoneBook);
            Console.ReadKey();
        }

        /// <summary>
        /// Считывание данных и проверка на корректность
        /// </summary>
        /// <param name="phoneBook"></param>
        static void CreateNote(Dictionary<int, string> phoneBook)
        {
            // Получаем номер телефона и проверяем, хочет ли пользователь прервать ввод данных
            Console.Write("\nВведите номер телефона:");
            int phoneTemp = IsIntValid();
            if (phoneTemp < 0) return;

            // Получаем имя владельца телефона
            Console.Write("\nВведите имя владельца:");
            string nameTemp = Console.ReadLine();

            // Добавляем данные в словарь
            AddNote(phoneBook, phoneTemp, nameTemp);

            // Вызываем этот же метод для повторного ввода
            CreateNote(phoneBook);
        }

        /// <summary>
        /// Добавление записи в словарь
        /// </summary>
        /// <param name="phoneBook"></param>
        /// <param name="phone"></param>
        /// <param name="name"></param>
        static void AddNote(Dictionary<int, string> phoneBook, int phone, string name)
        {
            phoneBook.Add(phone, name);
        }

        /// <summary>
        /// Проверка на корректность ввода int
        /// </summary>
        /// <returns></returns>
        static int IsIntValid()
        {            
            string tempValue = Console.ReadLine();
            if (EndOfDataEntry(tempValue))
            {
                if (int.TryParse(tempValue, out int result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Неверный ввод");
                    return IsIntValid();
                }
            }
            else return -1;
                        
        }
        

        /// <summary>
        /// Метод для прерывания ввода данных
        /// </summary>
        /// <param name="tempValue"></param>
        /// <returns></returns>
        static bool EndOfDataEntry(string tempValue)
        {
            if(tempValue != String.Empty)
            {
                return true;
            }
            else 
            { 
                return false; 
            }
        }

        /// <summary>
        /// Метод для поиска записи по номеру телефона
        /// </summary>
        /// <param name="phoneBook"></param>
        static void FindNote(Dictionary<int, string> phoneBook)
        {
            Console.Write("\nВведите номер телефона для поиска:");
            int targetPhone = IsIntValid();
            if (targetPhone < 0) return;
            if(phoneBook.TryGetValue(targetPhone, out string name))
            {
                Console.WriteLine($"Владелец телефона - {name}");
            }
            else
            {
                Console.WriteLine("Номер не найден!");
            }
        }
    }
}
