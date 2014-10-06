using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Windows.Forms;
using System.Timers;

namespace Twisterbot
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Создание объекта класса Google
        /// </summary>
        Google g = new Google(); // создание объекта класса Google

        public Form1()
        {
            InitializeComponent();
            Data.EventHandler = new Data.MyEvent(ChangePic); // вызов метода ChangePic для смены изображения по событию
        }

        /// <summary>
        /// При запуске приложения устанавливает фоновое изображение, скрывает некоторые объекты до начала игры и устанавливает начальные значения
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.Twister; // установка фонового изображения
            закончитьИгруToolStripMenuItem.Enabled = false;
            pictureBox2.Hide();
            pictureBox3.Hide();
            pictureBox4.Hide();

            // установка значений по умолчанию
            NumberOfPlayers.Value = 4;
            PauseTime.Seconds = 7;
            StartTime.Secs = 10;

            string txt = "Внимание!! Игра со звуком!!\nПодключите колонки или наушники перед запуском!";
            richTextBox1.Text = "Внимание!! Игра со звуком!!\nПодключите колонки или наушники перед запуском!";
            richTextBox1.Select(richTextBox1.Text.IndexOf(txt), txt.Length);
            richTextBox1.SelectionColor = Color.Red;
        }

        /// <summary>
        /// Запуск игры, отображение и скрытие некоторых функций управления
        /// </summary>
        private void начатьИгруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Hide();
            закончитьИгруToolStripMenuItem.Enabled = true;
            pictureBox1.Hide();
            pictureBox2.Show();
            pictureBox3.Show();
            pictureBox4.Show();
            выходToolStripMenuItem.Enabled = false;
            начатьИгруToolStripMenuItem.Enabled = false;
            настройкиToolStripMenuItem.Enabled = false;
            g.Starting(); // запуск игры
        }

        /// <summary>
        /// Меняет изображение на pictureBox
        /// </summary>
        void ChangePic(Image path, int n)
        {
            switch (n) // функция switch улавливает, какой pictureBox надо изменить
            {
                case 1:
                    pictureBox2.Image = path; // изменяет картинку в pictureBox2
                    break;
                case 2:
                    pictureBox3.Image = path;
                    break;
                case 3:
                    pictureBox4.Image = path;
                    break;
                case 4:
                    pictureBox2.BackgroundImage = path;
                    pictureBox3.BackgroundImage = path;
                    pictureBox4.BackgroundImage = path; // изменяет цвет фона 
                    break;
                default:
                    MessageBox.Show("Что-то пошло не так...");
                    break;
            }
        }


        /// <summary>
        /// Открытие формы Form2
        /// </summary>
        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        /// <summary>
        /// Остановка всех звуков и проигрывание звуковой дорожки, извещающей о конце игры
        /// </summary>
        private void закончитьИгруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.StopSound();
            System.Timers.Timer time1 = new System.Timers.Timer();
            SoundPlayer sq = new SoundPlayer(@"Audio/End.wav");
            sq.Play();
            time1.Elapsed += new ElapsedEventHandler(Ending);
            time1.Interval = 1500;
            time1.AutoReset = false;
            time1.Start();
        }

        /// <summary>
        /// Перезапускает приложение и фокусирует на него после перезапуска
        /// </summary>
        public void Ending(object source, ElapsedEventArgs e)
        {
            Application.Restart();
            try
            {
                Form1.ActiveForm.Focus();
            }
            catch { }
        }


        /// <summary>
        /// Закрытие формы при нажатии на кнопку Выход
        /// </summary>
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Открытие формы Form3
        /// </summary>
        private void правилаИгрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        /// <summary>
        /// Открытие формы Form4
        /// </summary>
        private void обАвтореToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }
    }
}
