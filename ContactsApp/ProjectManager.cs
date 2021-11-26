using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    /// Класс, выполняющий сохранение и запись в файл
    /// </summary>
    class ProjectManager
    {
        /// <summary>
        /// Стандартный путь к файлу.
        /// </summary>
        private static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                                      @"\\ContactsApp" + "\\ContactsApp.json";

        /// <summary>
        /// Функция, выполняющая сериализацию, для сохранения в файл
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
        /// Функция, выполняющая десериализации, для чтения из файла
        /// </summary>
        /// <param name="filename"></param>
        public static Project LoadFromFile(string filename)
        {
            //Создаём экземпляр десериализатора
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
