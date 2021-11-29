using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ContactApp
{
    /// <summary>
    /// Класс, выполняющий сохранение и запись в файл
    /// </summary>
    public class ProjectManager
    {
        /// <summary>
        /// Стандартный путь к файлу.
        /// </summary>
        private static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                                      @"\\ContactApp" + "\\ContactApp.json";
        private static JsonReader reader;
        private static TextWriter writer;

        /// <summary>
        /// Функция, выполняющая сериализацию, для сохранения в файл
        /// </summary>
        /// <param name="project"></param>
        /// <param name="filename">Путь к файлу</param>
        public static void SaveToFile(Project project, string filename)
        {
            //создаём объект сериализатора
            JsonSerializer serializer = new JsonSerializer();

            try
            {
                //Открываем поток для записи в файл с указанием пути
                using (StreamWriter sw = new StreamWriter(filename))
                using (JsonWriter writer = new JsonTextWriter(sw)) ;
            }
            catch
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать
                serializer.Serialize(writer, project);
            }
            return;
        }
        /// <summary>
        /// Функция, выполняющая десериализации, для чтения из файла
        /// </summary>
        /// <param name="filename">Путь до файла</param>
        public static Project LoadFromFile(string filename)
        {
            Project project2;
            var serializer = new JsonSerializer();

            try
            {
                //Открываем поток для чтения из файла с указанием пути
                using (StreamReader sr = new StreamReader(filename))
                using (JsonReader reader = new JsonTextReader(sr)) ;
                //Вызываем десериализацию и явно преобразуем результат в целевой тип данных
                project2 = serializer.Deserialize<Project>(reader);
            }
            catch
            {
                return new Project();
            }
            return project2;
        }
    }
}
