using System;
using System.Windows.Forms;
using System.IO;


namespace CosLab1
{
    public partial class Form1 : Form
    {
        private string ImageLocation;
        private ImageClastirization imageClastirization;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (useMedian.Checked && Convert.ToInt32(textBox_kernel.Text) % 2 !=0 && Convert.ToInt32(textBox_kernel.Text) >= 3)
            {
                imageClastirization.MedianFilter(Convert.ToInt32(textBox_kernel.Text));
            }
            pictureBox1.Refresh();
            imageClastirization.ToGrayTone();
            pictureBox1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            imageClastirization.Binarize(Convert.ToDouble(textBox_treshold.Text));
            pictureBox1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                imageClastirization = new ImageClastirization(ImageLocation);
                pictureBox1.Image = imageClastirization.Image;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save("D:\\Saved image.jpg");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            imageClastirization.Clastiraize(Convert.ToInt32(textBox_Clust.Text), label_objects);
            pictureBox1.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox1.Invalidate();

            Stream fileStream = null;                               // input file
            OpenFileDialog FileDialog = new OpenFileDialog();       // window for file choose


            FileDialog.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|" +
                                    "All files (*.*)|*.*";

            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                fileStream = FileDialog.OpenFile();
                imageClastirization = new ImageClastirization(FileDialog.FileName);
                pictureBox1.Image = imageClastirization.Image;
                ImageLocation = FileDialog.FileName;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            imageClastirization.AdaptiveBinarize();
            pictureBox1.Refresh();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            imageClastirization.MinFilter(ImageLocation);
            pictureBox1.Refresh();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            imageClastirization.MaxFilter(ImageLocation);
            pictureBox1.Refresh();
        }
    }
}
