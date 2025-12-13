using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Op
{
    public class Tetris
    {
        private const int size = 10;
        private int[,] Board = new int[size, size];
        private int[,] FigureCurrent;
        private int score = 0;
        private int X, Y;
        private bool gameRun = true;
        private bool drawn = false;
        private Random random = new();
        private int[][,] Figures =
        {
        new int[,] { {1,1,1} },
        new int[,] { {0,1,0}, {1,1,1} },
        new int[,] { {1,1}, {1,1} },
        new int[,] { {1,1,0}, {0,1,1} },
        new int[,] { {0,1,1}, {1,1,0} },
        new int[,] { {1,1,1}, {0,0,1} },
        new int[,] { {1,0,0}, {1,1,1} }
        };
        /// <summary>
        /// запуск тетриса
        /// </summary>
        public void GameStart()
        {
            BoardCreate();
            FigureCall();
            GameLoop();
        }

        /// <summary>
        /// создание поля
        /// </summary>
        private void BoardCreate()
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Board[y, x] = 0;
                }
            }
        }
        /// <summary>
        /// спавн фигурки 
        /// </summary>
        /// <return>номер фигуры</return>
        private int FigureCall()
        {
            int num = random.Next(7);
            FigureCurrent = Figures[num];
            X = 4;
            Y = 0;
            return num;
        }
        /// <summary>
        /// сообщение в случае поражения
        /// </summary>
        private void Loser()
        {
            if (!IsPositionRight())
            {
                gameRun = false;
                Console.WriteLine($"Игра окончена! Счёт: {score}");
            }
        }
        /// <summary>
        ///проверка правильности позиции
        /// </summary>
        /// <return>правильно или нет</return>
        private bool IsPositionRight(int newX = -1, int newY = -1)
        {
            if (newX == -1)
            {
                newX = X;
            }
            if (newY == -1)
            {
                newY = Y;
            }
            for (int y = 0; y < FigureCurrent.GetLength(0); y++)
            {
                for (int x = 0; x < FigureCurrent.GetLength(1); x++)
                {
                    if (FigureCurrent[y, x] != 0)
                    {
                        int BoardX = x + newX;
                        int BoardY = y + newY;
                        if (BoardX < 0 || BoardX >= 10 || BoardY >= 10)
                        {
                            return false;
                        }
                        if (BoardY >= 0 && Board[BoardY, BoardX] != 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// сдвиг влево
        /// </summary>
        private void MoveLeft()
        {
            if (gameRun && IsPositionRight(X - 1, Y))
            {
                X--;
                if (gameRun && !IsPositionRight(X, Y))
                {
                    X++;
                }
            }
        }

        /// <summary>
        /// сдвиг вправо
        /// </summary>
        private void MoveRight()
        {
            if (gameRun && IsPositionRight(X + 1, Y))
            {
                X++;
            }
        }

        /// <summary>
        /// сдвиг вниз
        /// </summary>
        /// <returns>можно или нельзя</returns>
        private bool MoveDown()
        {
            if (gameRun && IsPositionRight(X, Y + 1))
            {
                Y++;
                return true;
            }
            return false;
        }
        /// <summary>
        /// поворот на 90 градусов
        /// </summary>
        private void FigureRotate()
        {
            int rows = FigureCurrent.GetLength(0);
            int cols = FigureCurrent.GetLength(1);
            int[,] rotated = new int[cols, rows];


            for (int y = 0; y < rows; y++)
                for (int x = 0; x < cols; x++)
                    rotated[x, rows - 1 - y] = FigureCurrent[y, x];

            int[,] backup = FigureCurrent;
            FigureCurrent = rotated;
            if (!IsPositionRight())
                FigureCurrent = backup;
        }
        /// <summary>
        /// остановка фигуры
        /// </summary>
        private void FigureFixation()
        {
            for (int y = 0; y < FigureCurrent.GetLength(0); y++)
            {
                for (int x = 0; x < FigureCurrent.GetLength(1); x++)
                {
                    if (FigureCurrent[y, x] != 0)
                    {
                        int BoardY = Y + y;
                        int BoardX = X + x;
                        if (BoardY >= 0 || BoardX < 10 && BoardX >= 0 || BoardY < 10)
                        {
                            Board[BoardY, BoardX] = FigureCurrent[y, x];
                        }
                    }
                }
            }
            LineCheck();
            FigureCall();
        }
        /// <summary>
        /// проверка заполненности
        /// </summary>
        private void LineCheck()
        {
            for (int y = 9; y >= 0; y--)
            {
                bool full = true;
                for (int x = 0; x < 10; x++)
                {
                    if (Board[y, x] == 0)
                    {
                        full = false;
                        break;
                    }
                }
                if (full)
                {
                    LineRemove(y);
                    score += 100;
                    y++;
                }
            }
        }
        /// <summary>
        /// удаление ряда
        /// </summary>
        private void LineRemove(int LineY)
        {
            for (int y = LineY; y > 0; y--)
                for (int x = 0; x < 10; x++)
                    Board[y, x] = Board[y - 1, x];
            for (int x = 0; x < 10; x++)
                Board[0, x] = 0;
        }
        /// <summary>
        /// отрисовка интерфейса
        /// </summary>
        private void ScreenDraw()
        {
            Console.Clear();
            Console.WriteLine("ТЕТРИС");
            Console.WriteLine("========================");

            for (int y = 0; y < 10; y++)
            {
                Console.Write("/");
                for (int x = 0; x < 10; x++)
                {
                    drawn = false;
                    int FigureY = y - Y;
                    int FigureX = x - X;

                    if (gameRun && FigureY >= 0 && FigureX >= 0 &&
                        FigureY < FigureCurrent.GetLength(0) &&
                        FigureX < FigureCurrent.GetLength(1) &&
                        FigureCurrent[FigureY, FigureX] != 0)
                    {
                        Console.Write(" #");
                        drawn = true;
                    }

                    if (!drawn)
                    {
                        if (Board[y, x] == 0)
                            Console.Write(" .");
                        else
                            Console.Write(" #");
                    }
                }
                Console.WriteLine(" /");
            }
            Console.WriteLine("========================");
            Console.WriteLine($"Счет: {score}");
            if (!gameRun)
                Console.WriteLine("Нажмите N для новой игры (или Esc если хотите выйти)");
        }
        /// <summary>
        /// обновление экрана
        /// </summary>
        private void GameLoop()
        {
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
                                MoveLeft();
                                break;
                            case ConsoleKey.D:
                                MoveRight();
                                break;
                            case ConsoleKey.S:
                                MoveDown();
                                break;
                            case ConsoleKey.Spacebar:
                                FigureRotate();
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
                        BoardCreate();
                        FigureCall();
                    }
                    else if (key == ConsoleKey.Escape)
                    {
                        break;
                    }
                }
                Loser();
                if (score == 10000)
                {
                    score = 0;
                    continue;
                }
                if ((DateTime.Now - LastFall).TotalMilliseconds > 500)
                {
                    if (!MoveDown())
                        FigureFixation();
                    LastFall = DateTime.Now;
                }
                ScreenDraw();
                System.Threading.Thread.Sleep(50);
            }
        }
    }
}
