using System;
using System.Collections.Generic;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set = new HashSet<int>();
            GetValueFromUser(set);
            Console.ReadKey();
            
        }

        static void GetValueFromUser(HashSet<int> set)
        {          
            int userValue = IsIntValid();
            if (userValue < 0) return;
            AddNumber(set, userValue);
            GetValueFromUser(set);
        }

        static void AddNumber(HashSet<int> set, int userValue)
        {
            
            if(set.Add(userValue))
            {
                Console.WriteLine("\nЧисло успешно добавлено!");
            }
            else
            {
                Console.WriteLine("Такое число уже существует! Попробуйте еще раз!");
            }
        }

        static int IsIntValid()
        {
            Console.Write("Введите число:");
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
            if (tempValue != String.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
