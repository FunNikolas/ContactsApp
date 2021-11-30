using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp
{
    /// <summary>
    /// Класс, описывающий номер телефона 
    /// </summary>
    public class PhoneNumber
    {
        ///<summary>
        ///поле класса номер телефона 
        ///</summary>>
        private long _number;

        /// <summary>
        /// Класс,описывающий номер телефона
        /// </summary>
        public long Number
        {
            get
            {
                return _number; 
            }
            set
            { 
                if(value.ToString()[0]!='7')
                { 
                    throw new ArgumentException("Введите номер телефона, начинающийся с 7.");
                }
   
                if (value > 99999999999 || value < 100000000)
                {
                    throw new ArgumentException("Номер телефона должен состоять из 11 цифр");
                }

                    _number = value;
            }
        }
    }
}
