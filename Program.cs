using Lab5.Op;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
namespace Lab5.Op
{
    public static class Program
    {
        private static string str;
        /// <summary>
        /// выход из приложения
        /// </summary>
        /// <returns>выход или остается</returns>
        private static bool Exit()
        {
            Console.Clear();
            Console.WriteLine("Вы уверены что хотите выйти из приложения?\nЕсли да, то нажмите 'y'/'д', если нет, то любой другой символ");
            bool Flag = true;
            while (Flag)
            {
                str = Console.ReadLine();
                if (str.ToLower() == "д" || str.ToLower() == "y")
                {
                    Console.WriteLine("До скорых встреч!");
                    Flag = false;
                    return true;
                    break;
                }
                break;
            }
            return false;
        }
        /// <summary>
        /// управление 
        /// </summary>
        private static void Menu()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Отгадай ответ (нажмите 1)");
            Console.WriteLine("2. Об авторе (нажмите 2)");
            Console.WriteLine("3. Сортировка массива (нажмите 3)");
            Console.WriteLine("4. Игра (нажмите 4)");
            Console.WriteLine("5. Выход (нажмите 5)");
            Console.WriteLine("-----------------------------------------------------------------");
        }
        /// <summary>
        /// об авторе
        /// </summary>
        private static void Info()
        {
            Console.Clear();
            Console.WriteLine("Лабораторная работа №3\nАвтор: Соболев Арсений\nГруппа: 6104-090301D\nВариант №2");
            Console.WriteLine("Нажмите любую кнопку для выхода");
            Console.ReadLine();
        }
        public static void Main()
        {
            bool Flag = true;
            while (Flag)
            {
                Menu();
                Arrays arr = new Arrays();
                str = Console.ReadLine();
                switch (str)
                {
                    case "1":
                        Guesser.GuesserStart();
                        break;
                    case "2":
                        Info();
                        break;
                    case "3":
                        int num = InputClass.LengthInput();
                        if (num == 10)
                        {
                            Arrays arrays = new Arrays();
                            arrays.caseThird(num);
                        }
                        else
                        {
                            Arrays arrays = new Arrays(num);
                            arrays.caseThird(num);
                        }
                        break;
                    case "4":
                        Tetris tetris = new Tetris();
                        tetris.GameStart();
                        break;
                    case "5":
                        bool r = Exit();
                        if (r) 
                        {
                            Flag = false;
                        }
                        break;
                }
            }
        }
    }
}