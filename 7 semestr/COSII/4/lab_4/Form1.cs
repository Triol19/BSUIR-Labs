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

namespace lab_4
{
    public partial class Form1 : Form
    {
        Image preventImage;
        Bitmap currentBitmap;
        Bitmap preventBitmap;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;                                 // key processing ON
            this.KeyDown += new KeyEventHandler(Key_Down);          // add key processor
            label1.Visible = false;
        }

        private void Key_Down(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                if (e.KeyCode == Keys.Q)                            // reset to previous image
                {
                    Image tempImage;
                    tempImage = pictureBox2.Image;
                    pictureBox2.Image = preventImage;
                    preventImage = tempImage;
                }
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox1.Invalidate();
            pictureBox2.Invalidate();

            Stream fileStream = null;                               // input file
            OpenFileDialog FileDialog = new OpenFileDialog();       // window for file choose

            preventImage = pictureBox1.Image;

            FileDialog.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|" +
                                    "All files (*.*)|*.*";

            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                fileStream = FileDialog.OpenFile();
                pictureBox1.Image = new Bitmap(fileStream);
                pictureBox2.Image = (Image)pictureBox1.Image.Clone(); // copy imge from PB1 to PB2
                saveToolStripMenuItem.Enabled = true;
                closeToolStripMenuItem.Enabled = true;
                dissectionToolStripMenuItem.Enabled = true;
                resetToolStripMenuItem.Enabled = true;
                disDToolStripMenuItem.Enabled = true;
                disEToolStripMenuItem.Enabled = true;
                filterToolStripMenuItem.Enabled = true;
                minFilterToolStripMenuItem.Enabled = true;
                maxFilterToolStripMenuItem.Enabled = true;
                minMaxFilterToolStripMenuItem.Enabled = true;
            }

            drawHistogram(0);
            //drawHistogram(1);
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = ".jpeg|*.jpg|.bmp|*.bmp|.gif|*.gif";
            saveFileDialog1.Title = "Save image as";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        this.pictureBox2.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                    case 2:
                        this.pictureBox2.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp); break;
                    case 3:
                        this.pictureBox2.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Gif); break;
                }
                fs.Close();
            }
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox1.Invalidate();
            pictureBox2.Image = null;
            pictureBox2.Invalidate();
            for (int z = 0; z < 3; z++ )
            {
                this.chart1.Series[z].Points.Clear();
                this.chart2.Series[z].Points.Clear();
            }
        }
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = (Image)pictureBox1.Image.Clone();
            drawHistogram(1);
        }
        Color pixelFilter(int x, int y, int what)                                         // min, max, min-max
        {
            Color currentPixel = new Color();

            byte[] r_canal = new byte[9];
            byte[] g_canal = new byte[9];
            byte[] b_canal = new byte[9];

            for (int i = 0; i < 9; i++)
            {
                try
                {
                    switch (i)
                    {
                        case 0: currentPixel = preventBitmap.GetPixel(x, y); break;
                        case 1: currentPixel = preventBitmap.GetPixel(x - 1, y - 1); break;
                        case 2: currentPixel = preventBitmap.GetPixel(x, y - 1); break;
                        case 3: currentPixel = preventBitmap.GetPixel(x + 1, y - 1); break;
                        case 4: currentPixel = preventBitmap.GetPixel(x + 1, y); break;
                        case 5: currentPixel = preventBitmap.GetPixel(x + 1, y + 1); break;
                        case 6: currentPixel = preventBitmap.GetPixel(x, y + 1); break;
                        case 7: currentPixel = preventBitmap.GetPixel(x - 1, y + 1); break;
                        case 8: currentPixel = preventBitmap.GetPixel(x - 1, y); break;
                    }
                    r_canal[i] = currentPixel.R;
                    g_canal[i] = currentPixel.G;
                    b_canal[i] = currentPixel.B;
                }
                catch (Exception ex)
                {
                    r_canal[i] = 255;
                    g_canal[i] = 255;
                    b_canal[i] = 255;
                }
            }

            if (what < 0)
            {
                return Color.FromArgb(r_canal.Min(), g_canal.Min(), b_canal.Min());
            }
            else
                return Color.FromArgb(r_canal.Max(), g_canal.Max(), b_canal.Max());
        }
        private void drawHistogram(byte number)
        {
            int[] r_canal = new int[256];
            int[] g_canal = new int[256];
            int[] b_canal = new int[256];
            int[] brightness = new int[256];

            Color currentPixel = new Color();

            try
            {
                switch (number)
                {
                    case 0:
                        {
                            this.chart1.Series[0].Points.Clear();
                            this.chart1.Series[1].Points.Clear();
                            this.chart1.Series[2].Points.Clear();
                            this.chart3.Series[0].Points.Clear();

                            currentBitmap = new Bitmap(this.pictureBox1.Image);

                            for (int i = 0; i < pictureBox1.Image.Height; i++)
                            {
                                for (int j = 0; j < pictureBox1.Image.Width; j++)
                                {
                                    currentPixel = currentBitmap.GetPixel(j, i);

                                    r_canal[currentPixel.R]++;
                                    g_canal[currentPixel.G]++;
                                    b_canal[currentPixel.B]++;
                                    brightness[(int)(currentPixel.GetBrightness() * 255)]++;
                                }
                            }
                            for (int h = 0; h < 256; h++)
                            {
                                chart1.Series[0].Points.AddXY(h, r_canal[h]);
                                chart1.Series[1].Points.AddXY(h, g_canal[h]);
                                chart1.Series[2].Points.AddXY(h, b_canal[h]);
                                chart3.Series[0].Points.AddXY(h, brightness[h]);
                            }

                        } break;
                    case 1:
                        {
                            this.chart2.Series[0].Points.Clear();
                            this.chart2.Series[1].Points.Clear();
                            this.chart2.Series[2].Points.Clear();
                            this.chart4.Series[0].Points.Clear();

                            currentBitmap = new Bitmap(this.pictureBox2.Image);

                            for (int i = 0; i < pictureBox2.Image.Height; i++)
                            {
                                for (int j = 0; j < pictureBox2.Image.Width; j++)
                                {
                                    currentPixel = currentBitmap.GetPixel(j, i);

                                    r_canal[currentPixel.R]++;
                                    g_canal[currentPixel.G]++;
                                    b_canal[currentPixel.B]++;
                                    brightness[(int)(currentPixel.GetBrightness() * 255)]++;
                                }
                            }
                            for (int h = 0; h < 256; h++)
                            {
                                chart2.Series[0].Points.AddXY(h, r_canal[h]);
                                chart2.Series[1].Points.AddXY(h, g_canal[h]);
                                chart2.Series[2].Points.AddXY(h, b_canal[h]);
                                chart4.Series[0].Points.AddXY(h, brightness[h]);
                            }

                        } break;
                }
            }

            catch(Exception ex)
            {
                return;
            }
        }
        private void minFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preventImage = pictureBox1.Image;
            preventBitmap = new Bitmap(this.pictureBox1.Image);
            currentBitmap = new Bitmap(this.pictureBox1.Image);

            showLabelText(1);

            for (int i = 1; i < pictureBox1.Image.Height-1; i++)
            {
                for (int j = 1; j < pictureBox1.Image.Width-1; j++)
                {
                    currentBitmap.SetPixel(j, i, pixelFilter(j, i, -1));
                    progressBar1.Increment(1);
                }
            }

            showLabelText(-1);

            pictureBox2.Image = currentBitmap;
            drawHistogram(1);
        }
        private void maxFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preventImage = pictureBox1.Image;
            preventBitmap = new Bitmap(this.pictureBox1.Image);
            currentBitmap = new Bitmap(this.pictureBox1.Image);

            showLabelText(1);

            for (int i = 1; i < pictureBox1.Image.Height-1; i++)
            {
                for (int j = 1; j < pictureBox1.Image.Width-1; j++)
                {
                    currentBitmap.SetPixel(j, i, pixelFilter(j, i, 1));
                    progressBar1.Increment(1);
                }
            }

            showLabelText(-1);

            pictureBox2.Image = currentBitmap;
            drawHistogram(1);
        }
        private void minMaxFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preventImage = pictureBox1.Image;
            preventBitmap = new Bitmap(this.pictureBox1.Image);
            currentBitmap = new Bitmap(this.pictureBox1.Image);

            showLabelText(1, 1);

            for (int i = 1; i < pictureBox1.Image.Height-1; i++)
            {
                for (int j = 1; j < pictureBox1.Image.Width-1; j++)
                {
                    currentBitmap.SetPixel(j, i, pixelFilter(j, i, -1));
                    progressBar1.Increment(1);
                }
            }

            pictureBox2.Image = currentBitmap;
            preventBitmap = new Bitmap(this.pictureBox2.Image);

            for (int i = 1; i < pictureBox2.Image.Height-1; i++)
            {
                for (int j = 1; j < pictureBox2.Image.Width-1; j++)
                {
                    currentBitmap.SetPixel(j, i, pixelFilter(j, i, 1));
                    progressBar1.Increment(1);
                }
            }

            showLabelText(-1);

            pictureBox2.Image = currentBitmap;
            drawHistogram(1);
        }
        byte funcD(byte i)
        {
            float min = float.Parse(this.textBox1.Text);
            float max = float.Parse(this.textBox2.Text);
            byte result = (byte)(((max - min) * (float)(i) / 255) + min);
            return result;
        }
        byte funcE(byte i)
        {
            byte min = byte.Parse(this.textBox1.Text);
            byte max = byte.Parse(this.textBox2.Text);

            if (i <= min)
                return 0;
            if (i >= max)
                return 255;
            if (i > min && i < max)
            {
                byte result = (byte)(255 * (float)(i - min) / (float)(max - min));
                return result;
            }
            return 0;
        }    
        private Color dissection(int x, int y, char algorithm)                                   // preparirovanie
        {
            Color currentPixel = new Color();

            currentPixel = preventBitmap.GetPixel(x, y);

            if (algorithm == 'E')
            {
                return Color.FromArgb(funcE(currentPixel.R), funcE(currentPixel.G), funcE(currentPixel.B));
            }
            else
            {
                return Color.FromArgb(funcD(currentPixel.R), funcD(currentPixel.G), funcD(currentPixel.B));
            }
        }
        private void disLoop(char algorithm)
        {
            preventImage = pictureBox1.Image;
            preventBitmap = new Bitmap(this.pictureBox1.Image);
            currentBitmap = new Bitmap(this.pictureBox1.Image);

            showLabelText(1);

            for (int i = 0; i < pictureBox1.Image.Height; i++)
            {
                for (int j = 0; j < pictureBox1.Image.Width; j++)
                {
                    if (algorithm == 'E')
                    {
                        currentBitmap.SetPixel(j, i, dissection(j, i, 'E'));
                    }
                    else
                    {
                        currentBitmap.SetPixel(j, i, dissection(j, i, 'D'));
                    }
                    progressBar1.Increment(1);
                }
            }

            showLabelText(-1);

            pictureBox2.Image = currentBitmap;
            drawHistogram(1);
        }
        private void disDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disLoop('D');
        }
        private void disEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disLoop('E');
        }

        private void showLabelText(int i, int filter=0)
        {
            if (i > 0)
            {
                if (filter == 0)
                {
                    this.progressBar1.Maximum = pictureBox1.Image.Width * pictureBox1.Image.Height;
                }
                else
                {
                    this.progressBar1.Maximum = 2*pictureBox1.Image.Width * pictureBox1.Image.Height;
                }
                this.label1.Visible = true;
                Application.DoEvents();
            }
            else
            {
                this.label1.Visible = false;
                progressBar1.Value = 0;
            }
        }
        private void scrollMin(object sender, EventArgs e)
        {
           this.textBox1.Text = this.trackBar1.Value.ToString();
        }
        private void scrollMax(object sender, EventArgs e)
        {
            this.textBox2.Text = this.trackBar2.Value.ToString();
        }
    }
}