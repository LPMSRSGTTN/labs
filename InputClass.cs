using Lab5.Op;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using static System.Formats.Asn1.AsnWriter;

namespace Lab5.Op
{
    public static class InputClass
    {
        /// <summary>
        /// контролирует ввод чисел
        /// <param name="Input">ввод</param>>
        /// </summary>
        public static int IntInput()
        {
            int num = 0;
            bool Flag = true;
            while (Flag)
            {
                string Input = Console.ReadLine();
                if (!int.TryParse(Input, out num))
                {
                    Console.WriteLine("ВВЕДИТЕ ЧИСЛО!!!");
                    continue;
                }
                Flag = false;
            }
            return num;
        }
        public static int LengthInput()
        {
            int num = 0;
            bool Flag = true;
            while (Flag)
            {
                Console.Write("Введите длину массива: ");
                string Input = Console.ReadLine();
                if (!int.TryParse(Input, out num))
                {
                    Console.WriteLine("ВВЕДИТЕ ЧИСЛО!!!");
                    continue;
                }
                Flag = false;
                break;
            }
            return num;
        }
    }
}
/*    public static class InputClass
    {
        /// <summary>
        /// контролирует ввод чисел
        /// <param name="Input">ввод</param>>
        /// </summary>
        public static int IntInput()
        {
            int num = -1;
            bool Flag = true;
            while (Flag)
            {
                string Input = Console.ReadLine();
                while (!int.TryParse(Input, out num))
                {
                    Console.WriteLine("ВВЕДИТЕ ЧИСЛО!!!");
                    break;
                }
                Flag = false;
            }
            return num;
        }
    }
}*/
/*public static void Input()
{
    Program prog = new Program();
    prog.Menu();

    int a1 = Guesser.A1;
    int b1 = Guesser.B1;
    double answer = Guesser.Answer;

    Arrays arrays = new Arrays();
    int arrLength = arrays.Length;

    Tetris tetris = new Tetris();
    int score = tetris.Score;
    bool gameRun = tetris.GameRun;
    bool Flag = true;

    while (Flag)
    {

        string s = Console.ReadLine();
        switch (s)
        {
            case "1":
                Console.Clear();
                Console.WriteLine("f = Pi*((ln(B)^5)/sin(A)+1)");
                Console.WriteLine("Введите A");
                while (!int.TryParse(Console.ReadLine(), out a1))
                    Console.WriteLine("Введите ЧИСЛО!!!!!!!!!!");

                Console.WriteLine("Введите B");
                while (!int.TryParse(Console.ReadLine(), out b1))
                    Console.WriteLine("Введите ЧИСЛО!!!!!!!!!!");
                Console.WriteLine(answer); //вывожу ответ для удобства тестирования, чтобы не угадывать
                Console.Write("Введите результат: ");
                int c = 3;
                while (c >= 0 & int.TryParse(Console.ReadLine(), out int input))
                {
                    if ((input != answer))
                    {
                        c--;
                        if (c == 0)
                            Console.WriteLine("Вы проиграли!");
                        else
                            Console.WriteLine($"Неправильно! Попыток осталось: {c}");
                    }
                    else
                        Console.WriteLine("Поздравляю, Вы победили!");
                }
                var inp1 = "";
                Guesser.Guess(answer);
                break;
            case "2":
                prog.Info();
                break;
            case "3":
                Console.Write("Введите длину массива: ");
                Console.Write("(или нажмиите Q чтобы здать размер по умолчанию)");
                bool secondFlag = true;
                var inp = "";
                while (secondFlag)
                {
                    inp = Console.ReadLine();
                    if (int.TryParse(inp, out arrLength))
                    {
                        if (!(arrLength > 0))
                            Console.WriteLine("Длина массива должна быть больше 0");
                        continue;
                    }
                    else if (inp == "Q")
                    {
                        arrLength = arrLength;
                    }
                    else
                    {
                        Console.WriteLine("Введите ЧИСЛО!!!!!!!!!!");
                    }
                }
                if (arrLength == 10)
                {
                    Arrays arrStart = new Arrays();
                    arrStart.ArraySortTime(arrLength);
                }
                else
                {
                    Arrays arrStart = new Arrays(arrLength);
                    arrStart.ArraySortTime(arrLength);
                }
                break;
            case "4":
                Tetris game = new Tetris();
                game.GameStart();
                DateTime LastFall = DateTime.Now;
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKey key = Console.ReadKey(true).Key;
                        if (gameRun)
                        {
                            switch (key)
                            {
                                case ConsoleKey.A:
                                    game.MoveLeft();
                                    break;
                                case ConsoleKey.D:
                                    game.MoveRight();
                                    break;
                                case ConsoleKey.S:
                                    game.MoveDown();
                                    break;
                                case ConsoleKey.Spacebar:
                                    game.FigureRotate();
                                    break;
                                default:
                                    Console.WriteLine("Криворукий");
                                    break;
                            }
                        }
                        if (key == ConsoleKey.N)
                        {
                            gameRun = true;
                            score = 0;
                            game.BoardCreate();
                            game.FigureCall();
                        }
                        else if (key == ConsoleKey.Escape)
                        {
                            break;
                        }
                    }
                    game.Loser();
                    if (score == 10000)
                    {
                        score = 0;
                        continue;
                    }
                    if ((DateTime.Now - LastFall).TotalMilliseconds > 500)
                    {
                        if (!game.MoveDown())
                            game.FigureFixation();
                        LastFall = DateTime.Now;
                    }
                    game.ScreenDraw();
                    System.Threading.Thread.Sleep(50);
                }
                break;
            case "5":
                bool r = Exit();
                if (r) Flag = false;
                break;
        }*/
/*public static int StringInput(string Input)
       {
           int num;
           while (!int.TryParse(Input, out num))
           {
               Console.WriteLine("ВВЕДИТЕ ЧИСЛО!!!");
           }
       }*/
/*private static int a1;
private static int arrsize;
private static ConsoleKey key;
private static string str;*/
/*public static int IntInput
{
    get
    {
        return a1;
    }
    set
    {
        while (!int.TryParse(Console.ReadLine(), out a1))
        {
            Console.WriteLine("ВВЕДИТЕ ЧИСЛО!!!");
        }
    }
}
/// <summary>
/// контролирует нажатия клавиш управления
/// </summary>
public static ConsoleKey KeyInput
{
    get
    {
        return key;
    }
    set
    {
        key = Console.ReadKey(true).Key;
    }
}
/// <summary>
/// контролирует ввод строк
/// </summary>
public static string StringInput
{
    get
    {
        return str;
    }
    set
    {
        while (str != null)
        {
            str = Console.ReadLine();
        }
    }
}*/
