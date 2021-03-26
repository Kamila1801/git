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
    
    public partial class Form1 : Form
    {
        // открытое статическое свойство для хранения объект Form1
        // используется для возврата к этой форме из других форм
        public static Form1 FORMA
        {
            get; set;
        }
        public Form1()
        {
            InitializeComponent();
        }
        // метод показа формы Регистрации
        private void button3_Click(object sender, EventArgs e)
        {
            // закрываем первую форму и заканчиваем работу программы
            this.Close();
            // или можно по другому
            // Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // создаем форму регистрации Form2 
            Form2 f = new Form2();
            // сохраняем ссылку на текущую форму – Form1
            FORMA = this;
            // текущую форму прячем 
            this.Hide();
            f.Show();
        }
    }
}
