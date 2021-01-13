using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MyArrayLib;
using System.IO;

namespace Base_C_Lesson_4
{
    partial class Program
    {
        static void Main(string[] args)
        {
            // Задача 1.
            //Task1();

            // Задача 2.
            //Task2();

            // Задача 3.
            //Task3();

            // Задача 4.
            // Task4();

            // Задача 5.
            Task5();


        }

        /*
         * Задание 1.
         * Дан  целочисленный  массив  из 20 элементов.  
         * Элементы  массива  могут принимать  целые  значения  от –10 000 до 10 000 включительно. 
         * Заполнить случайными числами.  Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3. 
         * В данной задаче под парой подразумевается два подряд идущих элемента массива. 
         * Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2. 
        */
        static void Task1()
        {
            Console.Write("\n------------------------------------------------------\n");
            string description = "Задание 1\n";
            description += "Дан  целочисленный  массив  из 20 элементов.  \n";
            description += "Элементы  массива  могут принимать  целые  значения  от –10 000 до 10 000 включительно.\n";
            description += "Заполнить случайными числами.  Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3.\n";
            description += "В данной задаче под парой подразумевается два подряд идущих элемента массива.\n";
            description += "Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.\n";
            Console.Write(description);
            Console.Write("------------------------------------------------------\n");


            int cnt = 20, prevRNum = 0, cntPairs = 0;
            var a = new MyArrayLib<int>();
            Random rnd = new Random();
            for (int i = 0; i < cnt; i++)
            {
                // Генерируем и заполняем массив
                int rNum = rnd.Next(-10000, 10000);
                a[i] = rNum;

                // Проверям пары на совпадение
                if (prevRNum > 0 && rNum > 0) if ((prevRNum % 3 == 0 && rNum % 3 != 0) || (prevRNum % 3 != 0 && rNum % 3 == 0)) cntPairs++;
                prevRNum = rNum;
            }

            Console.WriteLine("\nРезультат:");
            Console.WriteLine("\nЦифры: " + a.toString());
            Console.WriteLine("\nКоличество пар: " + cntPairs);
            Console.ReadKey();
        }


        /*
         *  Задание 2.
            Реализуйте задачу 1 в виде статического класса StaticClass;
            а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
            б) *Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;
            в)**Добавьте обработку ситуации отсутствия файла на диске.
        */
        static void Task2()
        {
            Console.Write("\n------------------------------------------------------\n");
            string description = "Задание 2\n";
            description += "Реализуйте задачу 1 в виде статического класса StaticClass;\n";
            description += "а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;\n";
            description += "б) *Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;\n";
            description += "в)**Добавьте обработку ситуации отсутствия файла на диске.\n";
            Console.Write(description);
            Console.Write("------------------------------------------------------\n");

            // а
            var b = MyArrayStatic<int>.makeArray();
            int cntPairs = MyArrayStatic<int>.FillRandom(ref b, 20);
            string numbers = MyArrayStatic<int>.toString(ref b);
            Console.WriteLine("\nРезультат (а):");
            Console.WriteLine("\nГенерированные цифры: " + numbers);
            Console.WriteLine("\nКоличество пар: " + cntPairs);

            // б и в (чтение и проверка на существование файла)
            try
            {
                // Сохраняем в файл
                MyArrayStatic<int>.SaveToFile(ref b, "db.txt");

                // Читаем Файл
                int[] c = new int[0];
                MyArrayStatic<int>.LoadFromFile(ref c, "db.txt");
                string numbersNew = MyArrayStatic<int>.toString(ref c);

                Console.WriteLine("\nРезультат (б):");
                Console.WriteLine("\nДанные из файла db.txt: " + numbersNew);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: файл db.txt - отсутствует.", e);
            }

            // Пытаемся прочитать из несуществующего файла
            try
            {
                int[] d = new int[0];
                MyArrayStatic<int>.LoadFromFile(ref d, "db_tratata.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine("Данные из файла db_tratata.txt: файл отсутствует.", e);
            }
            Console.ReadKey();
        }

        /*
        *  Задание 3.
        а) Дописать класс для работы с одномерным массивом.Реализовать конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом.Создать свойство Sum, которое возвращает сумму элементов массива, метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива(старый массив, остается без изменений),  метод Multi, умножающий каждый элемент массива на определённое число, свойство MaxCount, возвращающее количество максимальных элементов.
        б)** Создать библиотеку содержащую класс для работы с массивом.Продемонстрировать работу библиотеки
        в) *** Подсчитать частоту вхождения каждого элемента в массив(коллекция Dictionary<int, int>)
        */
        static void Task3()
        {
            Console.Write("\n------------------------------------------------------\n");
            string description = "Задание 3\n";
            description += "а) Дописать класс для работы с одномерным массивом.Реализовать конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом.Создать свойство Sum, которое возвращает сумму элементов массива, метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива(старый массив, остается без изменений),  метод Multi, умножающий каждый элемент массива на определённое число, свойство MaxCount, возвращающее количество максимальных элементов.\n";
            description += "б) ** Создать библиотеку содержащую класс для работы с массивом.Продемонстрировать работу библиотеки\n";
            description += "в) *** Подсчитать частоту вхождения каждого элемента в массив(коллекция Dictionary<int, int>)\n";
            Console.Write(description);
            Console.Write("------------------------------------------------------\n");

            // Создаем массив
            var a = new MyArray(20, 1, 2);

            // Демонстрация работы каждого метода из класса Myarray
            Console.WriteLine("\nРезультат:");
            Console.WriteLine("\nЦифры: " + a.toString());
            Console.WriteLine("\nСумма: " + a.Sum);
            Console.WriteLine("\nВсего чисел: " + a.Count);
            Console.WriteLine("\nМетод Inverse: " + a.Inverse().toString());
            a.Multi(5);
            Console.WriteLine("\nМетод Multi: " + a.toString());
            Console.WriteLine("\nЧастота вхождения каждого элемента в массив: ");
            // Добавляем доп. числа для поиска вхождений (чтобы числа были повторяющимися)
            a.Add(5);
            a.Add(15);
            a.Add(45);
            Dictionary<int, int> b = a.Freq();
            foreach(KeyValuePair<int, int> info in b)
            {
                Console.WriteLine("\n"+ info.Key+ " = "+info.Value+" раз.");
            }
            //////

            Console.ReadKey();
        }

        /*
        *  Задание 4.
           Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. Создайте структуру Account, содержащую Login и Password.        
        */
        static void Task4()
        {
            Console.Write("\n------------------------------------------------------\n");
            string description = "Задание 4\n";
            description += "Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. Создайте структуру Account, содержащую Login и Password.\n";
            Console.Write(description);
            Console.Write("------------------------------------------------------\n");

            // Создаем структуру-базу данных
            string db_file = "accounts.txt";
            var a = new Account();
            try
            {
                // Попытка получить данные из базы (файл)
                a.LoadFromFile(db_file);

                // Проверяем ввод пользователя
                Console.WriteLine("Введите логин:");
                string login = Console.ReadLine();
                Console.WriteLine("Введите пароль:");
                string password = Console.ReadLine();
                // Проверяем
                if (a.Auth(login, password))
                {
                    Console.WriteLine("Авторизация прошла успешно!");
                }
                else
                {
                    Console.WriteLine("Авторизация НЕ прошла!");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }


        /*
        *  Задание 5.
        а) Реализовать библиотеку с классом для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами. Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство, возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).
        **б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
        **в) Обработать возможные исключительные ситуации при работе с файлами.
        */
        static void Task5()
        {
            Console.Write("\n------------------------------------------------------\n");
            string description = "Задание 5\n";
            description += "а) Реализовать библиотеку с классом для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами. Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство, возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).\n";
            description += "б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.\n";
            description += "б) Обработать возможные исключительные ситуации при работе с файлами.\n";
            Console.Write(description);
            Console.Write("------------------------------------------------------\n");

           
            // Создаем многомерный массив
            try
            {
                var a = new MyArrayDimensions(4, 5); // создаем новый и заполняем случайными числами
                //var a = new MyArrayDimensions(); // пытаемся получить из файла (нет проверки на целостность и корректность данных, берем за основу что доступ к файлу для ручной правки - нет)

                // Демонстрация работы каждого метода из класса Myarray
                Console.WriteLine("\nРезультат:");
                Console.WriteLine("\nСумма: " + a.Sum().ToString());
                Console.WriteLine("\nСумма (числа больше 500): " + a.Sum(500).ToString());

                // Получаем доступ к массиву
                var arr = a.GetArray();

                // Номер максимального элемента массива
                int[] maxValueIdx;

                // 3 варианта поиска через передачу параметра, ссылки и результата (out)
                Console.WriteLine("\nИндекс максимального числа:");
                maxValueIdx = a.MaxValueIdxParam(arr);
                Console.WriteLine("\nЧерез параметр - Row:" + maxValueIdx[0].ToString() + ", Idx: " + maxValueIdx[1].ToString() + ", Number: " + maxValueIdx[2].ToString());

                maxValueIdx = a.MaxValueIdxRef(ref arr);
                Console.WriteLine("\nЧерез REF - Row:" + maxValueIdx[0].ToString() + ", Idx: " + maxValueIdx[1].ToString() + ", Number: " + maxValueIdx[2].ToString());

                a.MaxValueIdxOut(arr, out maxValueIdx);
                Console.WriteLine("\nЧерез OUT - Row:" + maxValueIdx[0].ToString() + ", Idx: " + maxValueIdx[1].ToString() + ", Number: " + maxValueIdx[2].ToString());

                // Сохраняем массив в файл
                a.SaveToFile("array.txt");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
