using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Op
{
    public static class Guesser
    {
        private static int a1;
        private static int b1;
        private static int ans;
        private static double answer;
        /// <summary>
        /// считывание первый аргумента выражения
        /// </summary>
        /// <returns>первая переменная</returns>
        private static void GuessInputA()
        {
            Console.Clear();
            Console.WriteLine("f = Pi*((ln(B)^5)/sin(A)+1)");
            Console.WriteLine("Введите A");
            a1 = InputClass.IntInput();
        }
        /// <summary>
        /// считывание второй аргумента выражения
        /// </summary>
        /// <returns>вторая переменная</returns>
        private static void GuessInputB()
        {
            Console.WriteLine("Введите B");
            b1 = InputClass.IntInput();
        }
        /// <summary>
        /// выражение ответа
        /// </summary>
        /// <returns>ответ</returns>
        private static void Answer()
        {
            answer = Math.PI * (Math.Log(Math.Pow(b1, 5)) / (Math.Sin(a1) + 1));
        }
        /// <summary>
        /// главный ответ 
        /// </summary>
        private static void Guess()
        {
            Console.WriteLine(answer); //вывожу ответ для удобства тестирования, чтобы не угадывать
            Console.Write("Введите результат: ");
            int c = 3;
            bool Flag = true;
            while (Flag)
            {
                while (c >= 0)
                {
                    ans = InputClass.IntInput();
                    int intAnswer;
                    intAnswer = (int)answer;
                    if (ans != intAnswer)
                    {
                        c--;
                        if (c == 0)
                        {
                            Console.WriteLine("Вы проиграли!");
                            Flag = false;
                        }
                        else
                        {
                            Console.WriteLine($"Неправильно! Попыток осталось: {c}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Поздравляю, Вы победили!");
                        Flag = false;
                        c = -1;
                    }
                }
            }
        }
        /// <summary>
        /// публичный обобщающий метод
        /// </summary>
        public static void GuesserStart()
        {
            GuessInputA();
            GuessInputB();
            Answer();
            Guess();
        }
    }
}
