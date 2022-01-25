using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ContactApp.UnitTest
{
    class ProjectTest
    {
        [Test]
        public void Test_Project_CreateProject()
        {
            //Setup
            var sourceNumber = 74182963012;
            var phoneNumber = new PhoneNumber
            {
                Number = sourceNumber
            };

            var contact = new Contact
            {
                Name = "Bublik",
                Surname = "Bublikins",
                DateOfBirth = new DateTime(2005, 7, 20),
                Email = "dfghjkhb@df",
                VKId = "84949",
                phoneNumber = phoneNumber
            };

            var sourceProject = new Project();

            //Act
            sourceProject._contactsList.Add(contact);

            //Assert
            Assert.IsNotNull(sourceProject);
        }
    }
}
