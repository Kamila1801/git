using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        // закрытое поле, которое хранит объект модели 
        // для использования данных о пользователях в методах класса
        Model1 db = new Model1();
        private void button2_Click(object sender, EventArgs e)
        {
            // форму регистрации закрываем
            this.Close();
            // показываем скрытую форму Form1
            Form1.FORMA.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // проверяем, что во все текстовые поля введены данные
            if (textBox1.Text == "" || textBox2.Text == "" ||
              textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Нужно задать все данные!");
                return;
            }
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Значения паролей не совпадают!");
                return;
            }
            if ((textBox4.Text != "Директор") && (textBox4.Text != "Бухгалтер") 
                                        && (textBox4.Text != "Заказчик"))
  {
                MessageBox.Show("Задана неверная роль!");
                return;
            }

            // ищем запись пользователя с введенным логином
            users usr = db.users.Find(textBox1.Text);
            // если такой пользователь есть и его пароль правильный
            if (usr != null)
            {
                MessageBox.Show("Пользователь с таким логином уже есть!");
                return;
            }
            // создаем объект Users для нового пользователя
            usr = new users();
            usr.login = textBox1.Text;
            usr.psw = textBox2.Text;
            usr.role = textBox3.Text;
            usr.name = textBox5.Text;
            // добавляем новый объект в коллекцию объектов Users
            db.users.Add(usr);
            try
            {
                // сохраняем нового пользователя в базе данных
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("Пользователь " + usr.login + "зарегистрирован!");
            Form1.FORMA.Show();
            this.Close();
            return;

        }
    }
}
