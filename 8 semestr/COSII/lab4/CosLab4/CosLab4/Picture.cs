using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CosLab4
{
    class Picture
    {
        private Bitmap bp;
        private int X;
        private int Y;
        private int Width;
        private int Heigth;
        private PictureBox pict_box;
        public Picture(PictureBox pict,int Masht_X,int Masht_Y)
        {
            int W=0, H=0;
            X = Masht_X;
            Y = Masht_Y;
            pict_box = pict;
            if (pict.Width % Masht_X != 0)
            {
                Width = (int)(pict.Width / Masht_X);
                W = Width * (Masht_X) + 1;
            }
            else
                W = pict.Width+1;
            if (pict.Height % Masht_Y != 0)
            {
                Heigth = (int)(pict.Height / Masht_Y);
                H = Heigth * (Masht_Y)+1;
            }
            else
                H = pict.Height+1;
            pict.BackColor = Color.White;
            bp = new Bitmap(W, H);
        }
        public void Analiz_Mouse(System.Windows.Forms.MouseEventArgs e,Color clear_color,Color set_color)
        {
            if (e.Button == MouseButtons.Left)
                SetPixel(((int)(e.X / X)), ((int)(e.Y / Y)), set_color);
            if (e.Button == MouseButtons.Right)
                SetPixel(((int)(e.X / X)), ((int)(e.Y / Y)), clear_color);
        }
        private bool Cmp_Color(Color color1, Color color2)
        {
            if (color1.A == color2.A && color1.B == color2.B && color1.R == color2.R && color1.G == color2.G)
                return true;
            else
                return false;
        }
        public int[] Analiz_Image(Color clear_color, Color set_color)
        {
            int[] mas = new int[Width * Heigth];
            int k = 0;
            Color c;
            for(int i = 0;i<Width;i++)
                for (int j = 0; j < Heigth; j++)
                {
                    c = GetPixel(j, i);
                    if(Cmp_Color(set_color,c))
                        mas[k] = 0;
                    else 
                        mas[k] = 1;
                    
                    k++;
                }
            return mas;            
        }
        public void Clear(Color clear_color,Color set_color, Color line_color)
        {
            Color c;
            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Heigth; j++)
                {
                    c = GetPixel(i, j);
                    if (c.A == set_color.A && c.B == set_color.B && c.R == set_color.R && c.G == set_color.G)
                        SetPixel(i, j, clear_color);
                }
            for (int i = 0; i <= Width; i++)
                for (int j = 0; j <= Heigth * Y; j++)
                    bp.SetPixel(i*X, j, line_color);
            for (int i = 0; i <= Heigth; i++)
                for (int j = 0; j <= Width * X; j++)
                    bp.SetPixel(j, i*Y, line_color);
            pict_box.Image = bp;
            
        }
        public void SetPixel(int X_val, int Y_val, Color c)
        {
            if (X_val < Width && Y_val < Heigth && X_val >=0 && Y_val >=0)
            {
                for (int i = X_val * X + 1; i < X_val * X + X; i++)
                    for (int j = Y_val * Y + 1; j < Y_val * Y + Y; j++)
                        bp.SetPixel(i, j, c);
            }
            pict_box.Image = bp;
        }
        public Color GetPixel(int X_val, int Y_val)
        {
            return bp.GetPixel((X_val * X + 1), (Y_val * Y + 1));
        }
        public void Mas_to_Image(int [] mas,Color set_color, Color clear_color)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] == 1)
                    SetPixel(i - (int)(i / Heigth)*25, (int)(i / Heigth), clear_color); /////////////////////////////////////////////////////////
                if (mas[i] == 0)
                    SetPixel(i - (int)(i / Heigth) * 25, (int)(i / Heigth), set_color);
            }
        }
        public void Read_Image_to_mas(int n, int[] mas)
        {
            Color c;
            int k = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    c = GetPixel(j, i);
                    if (c.A == Color.Black.A && c.B == Color.Black.B && c.R == Color.Black.R && c.G == Color.Black.G)
                        mas[k] = 0;
                    else
                    //if (c.A == Color.White.A && c.B == Color.White.B && c.R == Color.White.R && c.G == Color.White.G)
                        mas[k] = 1;
                    k++;
                }
        }
    }
}
