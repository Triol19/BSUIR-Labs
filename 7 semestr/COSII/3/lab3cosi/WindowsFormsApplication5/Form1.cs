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

            originalGraphic.Series[0].ChartType = SeriesChartType.Line;  // Spline for smooth (сглаживания)
            FWTGraphic.Series[0].ChartType = SeriesChartType.Line;
            IFWTGraphic.Series[0].ChartType = SeriesChartType.Line;

            originalGraphic.Series[0].IsVisibleInLegend = false;
            FWTGraphic.Series[0].IsVisibleInLegend = false;
            IFWTGraphic.Series[0].IsVisibleInLegend = false;
        }

        private Complex FunctionY(Complex x)
        {
            return Complex.Sin(5*x) + Complex.Cos(2*x);
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

                originalGraphic.Series[0].Points.Clear();
                FWTGraphic.Series[0].Points.Clear();
                IFWTGraphic.Series[0].Points.Clear();

                fourierTransform = new FourierTransform();

                Complex[] arrayY = fourierTransform.CreatePointsArray(pointsCount, FunctionY); 
                Draw(pointsCount, arrayY, originalGraphic);

                Complex[] valuesVector = fourierTransform.FWT(arrayY, 1); //FWT
                Draw(pointsCount, valuesVector, FWTGraphic);

                valuesVector = fourierTransform.FWT(valuesVector, -1); //IFWT
                Draw(pointsCount, valuesVector, IFWTGraphic);
                
                this.originalGraphic.Show();
                this.FWTGraphic.Show();
                this.IFWTGraphic.Show();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
