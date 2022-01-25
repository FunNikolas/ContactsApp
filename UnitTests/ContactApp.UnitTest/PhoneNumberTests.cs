﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ContactApp.UnitTest
{
    [TestFixture]
    class PhoneNumberTests
    {
        private PhoneNumber _phoneNumber;

        [SetUp]
        public void InitNumber()
        {
            _phoneNumber = new PhoneNumber();
        }

        /// <summary>
        /// Неготивные тесты вызова свойства Number класса PhoneNumber.
        /// </summary>
        /// <param name="wrongPhoneNumber"></param>
        /// <param name="message"></param>
        [TestCase("11111111111", "Должно возникать исключение, если номер начинается не с 7",
                TestName = "Присвоение number номера телефона, начинающегося не с 7")]
            [TestCase("123456789123", "Должно возникать исключение, если введенный номер длиннее 11 символов",
                TestName = "Присвоение number номера телефона, который длиннее 11 символов")]
            [TestCase("1234567891", "Должно возникать исключение, если введенный номер короче 11 символов",
                TestName = "Присвоение number номера телефона, который короче 11 символов")]
            public void TestPhoneNumberSet_ArgumentException(string wrongPhoneNumber, string message)
            {
                Assert.Throws<ArgumentException>(
                    () => { _phoneNumber.Number = Convert.ToInt64(wrongPhoneNumber); },
                    message);
            }

        /// <summary>
        /// Положительные тесты на присваевание номера телефона.
        /// </summary>
        /// <param name="correctNumber"></param>
        /// <param name="message"></param>
            [TestCase("79998887766", "Тест пройден, если номер телефона присвоен успешно",
                TestName = "Присвоение правильного номера телефона.")]
            public void TestPhoneNumberSet_CorrectArgument(string correctNumber, string message)
            {
                _phoneNumber.Number = Convert.ToInt64(correctNumber);
                Assert.AreEqual(Convert.ToInt64(correctNumber), _phoneNumber.Number,
                    message);
            }

        /// <summary>
        /// Тест для геттера возвращение значения номера телефона.
        /// </summary>
        /// <param name="correctNumber"></param>
        /// <param name="message"></param>
            [TestCase("76665554433", "Геттер phone, возвращает номер телефона",
                TestName = "Возвращение геттером номера телефона")]
            public void TestPhoneNumberGet_CorrectArgument(string correctNumber, string message)
            {
                _phoneNumber.Number = Convert.ToInt64(correctNumber);
                Assert.AreEqual(Convert.ToInt64(correctNumber), _phoneNumber.Number,
                    message);
            }
    }
}
