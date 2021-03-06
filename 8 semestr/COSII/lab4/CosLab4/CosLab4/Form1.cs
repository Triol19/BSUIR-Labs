﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CosLab4
{
    public partial class Form1 : Form
    {
        Picture pict1;
        Picture pict2;
        Picture pict3;
        Picture pict4;
        Picture pict5;
        Picture pict6;
        Picture pict7;
        Picture pict8;
        Picture pict9;
        Picture pict10;
        RBF rbf;
        public Form1()
        {
            InitializeComponent();
            pict1 = new Picture(class1i1PictureBox, 7, 7);
            pict2 = new Picture(class1i2PictureBox, 7, 7);
            pict3 = new Picture(class1i3PictureBox, 7, 7);
            pict4 = new Picture(class2i1PictureBox, 7, 7);
            pict5 = new Picture(class2i2PictureBox, 7, 7);            
            pict6 = new Picture(class2i3PictureBox, 7, 7);
            pict7 = new Picture(class3i1PictureBox, 7, 7);
            pict8 = new Picture(class3i2PictureBox, 7, 7);
            pict9 = new Picture(class3i3PictureBox, 7, 7);
            pict10 = new Picture(endPictureBox, 7, 7);
            pict1.Clear(Color.White, Color.Black, Color.DarkGray);
            pict10.Clear(Color.White, Color.Black, Color.Blue);
            pict2.Clear(Color.White, Color.Black, Color.DarkGray);
            pict3.Clear(Color.White, Color.Black, Color.DarkGray);
            pict4.Clear(Color.White, Color.Black, Color.DarkGray);
            pict5.Clear(Color.White, Color.Black, Color.DarkGray);
            pict5.Clear(Color.White, Color.Black, Color.DarkGray);
            pict6.Clear(Color.White, Color.Black, Color.DarkGray);
            pict7.Clear(Color.White, Color.Black, Color.DarkGray);
            pict8.Clear(Color.White, Color.Black, Color.DarkGray);
            pict9.Clear(Color.White, Color.Black, Color.DarkGray);
            rbf = new RBF(3, 3, 625);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            pict1.Analiz_Mouse(e, Color.White, Color.Black);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pict1.Analiz_Mouse(e, Color.White, Color.Black);
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            pict2.Analiz_Mouse(e, Color.White, Color.Black);
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pict2.Analiz_Mouse(e, Color.White, Color.Black);
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            pict4.Analiz_Mouse(e, Color.White, Color.Black);
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            pict4.Analiz_Mouse(e, Color.White, Color.Black);
        }

        private void pictureBox4_MouseClick(object sender, MouseEventArgs e)
        {
            pict5.Analiz_Mouse(e, Color.White, Color.Black);
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            pict5.Analiz_Mouse(e, Color.White, Color.Black);
        }

        private void class1i3PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            pict3.Analiz_Mouse(e, Color.White, Color.Black);
        }

        private void class2i3PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            pict6.Analiz_Mouse(e, Color.White, Color.Black);
        }

        private void class3i1PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            pict7.Analiz_Mouse(e, Color.White, Color.Black);
        }

        private void class3i2PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            pict8.Analiz_Mouse(e, Color.White, Color.Black);
        }

        private void class3i3PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            pict9.Analiz_Mouse(e, Color.White, Color.Black);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] mas;
            mas = pict10.Analiz_Image(Color.White, Color.Black);
            double[] mas_d;
            mas_d = rbf.Analiz_Image(mas);
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;

            try
            {
                if (mas_d[0] != 0)
                {
                    progressBar1.Value = Math.Abs((int)(mas_d[0] * 100));
                    label3.Text = "Схожесть с первым классом: " + (Math.Abs((int)(mas_d[0] * 100))).ToString() + " %";
                }
                else
                {
                    progressBar1.Value = 0;
                    label3.Text = "Схожесть с первым классом: " + 0.ToString() + " %";
                }
            }
            catch (Exception)
            {
                progressBar1.Value = 100;
                label3.Text = "Схожесть с первым классом: " + (100).ToString() + " %";
            }
            progressBar2.Maximum = 100;
            progressBar2.Minimum = 0;
            try
            {
                if (mas_d[1] != 0)
                {
                    progressBar2.Value = Math.Abs((int)(mas_d[1] * 100));
                    label2.Text = "Схожесть со вторым классом: " + (Math.Abs((int)(mas_d[1] * 100))).ToString() + " %";
                }
                else
                {
                    progressBar2.Value = 0;
                    label2.Text = "Схожесть с вторым классом: " + 0.ToString() + " %";
                }
            }
            catch (Exception)
            {
                progressBar2.Value = 100;
                label2.Text = "Схожесть со вторым классом: " + (100).ToString() + " %";
            }
            progressBar3.Maximum = 100;
            progressBar3.Minimum = 0;
            try
            {
                if (mas_d[2] != 0)
                {
                    progressBar3.Value = Math.Abs((int)(mas_d[2] * 100));
                    label10.Text = "Схожесть с третьим классом: " + (Math.Abs((int)(mas_d[2] * 100))).ToString() + " %";
                }
                else
                {
                    progressBar3.Value = 0;
                    label10.Text = "Схожесть с третьим классом: " + 0.ToString() + " %";
                }
            }
            catch (Exception)
            {
                progressBar3.Value = 100;
                label10.Text = "Схожесть с третьим классом: " + (100).ToString() + " %";
            }
        }

        private void pictureBox5_MouseClick(object sender, MouseEventArgs e)
        {
            pict10.Analiz_Mouse(e, Color.White, Color.Black);
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            pict10.Analiz_Mouse(e, Color.White, Color.Black);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] m, mas;
            if (textBox1.Text != "")
            {
                int c = Convert.ToInt32(textBox1.Text);

                if (c > 100 || c < 0)
                {
                    c = 25;
                }

                mas = pict10.Analiz_Image(Color.White, Color.Black);

                Random random = new Random();
                var randomArray = Enumerable.Range(0, 625).OrderBy(t => random.Next()).Take(625 * c / 100).ToArray();

                for (int i = 0; i < (int)(625 * c / 100); i++)
                {
                    if (mas[randomArray[i]] == 0)
                        mas[randomArray[i]] = 1;
                    else
                        mas[randomArray[i]] = 0;
                }
                pict10.Mas_to_Image(mas, Color.Black, Color.White);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pict1.Clear(Color.White, Color.Black, Color.DarkGray);
            pict10.Clear(Color.White, Color.Black, Color.Blue);
            pict2.Clear(Color.White, Color.Black, Color.DarkGray);
            pict4.Clear(Color.White, Color.Black, Color.DarkGray);
            pict5.Clear(Color.White, Color.Black, Color.DarkGray);
            pict3.Clear(Color.White, Color.Black, Color.DarkGray);
            pict6.Clear(Color.White, Color.Black, Color.DarkGray);
            pict7.Clear(Color.White, Color.Black, Color.DarkGray);
            pict8.Clear(Color.White, Color.Black, Color.DarkGray);
            pict9.Clear(Color.White, Color.Black, Color.DarkGray);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int[] mas;            
            if (classRadioButton1.Checked == true)
            {
                if (imageRadioButton1.Checked == true)
                {
                    mas = pict1.Analiz_Image(Color.White, Color.Black);
                    pict10.Mas_to_Image(mas, Color.Black, Color.White);
                }
                if (imageRadioButton2.Checked == true)
                {
                    mas = pict2.Analiz_Image(Color.White, Color.Black);
                    pict10.Mas_to_Image(mas, Color.Black, Color.White);
                }
                if (imageRadioButton3.Checked == true)
                {
                    mas = pict3.Analiz_Image(Color.White, Color.Black);
                    pict10.Mas_to_Image(mas, Color.Black, Color.White);
                }
            }
            if (classRadioButton2.Checked == true)
            {
                if (imageRadioButton1.Checked == true)
                {
                    mas = pict4.Analiz_Image(Color.White, Color.Black);
                    pict10.Mas_to_Image(mas, Color.Black, Color.White);
                }
                if (imageRadioButton2.Checked == true)
                {
                    mas = pict5.Analiz_Image(Color.White, Color.Black);
                    pict10.Mas_to_Image(mas, Color.Black, Color.White);
                }
                if (imageRadioButton3.Checked == true)
                {
                    mas = pict6.Analiz_Image(Color.White, Color.Black);
                    pict10.Mas_to_Image(mas, Color.Black, Color.White);
                }
            }
            if (classRadioButton3.Checked == true)
            {
                if (imageRadioButton1.Checked == true)
                {
                    mas = pict7.Analiz_Image(Color.White, Color.Black);
                    pict10.Mas_to_Image(mas, Color.Black, Color.White);
                }
                if (imageRadioButton2.Checked == true)
                {
                    mas = pict8.Analiz_Image(Color.White, Color.Black);
                    pict10.Mas_to_Image(mas, Color.Black, Color.White);
                }
                if (imageRadioButton3.Checked == true)
                {
                    mas = pict9.Analiz_Image(Color.White, Color.Black);
                    pict10.Mas_to_Image(mas, Color.Black, Color.White);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rbf = new RBF(3, 3, 625);
            int [] mas1_1, mas1_2, mas1_3, mas2_1, mas2_2, mas2_3, mas3_1, mas3_2, mas3_3;
            mas1_1 = pict1.Analiz_Image(Color.White,Color.Black);
            mas1_2 = pict2.Analiz_Image(Color.White,Color.Black);
            mas1_3 = pict3.Analiz_Image(Color.White, Color.Black);
            mas2_1 = pict4.Analiz_Image(Color.White,Color.Black);
            mas2_2 = pict5.Analiz_Image(Color.White,Color.Black);
            mas2_3 = pict6.Analiz_Image(Color.White, Color.Black);
            mas3_1 = pict7.Analiz_Image(Color.White, Color.Black);
            mas3_2 = pict8.Analiz_Image(Color.White, Color.Black);
            mas3_3 = pict9.Analiz_Image(Color.White, Color.Black);

            double error, speed;
            double.TryParse(textBox2.Text, out error);
            double.TryParse(textBox3.Text, out speed);
            int i = rbf.Analiz(mas1_1, mas1_2, mas1_3 ,mas2_1, mas2_2, mas2_3, mas3_1, mas3_2, mas3_3, error, speed);
            numberOfStepsLabel.Text = "Количество шагов обучения: " + i.ToString();

        }

        private void Read_to_mas(string filename)
        {
            int pixels = 625;
            Int32[] mas = new int[pixels];


            System.IO.StreamReader reader = new System.IO.StreamReader(filename);
            for (int i = 0; i < pixels; i++)
                mas[i] = Convert.ToInt32(reader.ReadLine());
            pict1.Mas_to_Image(mas, Color.Black, Color.White);
            for (int i = 0; i < pixels; i++)
                mas[i] = Convert.ToInt32(reader.ReadLine());
            pict2.Mas_to_Image(mas, Color.Black, Color.White);
            for (int i = 0; i < pixels; i++)
                mas[i] = Convert.ToInt32(reader.ReadLine());
            pict3.Mas_to_Image(mas, Color.Black, Color.White);
            for (int i = 0; i < pixels; i++)
                mas[i] = Convert.ToInt32(reader.ReadLine());
            pict4.Mas_to_Image(mas, Color.Black, Color.White);
            for (int i = 0; i < pixels; i++)
                mas[i] = Convert.ToInt32(reader.ReadLine());
            pict5.Mas_to_Image(mas, Color.Black, Color.White);
            for (int i = 0; i < pixels; i++)
                mas[i] = Convert.ToInt32(reader.ReadLine());
            pict6.Mas_to_Image(mas, Color.Black, Color.White);
            for (int i = 0; i < pixels; i++)
                mas[i] = Convert.ToInt32(reader.ReadLine());
            pict7.Mas_to_Image(mas, Color.Black, Color.White);
            for (int i = 0; i < pixels; i++)
                mas[i] = Convert.ToInt32(reader.ReadLine());
            pict8.Mas_to_Image(mas, Color.Black, Color.White);
            for (int i = 0; i < pixels; i++)
                mas[i] = Convert.ToInt32(reader.ReadLine());
            pict9.Mas_to_Image(mas, Color.Black, Color.White);
            reader.Close();
        }

        private void loadLettersButton_Click(object sender, EventArgs e)
        {
            button4_Click(sender, e);
            
            rbf = null;
            OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();
            if (fd.FileName != "")
            {
                Read_to_mas(fd.FileName);
            }

            this.button1_Click(sender, e);
        }

        private void saveLetter_Click(object sender, EventArgs e)
        {
            int size = 25;
            int pixels = size * size;
            Int32[] mas = new int[pixels];
            System.IO.StreamWriter writer = new System.IO.StreamWriter("letters.txt");

            pict1.Read_Image_to_mas(size, mas);
            for (int i = 0; i < pixels; i++)
                writer.WriteLine(mas[i]);
            pict2.Read_Image_to_mas(size, mas);
            for (int i = 0; i < pixels; i++)
                writer.WriteLine(mas[i]);
            pict3.Read_Image_to_mas(size, mas);
            for (int i = 0; i < pixels; i++)
                writer.WriteLine(mas[i]);
            pict4.Read_Image_to_mas(size, mas);
            for (int i = 0; i < pixels; i++)
                writer.WriteLine(mas[i]);
            pict5.Read_Image_to_mas(size, mas);
            for (int i = 0; i < pixels; i++)
                writer.WriteLine(mas[i]);
            pict6.Read_Image_to_mas(size, mas);
            for (int i = 0; i < pixels; i++)
                writer.WriteLine(mas[i]);
            pict7.Read_Image_to_mas(size, mas);
            for (int i = 0; i < pixels; i++)
                writer.WriteLine(mas[i]);
            pict8.Read_Image_to_mas(size, mas);
            for (int i = 0; i < pixels; i++)
                writer.WriteLine(mas[i]);
            pict9.Read_Image_to_mas(size, mas);
            for (int i = 0; i < pixels; i++)
                writer.WriteLine(mas[i]);
            writer.Close();
        }

        

    }
}
