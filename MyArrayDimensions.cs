using System;
using System.Collections.Generic;
namespace Base_C_Lesson_4
{
    class MyArrayDimensions
    {

        private int[,] array;
        public int minValue = 0, maxValue = 0;


        // Свойства - индексаторы
        public int this[int r, int i]
        {
            get { return array[r,i]; }
            set
            {
                array[r,i] = value;
            }
        }

        // Конструкторы
        public MyArrayDimensions(int rows, int cntFill=0)
        {
            Init(rows);
            if (cntFill>0) Fill(cntFill);
        }

        // Инициализация массива
        public void Init(int rows)
        {
            array = new int[rows, 1]; // добавляем только один элемент в каждом измерении, далее автоматом расширится в set
        }


        // Методы:
        private void Fill(int cnt)
        {
            Random rnd = new Random();
            for (int r = 0; r < array.GetLength(0); r++)
            {
                for (int i = 0; i < cnt; i++)
                {
                    checkMemory(i);
                    array[r, i] = rnd.Next(1, 1000);
                    // Считаем мин и макс значения
                    if (array[r, i] > maxValue) maxValue = array[r, i];
                    if (array[r, i] < minValue || minValue == 0) minValue = array[r, i];
                }
            }
        }

        private void checkMemory(int idx)
        {
            if (array.GetLength(1) <= idx) Resize(idx); // проверка выделения памяти
        }


        private void Resize(int max, int add = 20) // операции выделения памяти ресурсоемкие, по этому заранее выделям больше +add на случай последовательных заполнений
        {
            var temp = new int[array.GetLength(0), max+add];
            for (int r = 0; r < array.GetLength(0); r++) for (int i = 0; i < array.GetLength(1); i++) temp[r,i] = array[r,i];
            array = temp;
        }


        public int Sum(int minNumber=0)
        {
            int sum = 0;
            for (int r = 0; r < array.GetLength(0); r++) for (int i = 0; i < array.GetLength(1); i++) if (array[r, i] > minNumber) sum += array[r,i];
            return sum;
        }

        public int[,] GetArray()
        {
            return array;
        }


        public int[] MaxValueIdxParam(int[,] arr)
        {
            int maxValue = 0;
            int[] idx = new int[3] { 0, 0, 0 };
            for (int r = 0; r < arr.GetLength(0); r++)
            {
                for (int i = 0; i < arr.GetLength(1); i++)
                {
                    if(maxValue < arr[r,i])
                    {
                        maxValue = arr[r, i];
                        idx[0] = r;
                        idx[1] = i;
                        idx[2] = maxValue;
                    }
                }
            }
            return idx;
        }


        public int[] MaxValueIdxRef(ref int[,] arr)
        {
            int maxValue = 0;
            int[] idx = new int[3] { 0, 0, 0 };
            for (int r = 0; r < arr.GetLength(0); r++)
            {
                for (int i = 0; i < arr.GetLength(1); i++)
                {
                    if (maxValue < arr[r, i])
                    {
                        maxValue = arr[r, i];
                        idx[0] = r;
                        idx[1] = i;
                        idx[2] = maxValue;
                    }
                }
            }
            return idx;
        }
        
        public void MaxValueIdxOut(int[,] arr, out int[] result)
        {
            int maxValue = 0;
            int[] idx = new int[3] { 0, 0, 0 };
            for (int r = 0; r < arr.GetLength(0); r++)
            {
                for (int i = 0; i < arr.GetLength(1); i++)
                {
                    if (maxValue < arr[r, i])
                    {
                        maxValue = arr[r, i];
                        idx[0] = r;
                        idx[1] = i;
                        idx[2] = maxValue;
                    }
                }
            }
            result = idx;
        }
        




        /*
        public MyArray Inverse()
        {
            var a = new MyArray(Count);
            for (int i = 0; i < Count; i++) a[i] = array[i] * -1;
            return a;
        }

        public void Multi(int number)
        {
            for (int i = 0; i < Count; i++) array[i] *= number;
        }

        public int Add(int value)
        {
            array[Count] = value;
            Count++;
            return Count;
        }

        // Частота вхождения
        public Dictionary<int, int> Freq()
        {
            var a = new Dictionary<int, int>();
            for (int i = 0; i < Count; i++)
            {
                if (a.ContainsKey(array[i])) a[array[i]] += 1; else a[array[i]] = 1;
            }
            return a;
        }

        public string toString(string sep = ",")
        {
            string result = "";
            for (int i = 0; i < this.Count; i++) result += ", " + array[i];
            if (result != "") result = result.Substring(2);
            return result;
        }

        */


    }
}