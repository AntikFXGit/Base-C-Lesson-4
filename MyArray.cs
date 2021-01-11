using System;
using System.Collections.Generic;
namespace Base_C_Lesson_4
{
    class MyArray
    {

        private int[] array;
        public int Count = 0; // количество элементов в массиве
        public int Sum = 0;

        // Свойства - индексаторы
        public int this[int i]
        {
            get { return array[i]; }
            set
            {
                if (array.Length <= i) Resize(i); // проверка выделения памяти
                array[i] = value;
                Count++;
            }
        }

        // Конструкторы
        public MyArray(int cnt)
        {
            Resize(cnt);
        }
        public MyArray(int cnt, int minNum=1, int step=1)
        {
            Resize(cnt);
            for (int i = 0; i < cnt; i++)
            {
                array[i] = minNum + step * i;
                Sum += array[i];
                Count++;
            }
        }


        // Методы:
        private void Resize(int max, int add = 20) // операции выделения памяти ресурсоемкие, по этому заранее выделям больше +add на случай последовательных заполнений
        {
            Array.Resize(ref array, max + add);
        }

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




    }
}