using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс, описывающий контакты.
    /// </summary>
    public class Contacts
    {
        /// <summary>
        /// поле класса Фамилия
        /// </summary>
        private string _surname;

        /// <summary>
        /// поле класса Имя
        /// </summary>
        private string _name;

        /// <summary>
        /// поле класса Номер телефона
        /// </summary>
        private PhoneNumber _number;

        /// <summary>
        /// поле класса Дата рождения
        /// </summary>
        private DateTime _birthDate;

        /// <summary>
        /// поле класса Айди вк
        /// </summary>
        private string _vkId;

        /// <summary>
        /// поле класса Почта
        /// </summary>
        private string _email;

        /// <summary>
        /// Ограничение фамилии контакта в 50 символов
        /// </summary>
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Фамилия не должна быть больше 50 символов");
                }
                else
                {
                    value.ToLower();//всё с маленькой буквы
                    char[] familyChar = value.ToCharArray();//представление строки как массив символов
                    familyChar[0] = char.ToUpper(familyChar[0]);//первый символ с большой буквы
                    string familyString = new string(familyChar);//всё в строку
                    _surname = familyString;
                }
            }
        }
      
        /// <summary>
        /// Ограничение имени в 50 символов
        /// </summary>>
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Имя должно содержать меньше 50 символов");
                }
                else
                {
                    value.ToLower();//всё с маленькой буквы
                    char[] nameChar = value.ToCharArray();//представление строки как массив символов
                    nameChar[0] = char.ToUpper(nameChar[0]);//первый символ с большой буквы
                    string nameString = new string(nameChar);//всё в строку
                    _name = nameString;
                }
            }
        }

        /// <summary>
        /// Метод, устанавливающий и возвращающий дату рождения контакта.
        /// </summary>
        public DateTime DateOfBirth
        {
            get { return _birthDate; }
            set
            {
                //Дата рождения не может быть раньше 1 января 1900 года и позже нынешнего времени.
                if (value < _birthDate || value > DateTime.Now)
                {
                    throw new ArgumentException
                        ("Вы ввели неправильную дату рождения.Введите дату, начиная с 1900 и не позже нынешней даты.");
                }
                else
                    _birthDate = value;
            }
        }

        /// <summary>
        /// Ограничение ID ВК в 15 символов
        /// </summary>
        public string VKId
        {
            get { return _vkId; }
            set
            {
                if (value.Length > 15)
                {
                    throw new ArgumentException("ID должен быть меньше 15 символов");
                }
                _vkId = value;
            }
        }

        /// <summary>
        /// Почта контакта ограниченичена 50-ю символами
        /// </summary>
        public string Email
        {
            get { return _email; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Максимальное количество символов = 50!");
                }

                _email = value;
            }
        }

    }
}
    



