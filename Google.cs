using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Timers;
using System.Windows.Forms;
using System.Drawing;

namespace Twisterbot
{
    class Google
    {
        /// <summary>
        /// Булевая переменная, отвечающая за продолжение воспроизведения
        /// </summary>
        bool cont = false;
        /// <summary>
        /// Массив с адресами звуковых дорожек с конечностями
        /// </summary>
        public string[] konech = {  @"Audio\Hand.wav",  @"Audio\Leg.wav" };
        /// <summary>
        /// Массив с адресами картинок конечностей из файла ресурсов
        /// </summary>
        public Image[] konechPic = { Properties.Resources.handp, Properties.Resources.legp };
        /// <summary>
        /// Массив с адресами звуковых дорожек с направлениями
        /// </summary>
        public string[] LR = {  @"Audio\Left.wav",  @"Audio\Right.wav" };
        /// <summary>
        /// Массив с адресами картинок направления из файла ресурсов
        /// </summary>
        public Image[] LRPic = { Properties.Resources.leftp, Properties.Resources.rightp};
        /// <summary>
        /// Массив с адресами звуковых дорожек с цветами
        /// </summary>
        public string[] color = {  @"Audio\Blue.wav",  @"Audio\Yellow.wav",  @"Audio\Red.wav",  @"Audio\Green.wav" };
        /// <summary>
        /// Массив с адресами картинок цветов из файла ресурсов
        /// </summary>
        public Image[] colorPic = { Properties.Resources.bluep, Properties.Resources.yellowp, Properties.Resources.redp, Properties.Resources.greenp };
        /// <summary>
        /// Массив с адресами звуковых дорожек с номерами игроков
        /// </summary>
        public string[] number = {  @"Audio\1st.wav",  @"Audio\2nd.wav",  @"Audio\3rd.wav",  @"Audio\4th.wav" };
        /// <summary>
        /// Массив с адресами картинок номеров игроков из файла ресурсов
        /// </summary>
        public Image[] numberPic = { Properties.Resources._1p, Properties.Resources._2p, Properties.Resources._3p, Properties.Resources._4p };
        /// <summary>
        /// Объект музыкального плеера
        /// </summary>
        SoundPlayer sp1 = new SoundPlayer();
        /// <summary>
        /// Счётчик для соблюдения порядка ходов игроков
        /// </summary>
        int i = 0;

        /// <summary>
        /// Состояние объекта, в котором происходит запуск звуковой дорожки, извещающей о начале игры
        /// </summary>
        public void Starting()
        {
                System.Timers.Timer time1 = new System.Timers.Timer(); // создания объекта класса Timer
                cont = true; // установка разрешения на воспроизведение звуков(нужно если игра запускается во второй раз)
                i = 0; // обнуление счетчика номера текущего игрока
                sp1.SoundLocation =  @"Audio\Start.wav"; // адрес звуковой дорожки
                sp1.Play(); // запуск звуковой дорожки
                time1.Elapsed += new ElapsedEventHandler(PlayNumber); //переход к методу PlayNumber по истечению времени
                time1.Interval = StartTime.Secs*1000; // время ожидания
                time1.AutoReset = false; // запрет действия таймера несколько раз
                time1.Start(); // запуск таймера
        }

        /// <summary>
        /// Состояние объекта, в котором происходит запуск звуковой дорожки с номером текущего игрока и установка картинки с номером игрока на Form1
        /// </summary>
        public void PlayNumber(object source, ElapsedEventArgs e)
        {
            if (cont) // если воспроизведение разрешено
            {
                System.Timers.Timer time1 = new System.Timers.Timer();
                sp1.SoundLocation = number[i];
                sp1.Play();
                Data.EventHandler(numberPic[i], 1); // вызов события Data и передача данных о номере игрока на Form1
                i++; // увеличение счётчика номера игрока
                time1.Elapsed += new ElapsedEventHandler(PlayLR);
                time1.Interval = 1500;
                time1.AutoReset = false;
                time1.Start();
            }
        }
        /// <summary>
        /// Состояние объекта, в котором происходит запуск звуковой дорожки с направлением, которое определяется случайно из массива, индекс которого создаётся с помощью Random, и установка картинки на Form1
        /// </summary>
        public void PlayLR(object source, ElapsedEventArgs e)
        {
            if (cont)
            {
                System.Timers.Timer time1 = new System.Timers.Timer();
                Random g = new Random();
                int rn = g.Next(0, 2); // генерация случайного числа 0 или 1, которое будет использовано как индекс массива
                sp1.SoundLocation = LR[rn];
                Data.EventHandler(LRPic[rn], 2); // вызов события Data и передача данных о выбранном Random направлении на Form1
                sp1.Play();
                time1.Elapsed += new ElapsedEventHandler(PlayKonech);
                time1.Interval = 800;
                time1.AutoReset = false;
                time1.Start();
            }

        }
        /// <summary>
        /// Состояние объекта, в котором происходит запуск звуковой дорожки с конечностью, которая определяется случайно из массива, индекс которого создаётся с помощью Random, и установка картинки с этой конечностью на Form1
        /// </summary>
        public void PlayKonech(object source, ElapsedEventArgs e)
        {
            if (cont)
            {
                System.Timers.Timer time1 = new System.Timers.Timer();
                Random t = new Random();
                int rn = t.Next(0, 2);
                sp1.SoundLocation = konech[rn];
                Data.EventHandler(konechPic[rn], 3); // вызов события Data и передача данных о выбранной Random конечности на Form1
                sp1.Play();
                time1.Elapsed += new ElapsedEventHandler(PlayColor);
                time1.Interval = 800;
                time1.AutoReset = false;
                time1.Start();
            }

        }
        /// <summary>
        /// Состояние объекта, в котором происходит запуск звуковой дорожки с цветом из массива, индекс которого создаётся с помощью Random, и установка цвета фона Form1
        /// </summary>
        public void PlayColor(object source, ElapsedEventArgs e)
        {
            if (cont)
            {
                System.Timers.Timer time1 = new System.Timers.Timer();
                Random c = new Random();
                int rn = c.Next(0, 4);
                sp1.SoundLocation = color[rn];
                Data.EventHandler(colorPic[rn], 4); // вызов события Data и передача данных о выбранном Random цвета на Form1
                sp1.Play();
                if (i == NumberOfPlayers.Value)
                {
                    i = 0; // если игрок последний - счётчик обнуляется и начинается снова с первого
                }
                time1.Elapsed += new ElapsedEventHandler(PlayNumber);
                time1.Interval = PauseTime.Seconds*1000;
                time1.AutoReset = false;
                time1.Start();
            }

        }

        /// <summary>
        /// Прерывает все звуковые дорожки
        /// </summary>
        public void StopSound()
        {
        cont = false;
        }     
    }
}
