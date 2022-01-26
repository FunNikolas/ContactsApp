using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ContactApp; 

namespace ContactApp.UnitTest
{
    [TestFixture]
    public class ContactTest
    {
        [SetUp]
        public void InitContact()
        {
            _contact = new Contact();
        }
        private Contact _contact;
        //Тесты для Surname
        /// <summary>
        /// Негативный тест для сетера Surname, на пустую строчку и определяющее генерацию исключения.
        /// </summary>
        /// <param name="wrongSurname"></param>
        /// <param name="message"></param>
        [TestCase("", "Должно возникать исключение, если фамилия - пустая строка",
            TestName = "Присвоение пустой строки в качестве фамилии")]
        [TestCase("123456789_123456789_123456789_123456789_123456789_123456789_123456789",
            "Должно возникать исключение, если фамилия длиннее 50 символов",
            TestName = "Присвоение неправильной фамилии, больше 50 символов")]
        public void TestSurnameSet_ArgumentException(string wrongSurname, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.Surname = wrongSurname; }, message);
        }

        /// <summary>
        /// Положительный тест для сетера Surname, на присвоение фамилии
        /// </summary>
        /// <param name="correctSurname"></param>
        /// <param name="message"></param>
        [TestCase("Смирнов", "Тест не пройден, фамилия присвоена неверно",
            TestName = "Присвоение правильной фамилии")]
        public void TestSurnameSet_CorrectArgument(string correctSurname, string message)
        {
            Assert.DoesNotThrow(
                () => { _contact.Surname = correctSurname; }, message);
        }

        /// <summary>
        /// Тест для геттера поля Surname
        /// </summary>
        /// <param name="correctSurname"></param>
        /// <param name="message"></param>
        [TestCase("Смирнов", "Геттер surname возвращает неверную фамилию",
            TestName = "Возвращение геттером фамилии")]
        public void TestSurnameGet_CorrectArgument(string correctSurname, string message)
        {
            _contact.Surname = correctSurname;
            //Если не равны, то выдаст сообщение об этом
            Assert.AreEqual(correctSurname, _contact.Surname, message);
        }

        //Тесты свойства Name.
        /// <summary>
        /// Негативные тесты для сетера поля Name: на проверку пустого поля, максимального количества символов
        /// </summary>
        /// <param name="wrongName"></param>
        /// <param name="message"></param>
        [TestCase("", "Должно возникать исключение, если поле имя - пустая строка",
            TestName = "Присвоение пустой строки в качестве имени")]
        [TestCase("123456789_123456789_123456789_123456789_123456789_123456789_123456789",
            "Должно возникать исключение, если имя длиннее 50 символов",
            TestName = "Присвоение неправильного имени, больше 50 символов")]
        public void TestNameSet_ArgumentException(string wrongName, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.Name = wrongName; },
                message);
        }

        /// <summary>
        /// Положительный тест для сетера поля Name: присвоение значения 
        /// </summary>
        /// <param name="correctName"></param>
        /// <param name="message"></param>
        [TestCase("Имя", "Тест не пройден, имя  присвоено неверно",
            TestName = "Присвоение правильного имени")]
        public void TestNameSet_CorrectArgument(string correctName, string message)
        {
            Assert.DoesNotThrow(
                () => { _contact.Name = correctName; }, message);
        }

        /// <summary>
        /// Тест для геттера поля Name.
        /// </summary>
        /// <param name="correctName"></param>
        /// <param name="message"></param>
        [TestCase("имя", "Геттер name возвращает неверное имя",
            TestName = "Возвращение геттером имени")]
        public void TestNameGet_CorrectArgument(string correctName, string message)
        {
            _contact.Name = correctName;
            Assert.AreEqual(correctName, _contact.Name, message);
        }

        //Тесты свойства Email.
        /// <summary>
        /// Негативные тесты для сетера поля Email: на проверку пустого поля, максимального количества символов
        /// </summary>
        /// <param name="wrongEmail"></param>
        /// <param name="message"></param>
        [TestCase("", "Должно возникать исключение, если поле е-мейл - пустая строка",
            TestName = "Присвоение пустой строки в качестве е-мейла")]
        [TestCase("123456789_123456789_123456789_123456789_123456789_123456789_123456789",
            "Должно возникать исключение, если е-мейл длиннее 50 символов",
            TestName = "Присвоение неправильного е-мейла, больше 50 символов")]
        public void TestEmailSet_ArgumentException(string wrongEmail, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.Email = wrongEmail; },
                message);
        }

        /// <summary>
        /// Положительный тест для сетера поля Email: присвоение значения 
        /// </summary>
        /// <param name="correctEmail"></param>
        /// <param name="message"></param>
        [TestCase("d.kletsko595@gmail.com", "Тест не пройден, е-мейл присвоен неверно",
            TestName = "Присвоение правильного е-мейла")]
        public void TestEmailSet_CorrectArgument(string correctEmail, string message)
        {
            Assert.DoesNotThrow(
                () => { _contact.Email = correctEmail; }, message);
        }

        /// <summary>
        /// Тест для геттера поля Email.
        /// </summary>
        /// <param name="correctEmail"></param>
        /// <param name="message"></param>
        [TestCase("тут почта", "Геттер е-мейл возвращает неверное имя",
            TestName = "Возвращение геттером е-мейла")]
        public void TestEmailGet_CorrectArgument(string correctEmail, string message)
        {
            _contact.Email = correctEmail;
            Assert.AreEqual(correctEmail, _contact.Email, message);
        }

        //Тесты свойства VkId.
        /// <summary>
        /// Негативные тесты для сетера поля VkId: на проверку пустого поля, максимального количества символов
        /// </summary>
        /// <param name="wrongVkId"></param>
        /// <param name="message"></param>
        [TestCase("", "Должно возникать исключение, если поле id vk - пустая строка",
            TestName = "Присвоение пустой строки в качестве id vk")]
        [TestCase("123456789_123456789_123456789", "Должно возникать исключение, если id vk длиннее 15 символов",
            TestName = "Присвоение неправильного id vk, больше 15 символов")]
        public void TestVkIDSet_ArgumentException(string wrongVkId, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.VKId = wrongVkId; }, message);
        }

        /// <summary>
        /// Положительный тест для сетера поля VkId: присвоение значения. 
        /// </summary>
        /// <param name="correctIdVk"></param>
        /// <param name="message"></param>
        [TestCase("VkId", "Тест не пройден, VkId присваивается неверное значение.",
            TestName = "Присвоение правильного VkId")]
        public void TestVkIdSet_CorrectArgument(string correctIdVk, string message)
        {
            Assert.DoesNotThrow(
                () => { _contact.VKId = correctIdVk; }, message);
        }

        /// <summary>
        /// Тест для геттера поля IdVk.
        /// </summary>
        /// <param name="correctIdVk"></param>
        /// <param name="message"></param>
        [TestCase("VkId", "Геттер VkId возвращает неверное имя",
            TestName = "Возвращение геттером VkId")]
        public void TestIdVkGet_CorrectArgument(string correctIdVk, string message)
        {
            _contact.VKId = correctIdVk;
            Assert.AreEqual(correctIdVk, _contact.VKId, message);
        }

        //Тесты свойства DateOfBirth.
        /// <summary>
        /// Негативные тесты для сетера поля DateOfBirth: на проверку даты больше нынешней и меньше нынешней.
        /// </summary>
        /// <param name="wrongDateOfBirth"></param>
        /// <param name="message"></param>
        [TestCase("1899, 01, 01", "Должно возникать исключение, если дата dateOfBirth меньше, чем 1900,01,01",
            TestName = "Присвоение dateOfBirth меньшее, чем 1900,01,01")]
        [TestCase("3075, 01, 01", "Должно возникать исключение, если дата dateOfBirth больше нынешней",
            TestName = "Присвоение dateOfBirth большее, чем нынешняя даты")]
        public void TestDateOfBirthSet_ArgumentException(string wrongDateOfBirth, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.DateOfBirth = DateTime.Parse(wrongDateOfBirth); },
                message);
        }

        /// <summary>
        /// Положительный тест для сетера поля DateOfBirth: присвоение значения
        /// </summary>
        /// <param name="correctDateOfBirth"></param>
        /// <param name="message"></param>
        [TestCase("1975, 01, 01", "Тест не пройден, dateOfBirth присваивается неверное значение",
            TestName = "Присвоение правильного dateOfBirth")]
        public void TestDateOfBirthSet_CorrectArgument(string correctDateOfBirth, string message)
        {
            Assert.DoesNotThrow(
                () => { _contact.DateOfBirth = DateTime.Parse(correctDateOfBirth); },
                message);
        }

        /// <summary>
        /// Тест для геттера поля DateOfBirth
        /// </summary>
        /// <param name="correctDateOfBirth"></param>
        /// <param name="message"></param>
        [TestCase("1980, 01, 01", "Геттер dateOfBirth возвращает неверное значение",
            TestName = "Возвращение геттером dateOfBirth")]
        public void TestDateOfBirthGet_CorrectArgument(string correctDateOfBirth, string message)
        {
            _contact.DateOfBirth = DateTime.Parse(correctDateOfBirth);
            Assert.AreEqual(DateTime.Parse(correctDateOfBirth), _contact.DateOfBirth,
                message);
        }
    }
}
