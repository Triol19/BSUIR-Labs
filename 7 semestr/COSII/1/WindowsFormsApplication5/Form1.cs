using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Numerics;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        FourierTransform fourierTransform;

        public Form1()
        {
            InitializeComponent();

            originalGraphic.Series[0].ChartType = SeriesChartType.Spline;
            inverseGraphic.Series[0].ChartType = SeriesChartType.Spline;
            magnitudeGraphic.Series[0].ChartType = SeriesChartType.Spline;

            fastMagnitudeGraphic.Series[0].ChartType = SeriesChartType.Spline;
            fastInverseGraphic.Series[0].ChartType = SeriesChartType.Spline;

            //pointsCountTextBox.Text = "64";

            originalGraphic.Series[0].IsVisibleInLegend = false;
            inverseGraphic.Series[0].IsVisibleInLegend = false;
            magnitudeGraphic.Series[0].IsVisibleInLegend = false;
            fastMagnitudeGraphic.Series[0].IsVisibleInLegend = false;
            fastInverseGraphic.Series[0].IsVisibleInLegend = false;

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            int pointsCount;

            try
            {
                pointsCount = int.Parse(pointsCountTextBox.Text);

                /*if (Math.Log(pointsCount, 2) != Math.Round(Math.Log(pointsCount, 2)))
                    throw (new Exception("Введено число не по основанию 2"));

                if (pointsCount <= 1)
                    throw (new Exception("Количество отсчётов <= 1"));

                if (pointsCount > int.MaxValue)
                    throw (new Exception("Количество отсчётов больне INTMAX"));
                */

                originalGraphic.Series[0].Points.Clear();
                inverseGraphic.Series[0].Points.Clear();
                magnitudeGraphic.Series[0].Points.Clear();

                fastMagnitudeGraphic.Series[0].Points.Clear();
                fastInverseGraphic.Series[0].Points.Clear();

                fourierTransform = new FourierTransform();
                DiscreteFourierTransform(pointsCount);
                this.originalGraphic.Show();
                this.magnitudeGraphic.Show();
                this.inverseGraphic.Show();
                FastDiscreteFourierTransform(pointsCount);
                this.fastMagnitudeGraphic.Show();
                this.fastInverseGraphic.Show();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void DiscreteFourierTransform(int pointsCount)
        {
            Complex[] resultArray = new Complex[pointsCount];
            Complex[] array = fourierTransform.CreatePointsArray(pointsCount);  // vector 

            for (int i = 0; i < pointsCount; i++)
                originalGraphic.Series[0].Points.AddXY(i, array[i].Real);

            resultArray = fourierTransform.DiscreteFourierTransform(array);

            DFTLabel.Text = "Nubmer of DFT: " + fourierTransform.GetOperationsCount().ToString();
            DFTLabel.Show();

            for (int i = 0; i < pointsCount; i++)
                magnitudeGraphic.Series[0].Points.AddXY(i, resultArray[i].Magnitude);

            resultArray = fourierTransform.InverseDiscreteFourierTransform(resultArray);

            for (int i = 0; i < pointsCount; i++)
                inverseGraphic.Series[0].Points.AddXY(i, resultArray[i].Real); 
        }

        private void FastDiscreteFourierTransform(int pointsCount)
        {
            Complex[] resultArray = new Complex[pointsCount];
            Complex[] array = fourierTransform.CreatePointsArray(pointsCount);

            fourierTransform.ResetOperationsCount();  // reset count of operations
            resultArray = fourierTransform.FastFourierTransform(array);

            for (int i = 0; i < pointsCount; i++)
                fastMagnitudeGraphic.Series[0].Points.AddXY(i, resultArray[i].Magnitude);

            FFTLabel.Text = "Nubmer of FFT: " + fourierTransform.GetOperationsCount().ToString();
            FFTLabel.Show();

            resultArray = fourierTransform.InverseFastFourierTransform(resultArray);

            for (int i = 0; i < pointsCount; i++)
                fastInverseGraphic.Series[0].Points.AddXY(i, resultArray[i].Real);
        }

        /*private void pointsCountTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                startButton_Click(sender, e);
            }
        }*/
    }
}
