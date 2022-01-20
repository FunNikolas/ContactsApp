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
        /// <summary>
        /// Лист, который хранит в себе список контактов.
        /// </summary>
        public List<Contact> contactsList = new List<Contact>();
        public Contact _contacts { get; set; } = new Contact();


    }
}
