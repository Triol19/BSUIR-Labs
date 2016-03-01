using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CosLab4
{
    class RBF
    {
        int number_class, number_image, number_neyron;
        double[,] mas_W;
        double[] mas_G, mas_Y, mas_t1, mas_t2, mas_t3;
        double sko_value;
        double valid_err;
        double alfa = 1;
        public RBF(int kol_class, int kol_image, int kol_neyron)
        {
            number_class = kol_class;
            number_image = kol_image;
            number_neyron = kol_neyron;
            mas_Y = new double[number_class];
            mas_G = new double[number_class];
            Random rand = new Random();
            mas_W = new double[number_class, number_class];
            for (int i = 0; i < number_class; i++)
            {
                for (int j = 0; j < number_class; j++)
                {
                    mas_W[i, j] = 1 - 2 * rand.NextDouble();
                }
            }

        }
        public double[] Mat_wait(int[] mas1, int[] mas2, int[] mas3)
        {
            double[] mas_out = new double[number_neyron];
            for (int i = 0; i < number_neyron; i++)
            {
                mas_out[i] = (mas1[i] + mas2[i] + mas3[i]) / 3.0;
            }
            return mas_out;
        }

        public double SKO(double[] mas1, double[] mas2, Double[] mas3)
        {
            double sko = 0;
            for (int i = 0; i < number_neyron; i++)
            {
                sko += ((mas2[i] - mas1[i]) * (mas2[i] - mas1[i]));
            }
            sko /= 2;
            sko = Math.Sqrt(sko);
            double sko1 = 0;
            for (int i = 0; i < number_neyron; i++)
            {
                sko1 += ((mas3[i] - mas1[i]) * (mas3[i] - mas1[i]));
            }
            sko1 /= 2;
            sko1 = Math.Sqrt(sko1);
            double sko2 = 0;
            for (int i = 0; i < number_neyron; i++)
            {
                sko2 += ((mas3[i] - mas2[i]) * (mas3[i] - mas2[i]));
            }
            sko2 /= 2;
            sko2 = Math.Sqrt(sko2);
            return Math.Min(Math.Min(sko,sko1), sko2);
            //return sko * sko;
        }
        private double Evklid_number(int[] mas_in, double[] mas_t)
        {
            double e = 0;
            for (int i = 0; i < number_neyron; i++)
            {
                e += ((mas_in[i] - mas_t[i]) * (mas_in[i] - mas_t[i]));
            }
            return e;
        }

        private double[] Studing(int[] mas, int number_image, double[] mas_t1, double[] mas_t2, double[] mas_t3, double sko)
        {
            double[] err = new double[number_class];
            //************************
            double e = 0;
            mas_G[0] = Math.Exp((-1) * (Evklid_number(mas, mas_t1)) / (sko * sko));
            mas_G[1] = Math.Exp((-1) * (Evklid_number(mas, mas_t2)) / (sko * sko));
            mas_G[2] = Math.Exp((-1) * (Evklid_number(mas, mas_t3)) / (sko * sko));

            for (int k = 0; k < number_class; k++)
            {
                e = 0;
                for (int j = 0; j < number_class; j++)
                    e += mas_W[j, k] * mas_G[j];
                mas_Y[k] = e;
            }
            if (number_image == 1)
            {
                err[0] = 1 - mas_Y[0];
                err[1] = 0 - mas_Y[1];
                err[2] = 0 - mas_Y[2];
            }
            if (number_image == 2)
            {
                err[0] = 0 - mas_Y[0];
                err[1] = 1 - mas_Y[1];
                err[2] = 0 - mas_Y[2];
            }
            if (number_image == 3)
            {
                 err[0] = 0 - mas_Y[0];
                 err[1] = 0 - mas_Y[1];
                 err[2] = 1 - mas_Y[2];
            }
            return err;
        }
        private void Korrekt(double[] err)
        {

            for (int j = 0; j < number_class; j++)
            {
                for (int k = 0; k < number_class; k++)
                {
                    mas_W[j, k] += alfa * err[k] * mas_G[j];
                }
            }

        }
        public int Analiz(int[] mas1_1, int[] mas1_2, int[] mas1_3, int[] mas2_1, int[] mas2_2, int[] mas2_3, int[] mas3_1, int[] mas3_2, int[] mas3_3, double error, double speed)
        {
            double[] err;
            int i = 0;
            double max_err = 0;
            valid_err = error;
            alfa = speed;

            mas_t1 = Mat_wait(mas1_1, mas1_2, mas1_3);
            mas_t2 = Mat_wait(mas2_1, mas2_2, mas2_3);
            mas_t3 = Mat_wait(mas3_1, mas3_2, mas3_3);
            sko_value = SKO(mas_t1, mas_t2, mas_t3);
            while (true && i < 30000)
            {
                err = Studing(mas1_1, 1, mas_t1,mas_t2, mas_t3, sko_value);
                max_err = Math.Max( Math.Max(Math.Abs(err[0]), Math.Abs(err[1])), Math.Abs(err[2]));
                Korrekt(err);
                err = Studing(mas2_1, 2, mas_t1,mas_t2, mas_t3, sko_value);
                if (Math.Max( Math.Max(Math.Abs(err[0]), Math.Abs(err[1])), Math.Abs(err[2])) > max_err)
                    max_err = Math.Max(Math.Max(Math.Abs(err[0]), Math.Abs(err[1])), Math.Abs(err[2]));
                Korrekt(err);
                err = Studing(mas3_1, 3, mas_t1, mas_t2, mas_t3, sko_value);
                if (Math.Max( Math.Max(Math.Abs(err[0]), Math.Abs(err[1])), Math.Abs(err[2])) > max_err)
                    max_err = Math.Max(Math.Max(Math.Abs(err[0]), Math.Abs(err[1])), Math.Abs(err[2]));
                Korrekt(err);

                if (max_err < valid_err/100)
                    return i;
                else
                    i++;
            }
            return i;
        }
        public double[] Analiz_Image(int[] mas)
        {
            mas_G[0] = Math.Exp((-1) * (Evklid_number(mas, mas_t1)) / (sko_value * sko_value));
            mas_G[1] = Math.Exp((-1) * (Evklid_number(mas, mas_t2)) / (sko_value * sko_value));
            mas_G[2] = Math.Exp((-1) * (Evklid_number(mas, mas_t3)) / (sko_value * sko_value));
            double e = 0;
            for (int k = 0; k < number_class; k++)
            {
                e = 0;
                for (int j = 0; j < number_class; j++)
                    e += mas_W[j, k] * mas_G[j];
                mas_Y[k] = e;
            }
            return mas_Y;
        }

    }
}
