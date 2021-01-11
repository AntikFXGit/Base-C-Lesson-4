using System;
using System.IO;
namespace Base_C_Lesson_4
{
    static class MyArrayStatic<T>
    {
        public static T[] makeArray()
        {
            T[] array = new T[0];
            return array;
        }


        // Методы (работаем только с массивами типа Int32)
        public static void Add(ref int[] array, int idx, int value)
        {
            if (array.Length <= idx) Resize(ref array, idx);
            array[idx] = value;
        }

        public static void Resize(ref int[] array, int max)
        {
            Array.Resize(ref array, max+1);
        }

        public static string toString(ref int[] array)
        {
            string result = "";
            for (int i = 0; i < array.Length; i++) result += ", " + array[i];
            if (result != "") result = result.Substring(2);
            return result;
        }

        public static int FillRandom(ref int[] array, int cnt)
        {
            
            int prevRNum = 0, cntPairs = 0;
            Random rnd = new Random();
            for (int i = 0; i < cnt; i++)
            {
                // Генерируем и заполняем массив
                int rNum = rnd.Next(-10000, 10000);

                Add(ref array, i, rNum);

                // Проверям пары на совпадение
                if (prevRNum > 0 && rNum > 0) if ((prevRNum % 3 == 0 && rNum % 3 != 0) || (prevRNum % 3 != 0 && rNum % 3 == 0)) cntPairs++;
                prevRNum = rNum;
            }
            return cntPairs;
        }

        public static void SaveToFile(ref int[] array, string file)
        {
            // Парсинг
            string[] result = Array.ConvertAll(array, val => val.ToString());
            File.WriteAllLines(file, result);
        }

        public static void LoadFromFile(ref int[] array, string file)
        {
            if(File.Exists(file)) { 
                string[] result = File.ReadAllLines(file);
                array = Array.ConvertAll(result, int.Parse);
            } else
            {
                throw new Exception("Файл ("+ file + ") не найден.");
            }
        }


    }
    
}