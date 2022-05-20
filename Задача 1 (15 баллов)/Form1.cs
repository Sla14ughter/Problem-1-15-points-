using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Задача_1__15_баллов_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
        }

        string filename;

        private void button2_Click(object sender, EventArgs e)
        {
            List<int[]> pines = new List<int[]>(); // Двумерные массивы для лохов. Создаём список.
            StreamReader streamreader = new StreamReader(filename); // Открываем поток.
            streamreader.ReadLine(); // Да, я в курсе, что первое число нужно для указания размера массива, но у меня-то СПИСОК! Поэтому его я пропускаю.
            while(streamreader.EndOfStream == false)
            {
                string[] rowspot = streamreader.ReadLine().Split(' '); // Сразу же считываем строку и делим её на 2 числа: ряд и место
                pines.Add(new int[2] { int.Parse(rowspot[0]), int.Parse(rowspot[1]) }); // Добавляем числа в список
            } // Повторяем, пока не закончатся данные.
            streamreader.Close(); // Не забываем закрыть поток
            PineComparer sort = new PineComparer(); // У меня тут описано, как сортировать сосны 
            pines.Sort(sort); // Сортируем
            int index = 0; // Это инструмент-сюрприз, который поможет нам позже.
            for (int i = 0; i < pines.Count() - 1; i++)
            {
                if (pines[i][0] == pines[i + 1][0] & pines[i][1] + 14 == pines[i + 1][1])
// Перевожу на русский: если ряд сосны равен ряду следующей сосны и между соснами 13 мест + одно, которое занимает следующая сосна
                {
                    index = i; //достаём нужную сосну с помощью переменной
                    break; // Сразу как нашли, выходим из цикла
                }
            }
            // Показываем месседжбокс
            MessageBox.Show($"Ряд №{pines[index][0]} соответствует данному условию. " +
                $"Подходящие под условие места для посадки начинаются с номера {pines[index][1] + 1}.", "Ответ");
        }

        private void button1_Click(object sender, EventArgs e) // Тут чисто выбор файла пользователем и занесение его в поле filename.
                                                               // И разблокирование основной кнопки
                                                               // Ничего особо интересного
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                button2.Enabled = true;
                label1.Text = $"Файл: {filename}";
            }
        }
    }
}
