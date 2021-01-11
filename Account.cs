using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
namespace Base_C_Lesson_4
{
    struct Account
    {
        // База: Логин - пароль
        private Dictionary<string, string> _db;

        private void Init()
        {
            _db = new Dictionary<string, string>();
        }


        // Загружаем из файла данные в словарь
        public void LoadFromFile(string file)
        {
            if (File.Exists(file))
            {
                // Инициализация словаря
                Init();

                // Читаем строки из файла
                string[] result = File.ReadAllLines(file);

                // Парсим и формируем базу логин-пароль
                for (int i = 0; i < result.Length; i++) { 
                    string[] words = result[i].Split(new string[] { "||" }, System.StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length == 2 && words[0].Length > 0 && words[1].Length > 0) _db.Add(words[0], words[1]);
                }
            }
            else
            {
                throw new Exception("Файл (" + file + ") не найден.");
            }
        }



        // Метод авторизации (в самом простом варианте)
        public bool Auth(string login, string password)
        {
            if (_db != null && _db.ContainsKey(login))
            {
                return (_db[login] == password) ? true : false;
            }
            return false;
        }


    }
}
