using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Twisterbot
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // установка значений текстовых полей по умолчанию
            textBox1.Text = "4";
            textBox2.Text = "7";
            textBox3.Text = "10";
        }

        /// <summary>
        /// Проверяет условия и сохраняет настройки
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            int c = 0; // переменная для проверки соответствия настроек требованиям
            try
            {
                if (Convert.ToInt32(textBox1.Text) > 0 && Convert.ToInt32(textBox1.Text) < 5)
                {
                    NumberOfPlayers.Value = Convert.ToInt32(textBox1.Text);
                }
                else
                {
                    MessageBox.Show("Число игроков может быть от 1 до 4-ёх!");
                    c++;
                }
            }
            catch { MessageBox.Show("Введите корректное число игроков!"); }

            try
            {
                if (Convert.ToInt32(textBox2.Text) > 2 && Convert.ToInt32(textBox2.Text) < 100)
                {
                    PauseTime.Seconds = Convert.ToInt32(textBox2.Text);
                }
                else
                {
                    MessageBox.Show("Пауза может быть равной от 3 до 99 секунд!");
                    c++;
                }
            }
            catch { MessageBox.Show("Введите корректное число секунд паузы между ходами!"); }

            try
            {
                if (Convert.ToInt32(textBox3.Text) > 3 && Convert.ToInt32(textBox3.Text) < 100)
                {
                    StartTime.Secs = Convert.ToInt32(textBox3.Text);
                }
                else
                {
                    MessageBox.Show("Время перед началом может быть от 4 до 99 секунд!"); 
                    c++;
                }
            }
            catch { MessageBox.Show("Введите корректное число секунд перед началом!"); }
            
            if (c == 0) Close(); // если нет ошибок - закрыть Form2
        }

        /// <summary>
        /// Закрывает Form2
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
