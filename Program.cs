using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace Twisterbot
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    public static class Data
    {
        // Создание события для передачи данных из класса Google в класс Form1
        public delegate void MyEvent(Image data, int k);
        public static MyEvent EventHandler;
    }
    static class NumberOfPlayers
    {
        /// <summary>
        /// Свойство с количеством игроков
        /// </summary>
        public static int Value { get; set; }
    }
    static class PauseTime
    {
        /// <summary>
        /// Свойство с числом секунд между ходами
        /// </summary>
        public static int Seconds { get; set; }
    }
    static class StartTime
    {
        /// <summary>
        /// Свойство с количеством секунд до начала игры
        /// </summary>
        public static int Secs { get; set; }
    }
}
