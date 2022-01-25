using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactApp;

namespace ContactsAppUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Создаем список контактов.
        /// </summary>
        private Project _project;

        /// <summary>
        /// Контакты, которые находятся в listbox
        /// </summary>
        private List<Contact> formlist = new List<Contact>();

        /// <summary>
        /// Путь к файлу.
        /// </summary>
        private readonly string _filePath = ProjectManager.FilePath();

        /// <summary>
        /// Путь к папке.
        /// </summary>
        private readonly string _directoryPath = ProjectManager.DirectoryPath();

        public MainForm()
        {
            InitializeComponent();

            //Выполняем десериализацию.
            ProjectManager.LoadFromFile(_filePath);
        }

        /// <summary>
        /// Функция добавления контакта.
        /// </summary>
        private void AddContact()
        {
            ContactForm editForm = new ContactForm();
            DialogResult result = editForm.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                editForm.Close();
            }
            else if (result == DialogResult.OK)
            {
                formlist.Add(editForm._current);
                editForm.Close();
                _project._contactsList = _project.FindContacts(FindTextBox.Text);
                
            }
            _project._contactsList = _project.Sort(_project._contactsList);
            RefreshContactsList(null);
            ProjectManager.SaveToFile(_project, _filePath, _directoryPath);
        }

        /// <summary>
        /// Функция, для обновления ContactList
        /// </summary>
        /// <param name="contact"></param>
        private void RefreshContactsList(Contact contact)
        {
            formlist = _project.FindContacts(FindTextBox.Text);
            var index = formlist.FindIndex(x => x == contact);
            ContactsListBox.Items.Clear();
            foreach (var t in formlist)
            {
                ContactsListBox.Items.Add(t.Surname);
            }

            if (index == -1 && ContactsListBox.Items.Count != 0)
            {
                index = 0;
            }

            ContactsListBox.SelectedIndex = index;
            if (index == -1)
            {
                ClearContactInfo();
            }
        }

        /// <summary>
        /// Функция для очистки информации о контакте 
        /// </summary>
        private void ClearContactInfo()
        {
            NameTextBox.Text = "";
            SurnameTextBox.Text = "";
            BirthdayDateTimePicker.Text = "";
            PhoneTextBox.Text = "";
            EmailTextBox.Text = "";
            VkTextBox.Text = "";
        }

        /// <summary>
        /// Функция удаления контакта.
        /// </summary>
        private void RemoveContact()
        {
            var index = ContactsListBox.SelectedIndex;

            if (index == -1)
            {
                MessageBox.Show("Select the entry to delete.", "Remove");
            }

            //Если список не пуст.
            if (_project._contactsList.Count > 0)
            {
                if (index >= 0)
                {
                    string removeThisContact =
                        "Do you really want to remove this contact: " + SurnameTextBox.Text + "?";

                    var result = MessageBox.Show(removeThisContact, "Remove", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        _project._contactsList.RemoveAt(index);
                        ContactsListBox.Items.RemoveAt(index);
                        ProjectManager.SaveToFile(_project, _filePath, _directoryPath);
                    }
                }
            }
        }

        /// <summary>
        /// Функция, выполняющая редактирование данных.
        /// </summary>
        private void EditContact()
        {
            ContactForm contactForm = new ContactForm();
            contactForm._current = formlist[ContactsListBox.SelectedIndex];
            DialogResult result = contactForm.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                contactForm.Close();
            }
            else if (result == DialogResult.OK)
            {
                formlist[ContactsListBox.SelectedIndex] = contactForm._current;
                contactForm.Close();
            }
            _project._contactsList = _project.Sort(_project._contactsList);
            RefreshContactsList(contactForm.Contact);
            ProjectManager.SaveToFile(_project, _filePath, _directoryPath);
        }

        /// <summary>
        /// Вызывает функцию для добавления контакта.
        /// </summary>
        private void AddContactButton_Click_1(object sender, EventArgs e)
        {
            AddContact();
        }

        /// <summary>
        /// Вызывает функцию для редактирования.
        /// </summary>
        private void EditContactButton_Click_1(object sender, EventArgs e)
        {
            EditContact();
        }

        /// <summary>
        /// Вызывает функцию для удаления контакта.
        /// </summary>
        private void RemoveContactButton_Click_1(object sender, EventArgs e)
        {
            RemoveContact();
        }

        /// <summary>
        /// Вывод данных контакта на главную форму.
        /// </summary>
        private void OutputContacts(IReadOnlyList<Contact> contacts)
        {
            if (formlist.Count != 0)
            {
                var index = ContactsListBox.SelectedIndex;
                //присвоить в selectedContact последний выбранный индекс элемента, если он не равен -1
                Contact selectedContact = index == -1 ? formlist.Last() : formlist[index];
                NameTextBox.Text = selectedContact.Name;
                SurnameTextBox.Text = selectedContact.Surname;
                BirthdayDateTimePicker.Text = selectedContact.DateOfBirth.ToString();
                EmailTextBox.Text = selectedContact.Email;
                VkTextBox.Text = selectedContact.VKId;
                PhoneTextBox.Text = selectedContact.phoneNumber.Number.ToString();
            }
            else
            {
                ClearContactInfo();
            }
        }

        /// <summary>
        /// Переключение между контактами списка и вывод выбранного контакта.
        /// </summary>
        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OutputContacts(_project.FindContacts(FindTextBox.Text));
        }

        /// <summary>
        /// Добавление контакта по клику в выпадающем сверху меню из Edit.
        /// </summary>
        private void AddContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        /// <summary>
        /// Выпадение формы About, при клике в верхнем меню на About.
        /// </summary>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newForm = new AboutForm();
            newForm.Show();
        }

        /// <summary>
        /// Редактирование контакта по клику в выпадающем сверху меню из Edit.
        /// </summary>
        private void EditContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        /// <summary>
        /// Удаление контакта по клику в выпадающем сверху меню из Edit.
        /// </summary>
        private void RemoveContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveContact();
        }

        /// <summary>
        /// Закрывает главное окно по клику в выпадающем сверху меню на Exit.
        /// </summary>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Функция поиска подстроки.
        /// </summary>
        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ContactsListBox.SelectedIndex >= 0)
            {
                var selectedContact = formlist[ContactsListBox.SelectedIndex];
                RefreshContactsList(selectedContact);
            }

            else
            {
                RefreshContactsList(null);
            }
        }

        /// <summary>
        /// Удаление контакта по нажатию клавиши Delete.
        /// </summary>
        private void ContactsListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveContact();
            }
        }

        /// <summary>
        /// Функция загрузки главной формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            _project = ProjectManager.LoadFromFile(_filePath);
            if (_project._contactsList.Count == 0)
            {
                return;
            }

            formlist = _project._contactsList;
            RefreshContactsList(null);
            CheckBirthday();
            ProjectManager.SaveToFile(_project, _filePath, _directoryPath);
        }


        /// <summary>
        /// Функция на проверку наличия именинника.
        /// </summary>
        private void CheckBirthday()
        {
            var birthdayMen = _project.BirthdayMan(DateTime.Today);
            var labelText = "";
            if (birthdayMen.Count != 0)
            {
                labelText = @"Today marks the birthday:  " + "\r\n";
                foreach (var birthdayBoy in birthdayMen)
                {
                    labelText += $@"{birthdayBoy.Name} {birthdayBoy.Surname} " + "\r\n";
                }
            }
            else
            {
                labelText = @"There are no birthday people today.";
            }

            BirthdayLabel.Text = labelText;
        }
    }


}
