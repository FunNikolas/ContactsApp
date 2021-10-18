using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    class PhoneNumber
    {
        private long _number;
        /// <summary>
        /// Класс,описывающий номер телефона
        /// </summary>
        public long Number
        {
            get { return _number; }
            set
            { 
                ///<summary>
                ///Номер телефона контакта должен начинаться с 7
                ///</summary>
                if(value.ToString()[0]!='7')
                { throw new ArgumentException("Введите номер телефона, начинающийся с 7."); }
                ///<summary>
                ///Номер телефона контакта должен состоять из 11 цифр
                /// </summary>
                if (value > 99999999999 || value < 100000000)
                { throw new ArgumentException("Номер телефона должен состоять из 11 цифр"); }
                else
                {
                    _number = value;
                }
            }
        }
    }
}
