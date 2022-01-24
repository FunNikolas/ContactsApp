using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp
{
    /// <summary>
    /// Класс, описывающий контакты.
    /// </summary>
    public class Contact : ICloneable
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
        public PhoneNumber phoneNumber = new PhoneNumber();

        /// <summary>
        /// поле класса Дата рождения
        /// </summary>
        private DateTime _dateOfBirth;

        /// <summary>
        /// поле класса Айди вк
        /// </summary>
        private string _vkId;

        /// <summary>
        /// поле класса Почта
        /// </summary>
        private string _email;

        /// <summary>
        /// Ограничение на устанавливаемую дату рождения (минимум 1 января 1900)
        /// </summary>
        private readonly DateTime _dateMinimum = new DateTime(1900, 01, 01);

        /// <summary>
        /// Ограничение фамилии контакта в 50 символов
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname; 
            }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Фамилия не должна быть больше 50 символов");
                }
                //Проверка на пустую строку.
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Вы ввели пустую строку. Повторите ввод.");
                }
                _surname = value;
            }
        }
      
        /// <summary>
        /// Ограничение имени в 50 символов
        /// </summary>>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Имя должно содержать меньше 50 символов");
                }

                //Проверка на пустую строку.
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Вы ввели пустую строку. Повторите ввод.");
                }
                _name = value;
            }
        }

        /// <summary>
        /// Метод, устанавливающий и возвращающий дату рождения контакта.
        /// </summary>
        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                //Дата рождения не может быть раньше 1 января 1900 года.
                if (value < _dateMinimum)
                {
                    throw new ArgumentException(
                        "Вы ввели неправильную дату рождения.\nВведите дату, начиная с 1900 года.");
                }

                //Дата рождения не может быть больше нынешней даты.
                if (value > DateTime.Now)
                {
                    throw new ArgumentException(
                        "Вы ввели неправильную дату рождения.\nДата рождения не может быть больше, чем нынешняя.");
                }
                _dateOfBirth = value;
            }
        }

        /// <summary>
        /// Ограничение ID ВК в 15 символов
        /// </summary>
        public string VKId
        {
            get
            {
                return _vkId;
            }
            set
            {
                if (value.Length > 15)
                {
                    throw new ArgumentException("ID должен быть меньше 15 символов");
                }
                //Проверка на пустую строку.
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Вы ввели пустую строку. Повторите ввод.");
                }
                _vkId = value;
            }
        }

        /// <summary>
        /// Почта контакта ограничена 50-ю символами
        /// </summary>
        public string Email
        {
            get 
            { 
                return _email; 
            }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException(
                        "Вы ввели e-mail, длиной более чем 50 символов.\nВведите e-mail, длиной до 50 символов.");
                }
                //Проверка на пустую строку.
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Вы ввели пустую строку. Повторите ввод.");
                }
                _email = value;
            }
        }

        /// <summary>
        /// Конструктор класса с 6 входными параметрами.
        /// </summary>
        /// <param name="phoneNumber">Номер телефона контакта.</param> 
        /// <param name="name">Имя контакта.</param> .
        /// <param name="surname">Фамилия контакта.</param> 
        /// <param name="email">E-mail контакта.</param> 
        /// <param name="dateOfBirth">Дата рождения контакта.</param> 
        /// <param name="idVk">ID Vk контакта.</param> 
        public Contact(long phoneNumber, string name, string surname, string email, DateTime dateOfBirth,
            string idVk)
        {
            this.phoneNumber.Number = phoneNumber;
            Name = name;
            Surname = surname;
            Email = email;
            DateOfBirth = dateOfBirth;
            VKId = idVk;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Contact()
        {
        }

        /// <summary>
        /// Реализация клонирования
        /// </summary>
        /// <returns>Возвращает объект - клон контакта, с полями: номер телефона, имя, фамилия, емейл, дата рождения, айди вк.</returns>
        public object Clone()
        {
            return new Contact(phoneNumber.Number, Name, Surname, Email, DateOfBirth, VKId);
        }
    }
}
    



