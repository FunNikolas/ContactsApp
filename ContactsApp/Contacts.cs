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
    public class Contacts : ICloneable
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
                return _birthDate;
            }
            set
            {
                //Дата рождения не может быть раньше 1 января 1900 года и позже нынешнего времени.
                if (value < _birthDate || value > DateTime.Now)
                {
                    throw new ArgumentException
                        ("Вы ввели неправильную дату рождения.Введите дату, начиная с 1900 и не позже нынешней даты.");
                }
                    _birthDate = value;
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
                _vkId = value;
            }
        }

        /// <summary>
        /// Почта контакта ограниченичена 50-ю символами
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
                    throw new ArgumentException("Максимальное количество символов = 50!");
                }

                _email = value;
            }
        }

        /// <summary>
        /// Конструктор класса с 6 входными параметрами.
        /// </summary>
        /// <param name="phoneNumber"></param> Номер телефона контакта.
        /// <param name="name"></param> Имя контакта.
        /// <param name="surname"></param> Фамилия контакта.
        /// <param name="email"></param> E-mail контакта.
        /// <param name="dateOfBirth"></param> Дата рождения контакта.
        /// <param name="idVk"></param> ID Vk контакта.
        public Contacts(long phoneNumber, string name, string surname, string email, DateTime dateOfBirth,
            string idVk)
        {
            this._number.Number = phoneNumber;
            Name = name;
            Surname = surname;
            Email = email;
            DateOfBirth = dateOfBirth;
            VKId = idVk;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Contacts()
        {
        }

        /// <summary>
        /// Реализация клонирования
        /// </summary>
        /// <returns>Возвращает объект - клон контакта, с полями: номер телефона, имя, фамилия, емейл, дата рождения, айди вк.</returns>
        public object Clone()
        {
            return new Contacts(_number.Number, Name, Surname, Email, DateOfBirth, VKId);
        }
    }
}
    



