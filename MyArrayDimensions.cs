using System;
using System.Collections.Generic;
using System.IO;

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

        public MyArrayDimensions()
        {
            try
            {
                LoadFromFile("array.txt");
            } catch(Exception e)
            {
                throw new Exception(e.Message);
            }
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
                        idx[0] = r; // номер измерения
                        idx[1] = i; // индекс 
                        idx[2] = maxValue; // число
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

        public void Add(int r, int i, int value)
        {
            checkMemory(i);
            array[r, i] = value;
        }

        public void SaveToFile(string file)
        {
            string text = "";
            for (int r = 0; r < array.GetLength(0); r++)
            {
                if (r > 0) text +="\n";
                string elems = "";
                for (int i = 0; i < array.GetLength(1); i++)
                {
                    elems += ","+ array[r,i].ToString();
                }
                elems = elems.Substring(1);
                text += elems;
            }

            // Save data into file
            string fPath = "./" + file;
            using (StreamWriter sw = new StreamWriter(fPath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(text);
            }
        }


        public void LoadFromFile(string file)
        {
            // Строки - измерения
            // Перечисления - элементы в каждом измерении

            // 0. Проверка на существование файла
            if (File.Exists(file))
            {
                // 1. Смотрим сколько строк (измерений) в файле
                string fPath = "./" + file;
                using (StreamReader sr = new StreamReader(fPath, System.Text.Encoding.Default))
                {
                    string line;
                    List<string> lines = new List<string>();
                    while ((line = sr.ReadLine()) != null) lines.Add(line);

                    // 2. Заполняем массив
                    var a = new MyArrayDimensions(lines.Count, 0);
                    for(int r=0; r< lines.Count; r++)
                    {
                        // Разбиваем на элементы
                        string[] elems = lines[r].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        for(int i=0; i<elems.Length; i++)
                        {
                            int val = int.Parse(elems[i]);
                            a.Add(r, i, val);
                            // Считаем мин и макс значения
                            if (val > maxValue) maxValue = val;
                            if (val < minValue || minValue == 0) minValue = val;
                        }
                    }
                    array = a.GetArray();
                }
            }
            else
            {
                throw new Exception("Файл (" + file + ") не найден.");
            }
            


        }









    }
}