using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Op
{
    public class Arrays
    {
        private Stopwatch sp1 = new(); //C# сказал, что в этих двух строках можно написать просто new, ибо последующее очевидно
        private Stopwatch sp2 = new();
        private int arraysize = 10;
        private int[] arr;
        private int[] arrCopy1;
        private int[] arrCopy2;
        private int k = 0;

        /// <summary>
        /// инициализация массива по умолчанию
        /// </summary>
        public Arrays()
        {
            this.arr = new int[arraysize];
        }

        /// <summary>
        /// инициализация массива заданным юзером размером
        /// </summary>
        /// <param name="arraysize">размер массива</param>
        public Arrays(int arraysize)
        {
            this.arraysize = arraysize;
            this.arr = new int[arraysize];
        }

        /// <summary>
        /// создает массив
        /// </summary>
        /// <param name="n">размер массива</param>
        private int[] ArrayCreate(int n)
        {
            int[] a = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                a[i] = rnd.Next(-100, 100);
            return a;
        }
        /// <summary>
        /// создает массив
        /// </summary>
        /// <param name="a">массив</param>
        private int[] ArrayCopy(int[] a)
        {
            int[] aCopy = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
                aCopy[i] = a[i];
            return aCopy;
        }

        /// <summary>
        /// сортировка пузырьком
        /// </summary>
        /// <param name="aCopy">массив</param>
        private int[] RandomArrayBubble(int[] aCopy)
        {
            int i1 = aCopy.Length;
            for (int i3 = 0; i3 < aCopy.Length; i3++)
                for (int i2 = 0; i2 + 1 < aCopy.Length; i2++)
                    if (!(aCopy[i2] < aCopy[i2 + 1]) | !(i2 - 1 < i1))
                    {
                        int o1 = aCopy[i2];
                        int o2 = aCopy[i2 + 1];
                        aCopy[i2] = o2;
                        aCopy[i2 + 1] = o1;
                    }
            i1 -= 1;
            return aCopy;
        }
        /// <summary>
        /// сортировка вставками
        /// </summary>
        /// <param name="aCopy">массив</param>
        private int[] RandomArrayInsert(int[] aCopy)
        {
            for (int i3 = 1; i3 < aCopy.Length; i3++)
                for (int i2 = 1; i2 < aCopy.Length; i2++)
                    if ((aCopy[i2 - 1] < aCopy[i2]))
                    {
                        int o1 = aCopy[i2 - 1];
                        int o2 = aCopy[i2];
                        aCopy[i2 - 1] = o2;
                        aCopy[i2] = o1;
                    }
            return aCopy;
        }
        /// <summary>
        /// вывод массива
        /// </summary>
        /// <param name="a">массив</param>
        /// <param name="message">номер массива</p.aram>
        private void ArrayWrite(int[] a, string message)
        {
            Console.WriteLine($"\n {message}");
            if (!(a.Length > 10))
                foreach (int i in a)
                    Console.Write("{0}  ", i);
            else
                Console.Write("Массивы не могут быть выведены на экран, так как длина массива больше 10.");
        }
        /// <summary>
        /// публичный обобщающий метод
        /// </summary>
        /// <param name="n">длина массива</param>
        public void caseThird(int n)
        {
            int[] arr1 = ArrayCreate(n);
            ArrayWrite(arr1, "");
            int[] arr2 = ArrayCopy(arr1);
            Stopwatch sp1 = new Stopwatch();
            Stopwatch sp2 = new Stopwatch();
            sp1.Start();
            arr1 = RandomArrayBubble(arr1);
            sp1.Stop();
            sp2.Start();
            arr2 = RandomArrayInsert(arr2);
            sp2.Stop();
            ArrayWrite(arr1, "1 -----  ");
            ArrayWrite(arr2, "2 -----  ");
            Console.WriteLine($"\nРазница по времени: {Math.Abs(sp1.Elapsed.TotalNanoseconds - sp2.Elapsed.TotalNanoseconds)}");

        }
    }
}
/*/// <summary>
        /// инициализация массива по умолчанию
        /// </summary>
        public Arrays()
        {
            this.arr = new int[arraysize];
        }
        /// <summary>
        /// инициализация массива заданным юзером размером
        /// </summary>
        /// <param name="arraysize">размер массива</param>
        public Arrays(int arraysize)
        {
            this.arraysize = arraysize;
            this.arr = new int[arraysize];
        }
        /// <summary>
        /// создает массив
        /// </summary>
        private int[] ArrayCreate()
        {
            Random rnd = new();
            for (int i = 0; i < this.arraysize; i++)
                arr[i] = rnd.Next(-100, 100);
            return arr;
        }
        /// <summary>
        /// копирование массива
        /// </summary>
        /// <param namea="a">копируемый массив</param>
        /// <returns>копия массива</returns>
        private void ArrayCopy(int[] arr)
        {
            int[] arrCopy1 = new int[arr.Length];
            int[] arrCopy2 = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                arrCopy1[i] = arr[i];
            for (int i = 0; i < arr.Length; i++)
                arrCopy2[i] = arr[i];
            //return arrCopy1;
        }
        /// <summary>
        /// пузырьковая сортировка массива
        /// </summary>
        /// <param name="aCopy">скопированный массив</param>
        /// <param namea="a">копируемый массив</param>
        /// <returns>отсротированный пузырьковой сортировкой массив.</returns>
        private void RandomArrayBubble()
        {
            int i1 = arr.Length;
            for (int i3 = 0; i3 < arr.Length; i3++)
                for (int i2 = 0; i2 + 1 < arr.Length; i2++)
                    if (!(arrCopy1[i2] < arrCopy1[i2 + 1]) | !(i2 - 1 < i1))
                    {
                        int o1 = arrCopy1[i2];
                        int o2 = arrCopy1[i2 + 1];
                        arrCopy1[i2] = o2;
                        arrCopy1[i2 + 1] = o1;
                    }
            //return arrCopy1;
        }
        /// <summary>
        /// сортировка массива вставками
        /// </summary>
        /// <param name="aCopy">скопированный массив</param>
        /// <param namea="a">копируемый массив</param>
        /// <returns>отсротированный сортировкой вставками массив.</returns>
        private void RandomArrayInsert()
        {
            for (int i3 = 1; i3 < arr.Length; i3++)
                for (int i2 = 1; i2 < arr.Length; i2++)
                    if ((arrCopy2[i2 - 1] < arrCopy2[i2]))
                    {
                        int o1 = arrCopy2[i2 - 1];
                        int o2 = arrCopy2[i2];
                        arrCopy2[i2 - 1] = o2;
                        arrCopy2[i2] = o1;
                    }
            //return arrCopy2;
        }
        /// <summary>
        /// сортировка массива вставками
        /// </summary>
        /// <param name="a">отсортированный массив</param>
        /// <param namea="message">оформление вывода</param>
        private void ArrayWrite(int[] a)
        {
            Console.Write($"\n {k} -----  ");
            if (!(a.Length > 10))
                foreach (int i in a)
                    Console.Write($"{i}  ");
            else
                Console.Write("Массивы не могут быть выведены на экран, так как длина массива больше 10.");
            k++;
        }
        */
/*private void ArrL(int len)
        {
            if (len == 10)
            {
                Arrays arrays = new Arrays();
            }
            else
            {
                Arrays arrays = new Arrays(len);
            }
        }*//*
        /// <summary>
        /// время сортировки элементов и отсортированные массивы
        /// </summary>
        /// <param name="arrLength">длина массива</param>
        public void ArraySortTime(int len)
        {
            //ArrL(len);
            ArrayCreate();
            ArrayCopy(this.arr);
            ArrayWrite(arr);
            sp1.Start();
            RandomArrayBubble();
            sp1.Stop();
            sp2.Start();
            RandomArrayInsert();
            sp2.Stop();
            ArrayWrite(arrCopy1);
            ArrayWrite(arrCopy2);
            Console.WriteLine($"\nРазница по времени: {sp1.Elapsed.TotalNanoseconds - sp2.Elapsed.TotalNanoseconds}");
        }*/
