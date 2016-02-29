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
    class FourierTransform
    {
        int operationsCount = 0;
        int stopNumber;

        public Complex[] CreatePointsArray(int pointsCount)  // get vector of 32 dots 
        {
            double stepValue = 2 * Math.PI / pointsCount;
            double argumentValue = 0;
            Complex[] pointsArray = new Complex[pointsCount];

            for (int i = 0; i < pointsCount; i++)
            {
                pointsArray[i] = Complex.Cos(argumentValue * 2) + Complex.Sin(argumentValue * 5);
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
                    resultArray[i] += inputArray[j] * Complex.Exp(-1 * Complex.ImaginaryOne * 2 * Math.PI * j * i / pointsCount);
                    operationsCount++;
			// i = index of frequency
			//result = complex aplitude 
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

                resultArray[i] /= pointsCount;  // 1/N
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
    }
}
