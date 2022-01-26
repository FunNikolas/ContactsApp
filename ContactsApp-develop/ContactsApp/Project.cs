using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp;

namespace ContactApp
{
    /// <summary>
    /// Класс, содержащий лист всех контактов.
    /// </summary>
    public class Project
    {
        ///// <summary>
        ///// Лист, который хранит в себе список контактов.
        ///// </summary>
        //public List<Contact> contactsList = new List<Contact>();

        /// <summary>
        /// Свойство списка всех контактов
        /// </summary>
        public List<Contact> _contactsList { get; set; } = new List<Contact>();

        /// <summary>
        /// Сортировка листа.
        /// </summary>
        /// <param name="contacts"> Лист для сортировки.</param>
        /// <returns></returns>
        public List<Contact> Sort(List<Contact> contacts)
        {
            var sortedContacts = from u in contacts orderby u.Surname select u;
            return sortedContacts.ToList();
        }

        /// <summary>
        /// Поиск контакта по строке.
        /// </summary>
        /// <param name="substringForSearch"> Строка по которой ведется поиск.</param>
        /// <param name="contacts"> Список контактов для поиска.</param>
        /// <returns></returns>
        public List<Contact> FindContacts(string substringForSearch)
        {
            var findProject = _contactsList;
            if (substringForSearch == "")
            {
                return findProject;
            }

            findProject = _contactsList.Where(contact =>
                contact.Surname.StartsWith(substringForSearch, StringComparison.OrdinalIgnoreCase) ||
                contact.Name.StartsWith(substringForSearch, StringComparison.OrdinalIgnoreCase)).ToList();
            if (findProject.Count == 0)
            {
                return findProject;
            }

            findProject = Sort(findProject);
            return findProject;
        }

        /// <summary>
        /// поиск именинников из текущего списка контактов и создание списка из таких контактов
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<Contact> BirthdayMan(DateTime date)
        {
            var birthdatemanList = new List<Contact>();
            var Contactlist = new List<Contact>();
            Contactlist = _contactsList;
            foreach (Contact contact in Contactlist)
            {
                if (contact.DateOfBirth.Month == date.Month && contact.DateOfBirth.Day == date.Day)
                {
                    birthdatemanList.Add((contact));
                }
            }
            return birthdatemanList;
        }
    }
}
