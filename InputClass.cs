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
        /// <summary>
        /// контролирует ввод чисел, но специальный для длины массива 
        /// <param name="Input">ввод</param>>
        /// </summary>
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

