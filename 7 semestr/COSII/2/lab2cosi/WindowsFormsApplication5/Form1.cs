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

            originalYGraphic.Series[0].ChartType = SeriesChartType.Line;  // Spline for smooth (сглаживания)
            originalY2Graphic.Series[0].ChartType = SeriesChartType.Line;
            originalZGraphic.Series[0].ChartType = SeriesChartType.Line;
            convolutionGraphic.Series[0].ChartType = SeriesChartType.Line;
            correlationGraphic.Series[0].ChartType = SeriesChartType.Line;
            correlationFFTGraphic.Series[0].ChartType = SeriesChartType.Line;
            convolutionFFTGraphic.Series[0].ChartType = SeriesChartType.Line;

            originalYGraphic.Series[0].IsVisibleInLegend = false;
            originalY2Graphic.Series[0].IsVisibleInLegend = false;
            originalZGraphic.Series[0].IsVisibleInLegend = false;
            convolutionFFTGraphic.Series[0].IsVisibleInLegend = false;
            convolutionGraphic.Series[0].IsVisibleInLegend = false;
            correlationGraphic.Series[0].IsVisibleInLegend = false;
            correlationFFTGraphic.Series[0].IsVisibleInLegend = false;
        }

        private Complex FunctionY(Complex x)
        {
            return Complex.Sin(5*x) + Complex.Cos(2*x);
        }

        private Complex FunctionZ(Complex x)
        {
            return Complex.Sin(5*x);
        }
        private Complex FunctionY2(Complex x)
        {
            return Complex.Cos(2 * x);
        }

        private void Draw(int pointsCount, Complex[] array, Chart graph)
        {
            for (int i = 0; i < pointsCount; i++)
                graph.Series[0].Points.AddXY(i, array[i].Real);
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            int pointsCount;

            try
            {
                pointsCount = int.Parse(pointsCountTextBox.Text);

                originalYGraphic.Series[0].Points.Clear();
                originalY2Graphic.Series[0].Points.Clear();
                originalZGraphic.Series[0].Points.Clear();
                convolutionFFTGraphic.Series[0].Points.Clear();
                convolutionGraphic.Series[0].Points.Clear();
                correlationGraphic.Series[0].Points.Clear();
                correlationFFTGraphic.Series[0].Points.Clear();

                fourierTransform = new FourierTransform();

                Complex[] arrayY = fourierTransform.CreatePointsArray(pointsCount, FunctionY);  // graph y
                Draw(pointsCount, arrayY, originalYGraphic);

                Complex[] arrayY2 = fourierTransform.CreatePointsArray(pointsCount, FunctionY2);  // graph y2
                Draw(pointsCount, arrayY2, originalY2Graphic);

                Complex[] arrayZ = fourierTransform.CreatePointsArray(pointsCount, FunctionZ);  // graph z
                Draw(pointsCount, arrayZ, originalZGraphic);

                Complex[] values = fourierTransform.Convolution(arrayY, arrayY2);  // conv(свёртка) y + y2
                Draw(pointsCount, values, convolutionGraphic);
                ConLabel.Text = "Nubmer of con and cor: " + fourierTransform.GetOperationsCount().ToString();
                fourierTransform.ResetOperationsCount();
                ConLabel.Show();

                values = fourierTransform.Correlation(arrayY, arrayZ);  // cor y + z
                Draw(pointsCount, values, correlationGraphic);

                values = fourierTransform.ConvolutionFFT(arrayY, arrayY2);  // conv(свёртка) y + y2 FFT
                Draw(pointsCount, values, convolutionFFTGraphic);
                FFTConLabel.Text = "Nubmer of con and cor FFT: " + (fourierTransform.GetOperationsCount()*2).ToString();
                fourierTransform.ResetOperationsCount();
                FFTConLabel.Show();

                values = fourierTransform.CorrelationFFT(arrayY, arrayZ);  // cor y + z FFT
                Draw(pointsCount, values, correlationFFTGraphic);
                fourierTransform.ResetOperationsCount();
                
                this.originalYGraphic.Show();
                this.originalY2Graphic.Show();
                this.originalZGraphic.Show();
                this.convolutionGraphic.Show();
                this.correlationGraphic.Show();
                this.convolutionFFTGraphic.Show();
                this.correlationFFTGraphic.Show();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
