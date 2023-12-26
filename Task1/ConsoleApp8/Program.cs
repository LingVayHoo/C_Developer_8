using System;
using System.Collections.Generic;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем коллекцию  и заполняем случайными числами от 0 до 100
            List<int> ints = new List<int>();
            RandomFillList(ints, 100);
            // Выводим на экран
            Console.WriteLine("Вся коллекция\n");
            PrintList(ints);
            Console.ReadKey();
            // Удаляем элементы в диапазоне с 25 по 50 и выводим на экран
            DeleteValuesInRange(ints, 25, 50);
            Console.WriteLine("Коллекция после удаления элементов с 25 по 50\n");
            PrintList(ints);
            Console.ReadKey();
        }

        static void RandomFillList(List<int> targetList, int countList)
        {
            Random rnd = new Random();

            for (int i = 0; i < countList; i++)
            {
                targetList.Add(rnd.Next(0, 101));
                //targetList.Add(i + 1);
            }
        }

        static void PrintList(List<int> targetList)
        {
            for (int i = 0;i < targetList.Count;i++)
            {
                Console.Write($"{targetList[i]} ");
            }
            Console.WriteLine("\n\n");
        }

        static void DeleteValuesInRange(List<int> targetList, int rangeStart, int rangeEnd)
        {
            targetList.RemoveRange(rangeStart, rangeEnd - rangeStart);
        }
    }
}
