using System;
using System.Collections;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.X86;
using System.Security.AccessControl;
using ClassLibrary;
using Lab_12_3;
using Lav_12_3;

namespace Lab_12_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Введите размер дерева:");
            int size = int.Parse(Console.ReadLine());
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>(size);
            int answer = 1;
            while (answer != 5)
            {
                try
                {
                    Commands();
                    answer = int.Parse(Console.ReadLine());
                    switch (answer)
                    {
                        case 1:
                            Console.WriteLine("Ваше дерево:");
                            tree.ShowTree();
                            break;

                        case 2:
                            MusicalInstrument t = tree.FindMax();
                            Console.WriteLine($"Максимальный элемент дерева: {t}.");
                            break;

                        case 3:
                            tree.TransFromToFindTree();
                            Console.WriteLine("ИСД преобразовано в дерево поиска.");
                            break;

                        case 4:
                            tree.ClearTree();
                            Console.WriteLine("Дерево удалено.");
                            break;

                        case 5:
                            Console.WriteLine("Change da world. My final massege. Goodbye.");
                            break;

                        default:
                            Console.WriteLine();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private static void Commands()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Меню.\n" +
                              "----------------------------------------------------------------------------\n" +
                              "1. Распечатать дерево.\n" +
                              "2. Найти максимальное значение в дереве. \n" +
                              "3. Преобразовать ИСД в дерево поиска. \n" +
                              "4. Удалить дерево из памяти.\n" +
                              "5. Завершение работы.\n" +
                              "----------------------------------------------------------------------------\n");
        }
    }
}