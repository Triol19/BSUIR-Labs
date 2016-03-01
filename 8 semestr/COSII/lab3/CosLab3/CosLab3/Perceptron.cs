using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosLab3
{
    class Perceptron
    {
        private double[,] associativeLayer_weights;
        private double[] associativeLayer_thresholds;

        private double[,] outputLayer_weights;
        private double[] outputLayer_thresholds;

        private int sensorCount;
        private int outputCount;
        private int associativeCount;

        private double alfa;
        private double beta;
        private double maxErrorTreshold;
        
        private char[] classesNames;

        public Perceptron(int cnt, double alfa, double beta, double maxError)
        {
            classesNames = new char[cnt];
            classesNames[0] = 'M';
            classesNames[0] = 'D';
            classesNames[0] = 'H';

            this.alfa = alfa;
            this.beta = beta;
            this.maxErrorTreshold = maxError;
        }

        public int TeachNeuralNetwork(int sizeMatrix, int classCnt, List<int[]> imgs)
        {
            sensorCount = sizeMatrix;
            outputCount = classCnt;

            associativeCount = (int) Math.Sqrt(sensorCount / outputCount); //(sensorCount + outputCount) / 2;

            associativeLayer_weights = new double[sensorCount, associativeCount];
            associativeLayer_thresholds = new double[associativeCount];

            outputLayer_weights = new double[associativeCount, outputCount];
            outputLayer_thresholds = new double[outputCount];

            Randomize();

            double[] associativeNeurons = new double[associativeCount];
            double[] outputNeurons = new double[outputCount];

            List<double> maxErrors = new List<double>();
            List<int[]> images = new List<int[]>();

            int iterCount = 0;
            double errorSumPrev = double.MaxValue;

            double[] outputErrors = new double[outputCount];
            double[] outputErrorsAbs = new double[outputCount];
            //double miu = 0.5;
            while (true)
            {
                maxErrors.Clear();

                for (int z = 0; z < classCnt; z++) //для каждого класса
                {
                    images.Clear();                               //берём массив изображений
                    images.Add(imgs[z * 3]);
                    images.Add(imgs[z * 3 + 1]);
                    images.Add(imgs[z * 3 + 2]);

                    foreach (int[] img in images) //берём поочерёдно каждое изображение
                    {
                        for (int j = 0; j < associativeCount; j++)
                        {
                            double sum = 0;
                            for (int i = 0; i < sensorCount; i++)
                                sum += associativeLayer_weights[i, j] * img[i];

                            associativeNeurons[j] = ActivationFunction(sum + associativeLayer_thresholds[j]);
                        }

                        for (int k = 0; k < outputCount; k++)
                        {
                            double sum = 0;
                            for (int j = 0; j < associativeCount; j++)
                                sum += outputLayer_weights[j, k] * associativeNeurons[j];

                            outputNeurons[k] = ActivationFunction(sum + outputLayer_thresholds[k]);
                        }


                        //---------------------------------------------------
                        Array.Clear(outputErrors, 0, outputErrors.Length);
                        outputErrors[z] = 1;

                        for (int k = 0; k < outputCount; k++)
                            outputErrors[k] -= outputNeurons[k];

                        outputErrorsAbs = outputErrors.Select(x => Math.Abs(x)).ToArray();
                        maxErrors.Add(outputErrorsAbs.Max());

                        double[] associativeErrors = new double[associativeCount]; //определение ошибки скрытого слоя
                        for (int j = 0; j < associativeCount; j++)
                        {
                            double sum = 0;
                            for (int k = 0; k < outputCount; k++)
                                sum += outputErrors[k] * outputNeurons[k] * (1 - outputNeurons[k]) * outputLayer_weights[j, k];

                            associativeErrors[j] = sum;
                        }

                        //-----------------------------------------------------------------------------
                        // правим веса и пороги

                        for (int j = 0; j < associativeCount; j++)
                        {
                            for (int k = 0; k < outputCount; k++)
                            {
                                outputLayer_weights[j, k] += alfa * outputNeurons[k] * (1 - outputNeurons[k]) * outputErrors[k] * associativeNeurons[j];
                            }
                        }
                        for (int k = 0; k < outputCount; k++)
                        {
                            outputLayer_thresholds[k] += alfa * outputNeurons[k] * (1 - outputNeurons[k]) * outputErrors[k];
                        }

                        for (int i = 0; i < sensorCount; i++)
                        {
                            for (int j = 0; j < associativeCount; j++)
                            {
                                associativeLayer_weights[i, j] += beta * associativeNeurons[j] * (1 - associativeNeurons[j]) * associativeErrors[j] * img[i];
                            }
                        }
                        for (int j = 0; j < associativeCount; j++)
                        {
                            associativeLayer_thresholds[j] += beta * associativeNeurons[j] * (1 - associativeNeurons[j]) * associativeErrors[j];
                        }
                    }
                }

                iterCount++;

                double maxError = maxErrors.Max();
                if (maxError < maxErrorTreshold)
                    break;

                double errorSum = outputErrorsAbs.Sum();
                if (errorSum >= errorSumPrev)
                {
                    Randomize();
                    errorSumPrev = double.MaxValue;
                }
                else
                    errorSumPrev = errorSum;                  
            }
            return iterCount;             
        }

        private double ActivationFunction(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }

        private void Randomize()
        {
            Random RND = new Random();
            Random random = new Random(RND.Next() ^ Environment.TickCount);

            for (int i = 0; i < associativeLayer_weights.GetLength(0); i++)
            {
                for (int j = 0; j < associativeLayer_weights.GetLength(1); j++)
                    associativeLayer_weights[i, j] = 2 * random.NextDouble() - 1;
            }

            for (int i = 0; i < associativeLayer_thresholds.Length; i++)
                associativeLayer_thresholds[i] = 2 * random.NextDouble() - 1;

            for (int i = 0; i < outputLayer_weights.GetLength(0); i++)
            {
                for (int j = 0; j < outputLayer_weights.GetLength(1); j++)
                    outputLayer_weights[i, j] = 2 * random.NextDouble() - 1;
            }

            for (int i = 0; i < outputLayer_thresholds.Length; i++)
                outputLayer_thresholds[i] = 2 * random.NextDouble() - 1;
        }

        public double[] ClassifyImage(int[] image)
        {
            double[] associativeNeurons = new double[associativeCount];
            double[] outputNeurons = new double[outputCount];

            for (int j = 0; j < associativeCount; j++)
            {
                double sum = 0;
                for (int i = 0; i < sensorCount; i++)
                    sum += associativeLayer_weights[i, j] * image[i];

                associativeNeurons[j] = ActivationFunction(sum + associativeLayer_thresholds[j]);
            }

            for (int k = 0; k < outputCount; k++)
            {
                double sum = 0;
                for (int j = 0; j < associativeCount; j++)
                    sum += outputLayer_weights[j, k] * associativeNeurons[j];

                outputNeurons[k] = ActivationFunction(sum + outputLayer_thresholds[k]);
            }

            return outputNeurons;
        }
    }
}