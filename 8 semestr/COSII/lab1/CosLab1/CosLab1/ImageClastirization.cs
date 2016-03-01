using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using System.Collections;

namespace CosLab1
{
    class ImageClastirization
    {
        private readonly int[,] imageMap;
        private int xMapPosition;
        private int yMapPosition;
        private List<ConnectedField> connectedFields;
        private Dictionary<int, ConnectedField> clasters;
        private int yMaxBuf;
        private int xMinBuf;
        private int xMaxBuf;
        private bool clasterizationReady;
        private int objectsCount;
        ObjectParameters[] objects;
        ObjectParameters[] centers;
        public Label objectsNum;
        private int num = 0;
        public int clustCount;
        Bitmap preventBitmap;

        private class ConnectedField
        {
            public int YStart { get; private set; }
            public int YEnd { get; private set; }
            public int XStart { get; private set; }
            public int XEnd { get; private set; }

            public int ClasterNumber { get; set; }

        }

        public Bitmap Image { get; private set; }

        public ImageClastirization(string fileName)
        {
            Image = new Bitmap(fileName);
            imageMap = new int[Image.Width, Image.Height];
        }

        private void FindConnectedFields()
        {
            Color pixel;
            int leftPixel, upPixel, zone = 0;

            for (yMapPosition = 0; yMapPosition < Image.Height; yMapPosition++)
            {
                for (xMapPosition = 0; xMapPosition < Image.Width; xMapPosition++)
                {
                    pixel = Image.GetPixel(xMapPosition, yMapPosition);
                    if (pixel.R == 255 && pixel.G == 255 && pixel.B == 255 && imageMap[xMapPosition, yMapPosition] == 0)
                    {
                        if (xMapPosition - 1 >= 0 && yMapPosition - 1 >=0)
                        {
                            leftPixel = imageMap[xMapPosition - 1, yMapPosition];
                            upPixel = imageMap[xMapPosition, yMapPosition - 1];
                        }
                        else
                            if (xMapPosition - 1 < 0)
                            {
                                leftPixel = 0;
                                upPixel = imageMap[xMapPosition, yMapPosition - 1];
                            }
                            else
                                if (yMapPosition - 1 < 0) 
                                {
                                    leftPixel = imageMap[xMapPosition - 1, yMapPosition];
                                    upPixel = 0;
                                }
                                else
                                {
                                    leftPixel = 0;
                                    upPixel = 0;
                                }


                        if(leftPixel == 0 && upPixel == 0)
                        {
                            zone += 1;
                            imageMap[xMapPosition, yMapPosition] = zone;

                        }
                        else 
                        {
                            if ((leftPixel > 0 && upPixel == 0) || (upPixel > 0 && leftPixel == 0))
                            {
                                if (leftPixel > 0)
                                {
                                    imageMap[xMapPosition, yMapPosition] = leftPixel;
                                }
                                else imageMap[xMapPosition, yMapPosition] = upPixel;
                            }
                            else
                            {
                                if (leftPixel == upPixel)
                                {
                                    imageMap[xMapPosition, yMapPosition] = leftPixel; // or upPixel, it does not have sense
                                }
                                else
                                {
                                    if (leftPixel != upPixel)
                                    {
                                        imageMap[xMapPosition, yMapPosition] = upPixel;
                                        fix(leftPixel, upPixel);
                                    }
                                }
                            }
                        }
                    }

                }
            }

            objectsCount = RenumberDomains();
        }


        private void fix(int what, int whereby)
        {
            for (int y = 0; y < Image.Height; y++)
            {
                for (int x = 0; x < Image.Width; x++)
                {
                    if (imageMap[x, y] == what)
                    {
                        imageMap[x, y] = whereby;
                    }
                }
            }

        }    
        private int RenumberDomains()
        {
            List<int> uniqueValues = new List<int>();
            uniqueValues.Add(0);
            for (int y = 0; y < Image.Height; y++)
            {
                for (int x = 0; x < Image.Width; x++)
                {
                    if (imageMap[x, y] != 0 && !uniqueValues.Contains(imageMap[x, y]))
                    {
                        uniqueValues.Add(imageMap[x, y]);
                        imageMap[x, y] = uniqueValues.Count()-1;
                    }
                    else if(uniqueValues.Contains(imageMap[x, y]))
                    {
                        imageMap[x, y] = uniqueValues.IndexOf(imageMap[x, y]);
                    }
                }
            }
            for (int i = 0; i < uniqueValues.Count(); i++)
            {
                uniqueValues[i] = i;
            }
            return uniqueValues.Count();
        }

        public void ToGrayTone()
        {
            try
            {
                for (var x = 0; x < Image.Width; x++)
                {
                    for (var y = 0; y < Image.Height; y++)
                    {
                        var currentPixel = Image.GetPixel(x, y);

                        var buffer = (int)(0.3 * currentPixel.R + 0.59 * currentPixel.G + 0.11 * currentPixel.B);

                        Image.SetPixel(x, y, Color.FromArgb(buffer, buffer, buffer));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void MedianFilter(int window_size)
        {


            /*int sourceWidth = Image.Width;
            int sourceHeight = Image.Height;


            int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
            float nPercent = 0, nPercentW = 0, nPercentH = 0;

            nPercentW = ((float)newWidth / (float)sourceWidth);
            nPercentH = ((float)newHeight / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((newWidth -
                            (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((newHeight -
                            (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);*/
            int zoom = 20;


            Bitmap temp = new Bitmap(Image.Width + zoom, Image.Height + zoom, Image.PixelFormat);

            int ytemp = 0;
            int xtemp = 0;

            while(true)
            {
                temp.SetPixel(xtemp, ytemp, Color.Black);
                xtemp++;
                if (xtemp == temp.Width)
                {
                    xtemp=0;
                    ytemp+=1;
                }
                if (ytemp == zoom/2)
                {
                    ytemp = temp.Height - zoom/2;
                    xtemp = 0;
                }
                else if (ytemp == temp.Height)
                {
                    break;
                }
            }

            ytemp = 0;
            xtemp = 0;

            while(true)
            {
                temp.SetPixel(xtemp, ytemp, Color.Black);
                ytemp++;
                if (ytemp == temp.Height)
                {
                    ytemp=0;
                    xtemp+=1;
                }
                if (xtemp == zoom/2)
                {
                    xtemp = temp.Width - zoom/2;
                    ytemp = 0;
                }
                else if (xtemp == temp.Width)
                {
                    break;
                }
            }

            for (ytemp = zoom/2; ytemp < temp.Height - zoom/2; ytemp++)
            {
                for (xtemp = zoom/2; xtemp < temp.Width - zoom/2; xtemp++)
                {
                    temp.SetPixel(xtemp, ytemp, Image.GetPixel(xtemp - zoom/2, ytemp - zoom/2));
                }
            }
            

            /*int edgex = window_size / 2;
            int edgey = window_size / 2;
            int width = Image.Width;
            int height = Image.Height;
            int arrlen = window_size * window_size;

            for(int x = edgex; x < width - edgex; x++)
            {
                for(int y = edgey; y < height - edgey; y++)
                {
                    int[] arrR = new int[arrlen];
                    int[] arrG = new int[arrlen];
                    int[] arrB = new int[arrlen];

                    int i = 0;
                    Color pixel;
                    for (int fx = 0; fx < window_size; fx++)
                    {
                        for (int fy = 0; fy < window_size; fy++)
                        {
                            pixel = Image.GetPixel(x + fx - edgex, y + fy - edgey);
                            arrR[i] = pixel.R;
                            arrG[i] = pixel.G;
                            arrB[i] = pixel.B;
                            i++;
                        }
                    }
                    Array.Sort(arrR);
                    Array.Sort(arrG);
                    Array.Sort(arrB);
                    Image.SetPixel(x, y, Color.FromArgb(arrR[arrlen/2], arrG[arrlen/2], arrB[arrlen/2]));
                }
            }*/

            int edgex = window_size / 2;
            int edgey = window_size / 2;
            int width = temp.Width;
            int height = temp.Height;
            int arrlen = window_size * window_size;

            for (int x = edgex; x < width - edgex; x++)
            {
                for (int y = edgey; y < height - edgey; y++)
                {
                    int[] arrR = new int[arrlen];
                    int[] arrG = new int[arrlen];
                    int[] arrB = new int[arrlen];

                    int i = 0;
                    Color pixel;
                    for (int fx = 0; fx < window_size; fx++)
                    {
                        for (int fy = 0; fy < window_size; fy++)
                        {
                            pixel = temp.GetPixel(x + fx - edgex, y + fy - edgey);
                            arrR[i] = pixel.R;
                            arrG[i] = pixel.G;
                            arrB[i] = pixel.B;
                            i++;
                        }
                    }
                    Array.Sort(arrR);
                    Array.Sort(arrG);
                    Array.Sort(arrB);
                    temp.SetPixel(x, y, Color.FromArgb(arrR[arrlen / 2], arrG[arrlen / 2], arrB[arrlen / 2]));
                }
            }

            for (ytemp = zoom/2; ytemp < temp.Height - zoom/2; ytemp++)
            {
                for (xtemp = zoom/2; xtemp < temp.Width - zoom/2; xtemp++)
                {
                    Image.SetPixel(xtemp - zoom/2, ytemp - zoom/2, temp.GetPixel(xtemp, ytemp));
                }
            }

            temp = null;
            GC.Collect();
        }

        public void Binarize(double value)
        {
            try
            {
                //const double threshold = 0.6;
                double treshold;
                if (value < 0 || value > 255)
                {
                    treshold = 128;
                }
                else
                {
                    treshold = value;
                }
                for (var x = 0; x < Image.Width; x++)
                {
                    for (var y = 0; y < Image.Height; y++)
                    {
                         //Image.SetPixel(x, y, Image.GetPixel(x, y).GetBrightness() < threshold ? Color.Black : Color.White);
                        Image.SetPixel(x, y, Image.GetPixel(x, y).R < treshold ? Color.Black : Color.White);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AdaptiveBinarize()
        {
            int threshold = 0;
            int width = Image.Width;
            int height = Image.Height;
            int window_width = 10; //3
            int window_height = 10; //3
            Color pixel;

            for (int x = 0; x < width; x = x + window_width)
            {
                for (int y = 0; y < height; y = y + window_height)
                {
                    int x2 = x + window_width;
                    int y2 = y + window_height;

                    if (x2 > width)
                        x2 = width;

                    if (y2 > height)
                        y2 = height;

                    //threshold = getTreshold(image, x, x2, y, y2);
                    threshold = 210;

                    for (int fx = x; fx < x2; fx++)
                    {
                        for (int fy = y; fy < y2; fy++)
                        {
                            pixel = Image.GetPixel(fx, fy);
                            //Scalar pixel = image.at<uchar>(fx, fy);
                            Image.SetPixel(fx, fy, Image.GetPixel(x, y).R < threshold ? Color.Black : Color.White);
                            /*if (pixel.val[0] >= threshold)
                            {
                                image_binarized.at<uchar>(fx, fy) = 255;
                            }
                            else
                            {
                                image_binarized.at<uchar>(fx, fy) = 0;
                            }*/
                        }
                    }
                }
            }
        }

        public void Clastiraize(int clustCount, Label objects)
        {
            this.clustCount = clustCount;
            this.objectsNum = objects;
            var t = new Thread(FindConnectedFields, 4000000);
            t.Start();
            t.Join();

            int temp = objectsCount - 1;
            if (objectsNum.InvokeRequired)
                objectsNum.Invoke(new Action<string>((s) => objectsNum.Text = s.ToString()), temp);
            else objectsNum.Text = (objectsCount - 1).ToString();
            //objectsNum.Text = (objectsCount - 1).ToString();

            CalculateParameters();
            num = 0;

            Hashtable table = k_medoids();

            Random random = new Random();
            Color[] colors = new Color[table.Count];
            for (int i = 0; i < table.Count; i++)
            {
                colors[i] = Color.FromArgb(random.Next(50, 255), random.Next(50, 255),
                                                                    random.Next(50, 255));
            }

            for (int y = 0; y < Image.Height; y++)
            {
                for (int x = 0; x < Image.Width; x++)
                {
                    if (imageMap[x, y] != 0)
                    {
                        for (int i = 0; i < table.Count; i++)
                        {
                            if (((List<int>)table[i]).Contains(imageMap[x, y]))
                            {
                                Image.SetPixel(x, y, colors[i]);

                                break;
                            }
                        }
                    }
                }
            }
        }
      
        private void CalculateParameters()
        {
            objects = new ObjectParameters[objectsCount];
            for (int i = 0; i < objects.Length; i++)
                objects[i] = new ObjectParameters();

            for (int y = 0; y < Image.Height; y++)
            {
                for (int x = 0; x < Image.Width; x++)
                {
                    //int labelIndex = GetLabelIndex(x, y);
                    if (imageMap[x, y] != 0)
                    {
                        objects[imageMap[x, y]].Square++;
                        objects[imageMap[x, y]].Xmas += x;
                        objects[imageMap[x, y]].Ymas += y;

                        // Связность 4, внутренняя граница
                        if (x - 1 < 0 || x + 1 >= Image.Width || y + 1 >= Image.Height || y - 1 < 0)
                        {
                            objects[imageMap[x, y]].Perimeter++;
                        }
                        else
                        {
                            if (imageMap[x, y] != imageMap[x - 1, y] || imageMap[x, y] != imageMap[x + 1, y] ||
                                imageMap[x, y] != imageMap[x, y - 1] || imageMap[x, y] != imageMap[x, y + 1])
                                objects[imageMap[x, y]].Perimeter++;
                        }
                    }
                }
            }
            // Вычисление центра масс и компактности
            for (int i = 1; i < objects.Length; i++)
            {
                objects[i].Xmas /= (double)objects[i].Square;
                objects[i].Ymas /= (double)objects[i].Square;
                objects[i].Compactness = objects[i].Perimeter * objects[i].Perimeter / objects[i].Square;
            }

            // Дискретные центральные моменты
            for (int y = 0; y < Image.Height; y++)
            {
                for (int x = 0; x < Image.Width; x++)
                {
                    if (imageMap[x, y] != 0)
                    {
                        objects[imageMap[x, y]].m20 += Math.Pow((x - objects[imageMap[x, y]].Xmas), 2);
                        objects[imageMap[x, y]].m02 += Math.Pow((y - objects[imageMap[x, y]].Ymas), 2);
                        objects[imageMap[x, y]].m11 += (x - objects[imageMap[x, y]].Xmas) * (y - objects[imageMap[x, y]].Ymas);
                    }
                }
            }

            // Вычисление удлинённости и ориентаци главной оси
            for (int i = 1; i < objects.Length; i++)
            {
                objects[i].elongation = (objects[i].m20 + objects[i].m02 + Math.Sqrt(Math.Pow((objects[i].m20 - objects[i].m02), 2) + 4 * objects[i].m11 * objects[i].m11)) /
                    (objects[i].m20 + objects[i].m02 - Math.Sqrt(Math.Pow((objects[i].m20 - objects[i].m02), 2) + 4 * objects[i].m11 * objects[i].m11));

                objects[i].OrientationOfMainAxis = 1.0 / 2.0 * Math.Atan(2 * objects[i].m11 / (objects[i].m20 - objects[i].m02));
            }
        }





        private Hashtable k_medoids()
        {
            Hashtable centersPoints = new Hashtable(clustCount);

            // выделяю место под ассоциацию цент - точки
            for (int i = 0; i < clustCount; i++)
            {
                centersPoints[i] = new List<int>();
            }

            // выделяю место под параметры центров
            centers = new ObjectParameters[clustCount];

            for (int i = 0; i < centers.Length; i++)
                centers[i] = new ObjectParameters();

            //рандомно расставляю центры по точкам
            // take clustCount random numbers in range
            Random random = new Random();
            var randomArray = Enumerable.Range(1, objects.Length-1).OrderBy(t => random.Next()).Take(clustCount).ToArray();

            for(int l=0; l < randomArray.Length; l++)
            {
                centers[l] = objects[randomArray[l]]; //присваиваем инфу точки центру
	            // или надо почленно перенести все измерения
            }


            /*Random rnd = new Random();
            ObjectParameters[] sortedObjects;
            sortedObjects = objects.OrderBy(x => x.Compactness).ToArray();
            //sortedObjects = objects.OrderBy(x => x.elongation).ToArray();
            centers[0] = sortedObjects[1];
            centers[1] = sortedObjects[sortedObjects.Length - 1];
                    
            int index = 2;
            int tmp=0;
            int er = 0;
            while(true)
            {   
                tmp = rnd.Next(1, sortedObjects.Length-2);

                for (int z = 0; z < centers.Length;z++ )
                {
                    //if (sortedObjects[tmp].elongation >= centers[z].elongation*0.2 && sortedObjects[tmp].elongation <= centers[z].elongation*1.2)
                    if (centers[z].Compactness == sortedObjects[tmp].Compactness)
                    {
                        er = 1;
                        break;
                    }
                }
                if (er==1)
                {
                    er = 0;
                    continue;
                }
                else
                {
                    centers[index] = sortedObjects[tmp];
                    index++;
                }
                if (index == centers.Length)
                    break;
            }*/

            /*Random random = new Random();
            ObjectParameters[] sortedObjects;
            sortedObjects = objects.OrderBy(x => x.Compactness).ToArray();
            var randomArray = Enumerable.Range(2, sortedObjects.Length - 2).OrderBy(t => random.Next()).Take(clustCount-2).ToArray();

            for(int j=0; j< centers.Length; j++)
            {
                if (j == 0)
                {
                    centers[j] = sortedObjects[1];
                }
                else
                    if (j == 1)
                    {
                        centers[j] = sortedObjects[sortedObjects.Length - 1];
                    }
                    else
                    {
                        centers[j] = sortedObjects[randomArray[j-2]];
                    }
            }

            */





            //соотносим точки к центрам
            double distance;
            int claster=0;
            int change = 0;
            int futureCenter = 0;

            while(true)
            {
	            // начинать надо мб с 1
	            for(int i=1; i < objects.Length; i++) //точки на графике
	            {
		            double minDistance = 999999999;
		            for(int c=0; c < centers.Length; c++) // центры кластеров на графике
		            {
			            if (objects[i] == centers[c] ) //если точка и есть центр
                        {
                            ((List<int>)centersPoints[c]).Add(i);
                            claster = c;
                            break;
                        }
			            distance = calculateDistanceMedoids(objects[i], centers[c]);
			            if (distance < minDistance)
			            {
				            minDistance = distance;
				            claster = c;
			            }
		            }

		            if(((List<int>)centersPoints[claster]).Contains(i))
			            continue;
		            else
		            {
			            ((List<int>)centersPoints[claster]).Add(i);
			            //change = 1;
		            }

	            }


	            //меняем местами центр с точками и рассчитываем самую лучшую комбинацию
	            for(int i=0; i< centersPoints.Count; i++) // для всех кластеров
	            {
		            double minLen = 9999999999999;
		            double len = 0;
                    for (int c = 0; c < ((List<int>)centersPoints[i]).Count; c++) // для всех точек
		            {
                        len = calculateBestDistance(((List<int>)centersPoints[i]).ElementAt(c), (List<int>)centersPoints[i]); //ф-я принимает центр(условный) и набор точек
			            if(len< minLen)
			            {
				            minLen = len;
				            futureCenter = ((List<int>)centersPoints[i]).ElementAt(c);
			            }
		            }
		            // здесь првоерить, если центр поменялся, то поменять и его конфигурацию(метрики)
		            if (centers[i] != objects[futureCenter])
		            {
			            change = 1;
			            centers[i] = objects[futureCenter];
		            }
	            }

	            if(change == 0)
		            break;
	            else 
	            {
		            for(int i=0; i< centersPoints.Count; i++) // для всех кластеров
		            {
			            ((List<int>)centersPoints[i]).Clear();	
		            }
                    change = 0;
	            }
            }
            return centersPoints;
        }

        public double calculateBestDistance(int objectNum, List<int> points)
        {
            double len = 0;
            for (int i = 0; i < points.Count; i++)
            {
                len += calculateDistanceMedoids(objects[objectNum], objects[points[i]]);
            }
            return len;
        }

        public double calculateDistanceMedoids(ObjectParameters obj, ObjectParameters center)
        {
            double per = Math.Pow(obj.Perimeter - center.Perimeter, 2);
            double sq = Math.Pow(obj.Square - center.Square, 2);
            double el = Math.Pow(obj.elongation - center.elongation, 2);
            double comp = Math.Pow(obj.Compactness - center.Compactness, 2);
            return Math.Sqrt(per + sq + el + comp);
        }

        public void MinFilter(string file)
        {
            preventBitmap = new Bitmap(Image); 
            for (int i = 1; i < Image.Height - 1; i++)
            {
                for (int j = 1; j < Image.Width - 1; j++)
                {
                    Image.SetPixel(j, i, pixelFilter(j, i, -1));
                }
            }
        }

        public void MaxFilter(string file)
        {
            preventBitmap = new Bitmap(Image);
            for (int i = 1; i < Image.Height - 1; i++)
            {
                for (int j = 1; j < Image.Width - 1; j++)
                {
                    Image.SetPixel(j, i, pixelFilter(j, i, 1));
                }
            }
        }

        public Color pixelFilter(int x, int y, int what)                                         // min, max, min-max
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
    }
}
