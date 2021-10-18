﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ContactsApp
{
    class ProjectManager
    {
        /// <summary>
        /// Функция, выполняющая функцию сериализации
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filename">Путь к файлу</param>
        public static void SaveToFile(Project data, string filename)
        {
            //создаём объект сериализатора
            JsonSerializer serializer = new JsonSerializer();

            //Открываем поток для записи в файл с указанием пути
            using (StreamWriter sw = new StreamWriter(filename))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать
                serializer.Serialize(writer, data);
            }
        }
        /// <summary>
        /// Функция, выполняющая функцию десериализации
        /// </summary>
        /// <param name="filename"></param>
        public static Project LoadFromFile(string filename)
        {
            //Создаём экземпляр сериализатора
            JsonSerializer serializer = new JsonSerializer();

            //Открываем поток для чтения из файла с указанием пути
            using (StreamReader sr = new StreamReader(filename))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                //Вызываем десериализацию и явно преобразуем результат в целевой тип данных
                return (Project)serializer.Deserialize<Project>(reader);
            }
        }
    }
}
