using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosLab2
{
    public partial class Form1 : Form
    {
        Bitmap bp1,bp2,bp3,bp4,bp5;
        int[] mas1,mas2,mas3,mas4;
        int[,] mas_koeff;
        public Form1()
        {
            InitializeComponent();
            bp1 = new Bitmap(326, 326);
            bp2 = new Bitmap(326, 326);
            bp3 = new Bitmap(326, 326);
            bp4 = new Bitmap(326, 326);
            bp5 = new Bitmap(326, 326);
           
            Clear_All();
            mas1 = new int[625];
            mas2 = new int[625];
            mas3 = new int[625];
            mas4 = new int[625];
            mas_koeff = new int[625, 625];
            for (int i = 0; i < 625; i++)
               {
                    mas1[i] = 1;
                    mas2[i] = 1;
                    mas3[i] = 1;
                    mas4[i] = 1;
                }
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            Analiz(e, bp1);
            firstLetterPictureBox.Image = bp1;
        }
        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            Analiz(e, bp2);
            secondLetterPictureBox.Image = bp2;    
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            Analiz(e, bp3);
            thirdLetterPictureBox.Image = bp3;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                Analiz(e, bp1);
                firstLetterPictureBox.Image = bp1;
            }

        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                Analiz(e, bp2);
                secondLetterPictureBox.Image = bp2;
            }
        }
        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                Analiz(e, bp3);
                thirdLetterPictureBox.Image = bp3;
            }
        }
        private void Analiz(MouseEventArgs e, Bitmap b)
        {
            if (e.Button == MouseButtons.Left)
                SetPixel(b, ((int)(e.X / 13)), ((int)(e.Y / 13)), Color.Black);
            if (e.Button == MouseButtons.Right)
                SetPixel(b,((int)(e.X / 13)) , ((int)(e.Y / 13) ) , Color.White);
        }
        private void SetPixel(Bitmap b, int x, int y, Color c)
        {
            if (x < 25 && y < 25 && x >= 0 && y >= 0)
                for (int i = 1; i < 13; i++)
                {
                    for (int j = 1; j < 13; j++)
                    {
                        b.SetPixel((x * 13) + i, (y * 13) + j, c);
                    }
                }
        }
        private Color GetPixel(Bitmap b, int x, int y)
        {
            return b.GetPixel(x * 13 + 1, y * 13 + 1);
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Read_Image_to_mas(bp1, 625, mas1);
                Mas_to_Image(bp4, mas1, 625);
            }
            beforePictureBox.Image = bp4;

            noiseButton.Enabled = true;
            differenceButton.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                Read_Image_to_mas(bp2, 625, mas2);
                Mas_to_Image(bp4, mas2, 625);
            }
            beforePictureBox.Image = bp4;

            noiseButton.Enabled = true;
            differenceButton.Enabled = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                Read_Image_to_mas(bp3, 625, mas3);
                Mas_to_Image(bp4, mas3, 625);
            }
            beforePictureBox.Image = bp4;

            noiseButton.Enabled = true;
            differenceButton.Enabled = true;
        }

        private void Clear(Bitmap b, int n, int m)
        {
            Color c;
            for (int i = 0; i < n ; i++)
                for (int j = 0; j < m; j++)
                {
                    c = GetPixel(b, i, j);
                    if (c.A == Color.Black.A && c.B == Color.Black.B && c.R == Color.Black.R && c.G == Color.Black.G)
                        SetPixel(b, i, j, Color.White);
                }
                    for (int i = 0; i <= n; i++)
                    {
                        for (int j = 0; j <= m * 13; j++)
                            b.SetPixel(i * 13, j, Color.Black);
                        for (int j = 0; j <= m * 13; j++)
                            b.SetPixel(j, i * 13, Color.Black);
                    }
        }

        private void Clear_All()
        {
            Clear(bp1, 25, 25);
            Clear(bp2, 25, 25);
            Clear(bp3, 25, 25);
            Clear(bp4, 25, 25);
            Clear(bp5, 25, 25);
            
            firstLetterPictureBox.BackColor = Color.White;
            secondLetterPictureBox.BackColor = Color.White;
            thirdLetterPictureBox.BackColor = Color.White;
            beforePictureBox.BackColor = Color.White;
            afterPictureBox.BackColor = Color.White;
            firstLetterPictureBox.Image = bp1;
            secondLetterPictureBox.Image = bp2;
            thirdLetterPictureBox.Image = bp3;
            beforePictureBox.Image = bp4;
            afterPictureBox.Image = bp5;
        }

        private void clearAllButton_Click(object sender, EventArgs e)
        {
            Clear_All();
            for (int i = 0; i < mas4.Length; i++)
                mas4[i] = 0;
        }
        private void teachButton_Click(object sender, EventArgs e)
        {
            Read_Image_to_mas(bp1, 25, mas1);
            Read_Image_to_mas(bp2, 25, mas2);
            Read_Image_to_mas(bp3, 25, mas3);
            Form_koeff();
        }

        private void Form_koeff()
        {
            for (int i = 0; i < 625; i++)
            {
                for (int j = 0; j < 625; j++)
                {
                    if (i == j)
                    {
                        mas_koeff[i, j] = 0;
                        
                    }
                    else
                    {
                        mas_koeff[i, j] = mas1[i] * mas1[j] + mas2[i] * mas2[j] + mas3[i] * mas3[j];
                    }
                }
            }
        }
        private void Mas_to_Image(Bitmap b, int[] mas, int n)
        {
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                if (k >= 25)
                    k = 0;
                if (mas[i] == -1)
                {
                    SetPixel(b,k,(int)(i / 25), Color.Black);
                    k++;
                }
                if (mas[i] == 1)
                {
                    SetPixel(b, k, (int)(i / 25), Color.White);
                    k++;
                }
            }
        }

        private void Read_Image_to_mas(Bitmap b, int n,int[] mas)
        {
            Color c;
            int k = 0;
            for (int i = 0; i < 25 ; i++)
                for (int j = 0; j < 25; j++)
                {
                    c = GetPixel(b, j, i);
                    if (c.A == Color.Black.A && c.B == Color.Black.B && c.R == Color.Black.R && c.G == Color.Black.G)
                        mas[k] = -1;
                    if (c.A == Color.White.A && c.B == Color.White.B && c.R == Color.White.R && c.G == Color.White.G)
                        mas[k] = 1;
                    k++;
                }
        }
        private void differenceButton_Click(object sender, EventArgs e)
        {
            Read_Image_to_mas(bp4, 25, mas4);

            int[] mas = Pow(mas_koeff, mas4, 625);

            Mas_to_Image(bp5, mas, 625);
            afterPictureBox.Image = bp5;
        }
        private int[] Pow(int[,] koeff, int[] before, int N)
        {
            int[] mas = new int[N];
            for (int j=0; j < N; j++)
                mas[j] = 0;
            Random r = new Random();
            int count = 0;

            while (count < N*N)
            {
                int i = r.Next(0, N);//for (int i = 0; i < N; i++){
                //{
                for (int j = 0; j < N; j++)
                {
                    mas[i] += koeff[i, j] * before[j];
                }
                mas[i] = Func(mas[i]);
                if (mas.SequenceEqual(mas1) || mas.SequenceEqual(mas2) || mas.SequenceEqual(mas3))
                    break;
                //}
                count++;

            }    
            return mas;
        }

        private bool Cmp(int[] ms1, int[] ms2, int N)
        {
            for(int i=0; i<N; i++)
                if (ms1[i] != ms2[i])
                        return false;
            return true;
        }
        private int Func(int x)
        {
            if (x > 0)
                return 1;
            else
                return -1;
        }
        private void Read_to_mas(string filename)
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(filename);
            for (int i = 0; i < 625; i++)
                mas1[i] = Convert.ToInt32(reader.ReadLine());
            for (int i = 0; i < 625; i++)
                mas2[i] = Convert.ToInt32(reader.ReadLine());
            for (int i = 0; i < 625; i++)
                mas3[i] = Convert.ToInt32(reader.ReadLine());
            reader.Close();
            Mas_to_Image(bp1, mas1, 625);
            Mas_to_Image(bp2, mas2, 625);
            Mas_to_Image(bp3, mas3, 625);
        }

        private void noiseButton_Click(object sender, EventArgs e)
        {
            int c;
            Read_Image_to_mas(bp4, 625, mas4);
            if (noiseTextBox.Text != "")
            {
                c = Convert.ToInt32(noiseTextBox.Text);

                if (c > 100 || c < 0)
                {
                    c = 25;
                }

                Random random = new Random();
                var randomArray = Enumerable.Range(0, 625).OrderBy(t => random.Next()).Take(625 * c / 100).ToArray();

                for (int i = 0; i < (int)(625 * c / 100); i++)
                {
                    mas4[randomArray[i]] *= -1;
                }
                Mas_to_Image(bp4, mas4, 625);
            }
            beforePictureBox.Image = bp4;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Read_Image_to_mas(bp1, 25, mas1);
            Read_Image_to_mas(bp2, 25, mas2);
            Read_Image_to_mas(bp3, 25, mas3);
            System.IO.StreamWriter writer = new System.IO.StreamWriter("letters.txt");
            for (int i = 0; i < 625; i++)
                writer.WriteLine(mas1[i]);
            for (int i = 0; i < 625; i++)
                writer.WriteLine(mas2[i]);
            for (int i = 0; i < 625; i++)
                writer.WriteLine(mas3[i]);
            writer.Close();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();
            textBox2.Text = fd.FileName;
            if (textBox2.Text != "")
            {
                Read_to_mas(textBox2.Text);
                firstLetterPictureBox.Image = bp1;
                secondLetterPictureBox.Image = bp2;
                thirdLetterPictureBox.Image = bp3;
            }

            teachButton_Click(sender, e);

            teachButton.Enabled = true;
            saveButton.Enabled = true;
            radioButton1.Enabled = true; 
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
        }

        private void clearImageButton_Click(object sender, EventArgs e)
        {
            Clear(bp4, 25, 25);
            Clear(bp5, 25, 25);
           
            beforePictureBox.Image = bp4;
            afterPictureBox.Image = bp5;
        }
    }
}
