using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace WindowsFormsApplication5
{
    public delegate Complex Function(Complex argValue);
    class FourierTransform
    {
        int operationsCount = 0;

        public Complex[] CreatePointsArray(int pointsCount, Function func)  // get vector of "pointsCount" dots 
        {
            double stepValue = 2 * Math.PI / pointsCount;
            double argumentValue = 0;
            Complex[] pointsArray = new Complex[pointsCount];

            for (int i = 0; i < pointsCount; i++)
            {
                pointsArray[i] = func(argumentValue);
                argumentValue += stepValue;
            }

            return pointsArray;
        }

        public Complex[] DiscreteFourierTransform(Complex[] inputArray)
        {
            int pointsCount = inputArray.Length;
            Complex[] resultArray = new Complex[pointsCount];

            for (int i = 0; i < pointsCount; i++)
            {
                resultArray[i] = 0;

                for (int j = 0; j < pointsCount; j++)
                {
                    resultArray[i] += inputArray[j] * Complex.Exp(-1 * Complex.ImaginaryOne * 2 * Math.PI * j * i / pointsCount); // change znak of im part in comlex form of Furie
                    // i = index of frequency
                    //result = complex aplitude 
                    operationsCount++;
                }
            }

            return resultArray;
        }

        public Complex[] InverseDiscreteFourierTransform(Complex[] inputArray)
        {
            int pointsCount = inputArray.Length;
            Complex[] resultArray = new Complex[pointsCount];

            for (int i = 0; i < pointsCount; i++)
            {
                resultArray[i] = 0;

                for (int j = 0; j < pointsCount; j++)
                {
                    resultArray[i] += inputArray[j] * Complex.Exp(Complex.ImaginaryOne * 2 * Math.PI * j * i / pointsCount);
                    operationsCount++;
                }

                resultArray[i] /= pointsCount;
            }

            return resultArray;
        }

        public Complex[] FastFourierTransform(Complex[] inputArray)
        {
            int pointsCount = inputArray.Length;
            Complex[] resultArray = new Complex[pointsCount];
            Complex[] tempArray_1 = new Complex[pointsCount / 2];
            Complex[] tempArray_2 = new Complex[pointsCount / 2];

            for (int i = 0; i < pointsCount; i++)
            {
                if (i % 2 == 0)
                    tempArray_1[i / 2] = inputArray[i];
                else
                    tempArray_2[i / 2] = inputArray[i];
            }

            if (pointsCount > 2)
            {
                tempArray_1 = FastFourierTransform(tempArray_1);
                tempArray_2 = FastFourierTransform(tempArray_2);
            }

            for (int i = 0; i < pointsCount / 2; i++)
            {
                resultArray[i] = tempArray_1[i] + tempArray_2[i] * Complex.Exp(-1 * Complex.ImaginaryOne * 2 * Math.PI * i / pointsCount);
                resultArray[i + pointsCount / 2] = tempArray_1[i] - tempArray_2[i] * Complex.Exp(-1 * Complex.ImaginaryOne * 2 * Math.PI * i / pointsCount);

                operationsCount++;
            }

            return resultArray;
        }

        public Complex[] InverseFastFourierTransform(Complex[] inputArray)
        {
            int pointsCount = inputArray.Length;

            Complex[] resultArray = new Complex[pointsCount];

            for (int i = 0; i < pointsCount; i++)
                inputArray[i] = Complex.Conjugate(inputArray[i]);

            resultArray = FastFourierTransform(inputArray);

            for (int i = 0; i < pointsCount; i++)
                resultArray[i] = Complex.Conjugate(resultArray[i]);

            for (int i = 0; i < pointsCount; i++)
                resultArray[i] /= pointsCount;

            return resultArray;
        }

        public int GetOperationsCount()
        {
            return operationsCount;
        }

        public void ResetOperationsCount()
        {
            operationsCount = 0;
        }

        public Complex[] Convolution(Complex[] values1, Complex[] values2)
        {
            //length of 2 vectors must be == between them
            int N = values1.Length;
            Complex[] result = new Complex[N];

            for (int m = 0; m < N; m++)
            {
                for (int h = 0; h < N; h++)
                {
                    if (m - h >= 0)
                    {
                        result[m] += values1[h] * values2[m - h];
                        operationsCount++;
                    }
                    else
                    {
                        result[m] += values1[h] * values2[m - h + N];
                        operationsCount++;
                    }
                }
                result[m] /= N;
                //operationsCount++;
            }
            return result;
        }
        public Complex[] Correlation(Complex[] values1, Complex[] values2)
        {
            //length of 2 vectors must be == between them
            int N = values1.Length;
            Complex[] result = new Complex[N];

            for (int m = 0; m < N; m++)
            {
                for (int h = 0; h < N; h++)
                {
                    if (m + h < N)
                    {
                        result[m] += values1[h] * values2[m + h];
                        //operationsCount++;
                    }
                    else
                    {
                        result[m] += values1[h] * values2[m + h - N];
                        //operationsCount++;
                    }
                }
                result[m] /= N;
                //operationsCount++;
            }
            return result;
        }
        public Complex[] ConvolutionFFT(Complex[] values1, Complex[] values2)  //  conv FFT
        {
            Complex[] transformedValues1 = FastFourierTransformFrequency(values1, 1);
            Complex[] transformedValues2 = FastFourierTransformFrequency(values2, 1);

            transformedValues1 = transformedValues1.Zip(transformedValues2, (x, y) => x * y).ToArray();
            return FastFourierTransformFrequency(transformedValues1, -1);
        }

        public Complex[] CorrelationFFT(Complex[] values1, Complex[] values2)  //  cor FFT
        {
            Complex[] transformedValues1 = FastFourierTransformFrequency(values1, 1);
            Complex[] transformedValues2 = FastFourierTransformFrequency(values2, 1);

            transformedValues1 = transformedValues1.Zip(transformedValues2, (x, y) => Complex.Conjugate(x) * y).ToArray();  // concatenates corresponding elements of the two input sequences
            return FastFourierTransformFrequency(transformedValues1, -1);
        }
        public Complex[] FastFourierTransformFrequency(Complex[] inputValues, int dir)  // FFT by freq
        {
            Complex[] outputValues = FastFourierTransformFrequencyReversedBit(inputValues, dir);
            ChangeOrder(outputValues, (ulong)outputValues.Length);
            return outputValues;
        }
        private Complex[] FastFourierTransformFrequencyReversedBit(Complex[] a, int dir)
        {
            if (a.Length == 1) return a;
            int N = a.Length;

            Complex wN = Complex.Exp(-dir * 2 * Math.PI * Complex.ImaginaryOne / N);
            Complex w = new Complex(1, 0);
            Complex[] y = new Complex[N];

            Complex[] left = new Complex[N / 2];
            Complex[] right = new Complex[N / 2];

            for (int j = 0; j < N / 2; j++)
            {
                left[j] = a[j] + a[j + N / 2];
                right[j] = (a[j] - a[j + N / 2]) * w;
                w = w * wN;
                operationsCount+=3;
            }

            Complex[] b_left = FastFourierTransformFrequencyReversedBit(left, dir);
            Complex[] b_right = FastFourierTransformFrequencyReversedBit(right, dir);

            if (dir == 1) // -1 = inverse FFT
                for (int j = 0; j < N / 2; j++)
                {
                    y[j] = b_left[j] / 2;
                    y[j + N / 2] = b_right[j] / 2;
                    operationsCount+=2;
                }
            else          
                for (int j = 0; j < N / 2; j++)
                {
                    y[j] = b_left[j];
                    y[j + N / 2] = b_right[j];
                }
            return y;
        }
        private void ChangeOrder(Complex[] Data, ulong len)
        {
            Complex temp;
            if (len <= 2) return;
            ulong r = 0;
            for (ulong x = 1; x < len; x++)
            {
                r = position(r, len);
                if (r > x)
                {
                    temp = Data[x];
                    Data[x] = Data[r];
                    Data[r] = temp;
                }
            }
        }
        private ulong position(ulong r, ulong n) // from rev(x-1) to rev(x) 
        {
            do
            {
                n = n >> 1; // /2
                r = r ^ n;
                operationsCount+=2;
            } while ((r & n) == 0);
            return r;
        }

        public Complex[] FWT(Complex[] inputValues, int dir)
        {
            if (inputValues.Length == 1)  // for break infinite recursion
                return inputValues;

            int N = inputValues.Length;

            Complex[] left = new Complex[N / 2];
            Complex[] right = new Complex[N / 2];
            Complex[] outputVector = new Complex[N];

            for (int j = 0; j < N / 2; j++)
            {
                left[j] = inputValues[j] + inputValues[j + N / 2];
                right[j] = inputValues[j] - inputValues[j + N / 2];
            }

            Complex[] b_left = FWT(left, dir);
            Complex[] b_right = FWT(right, dir);

            if (dir == 1) 
                for (int j = 0; j < N / 2; j++)
                {
                    outputVector[j] = b_left[j] / 2;
                    outputVector[j + N / 2] = b_right[j] / 2;
                }
            else
                for (int j = 0; j < N / 2; j++)
                {
                    outputVector[j] = b_left[j];
                    outputVector[j + N / 2] = b_right[j];
                }
            return outputVector;
        }
    }
}
