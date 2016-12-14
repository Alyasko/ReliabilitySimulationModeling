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
using Lab_1.Model;

namespace Lab_1
{
    public partial class MainForm : Form
    {
        private ReliabilityAssessor _reliabilityAssessor;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _reliabilityAssessor = new ReliabilityAssessor();

            //// Data arrays.
            //string[] seriesArray = { "Cats", "Dogs" };
            //int[] pointsArray = { 1, 2 };

            //// Set palette.
            //plotView.Palette = ChartColorPalette.SeaGreen;


            //// Set title.
            //plotView.Titles.Add("Pets");

            //// Add series.
            //for (int i = 0; i < seriesArray.Length; i++)
            //{
            //    // Add series.
            //    Series series = plotView.Series.Add(seriesArray[i]);

            //    // Add point.
            //    series.Points.Add(pointsArray[i]);
            //}
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            plotView.Series.Clear();

            InputConfig inputConfig = ReadInputConfig();

            PlotType plotType = GetPlotType();

            if (plotType == PlotType.Undefined)
            {
                MessageBox.Show("Please, select plot type", "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                IDictionary<string, PointF[]> data = _reliabilityAssessor.CalculatePlot(plotType, inputConfig);

                DrawPlot(data, plotType);
                rtbOutput.Text = _reliabilityAssessor.Output;
            }
        }

        private void DrawPlot(IDictionary<string, PointF[]> data, PlotType plotType)
        {
            List<string> seriesArray = new List<string>(data.Keys);

            for (int i = 0; i < seriesArray.Count; i++)
            {
                string seriesName = seriesArray[i];
                Series series = new Series(seriesName);
                series.ChartType = SeriesChartType.Line;
                plotView.Series.Add(series);

                PointF[] points = data[seriesName];
                for (int j = 0; j < points.Length; j++)
                {
                    series.Points.AddXY(data[seriesName][j].X, data[seriesName][j].Y);
                }
            }
        }

        private PlotType GetPlotType()
        {
            sbyte selectedIndex = (sbyte)cmbPlotType.SelectedIndex;

            PlotType plotType = (PlotType)selectedIndex;

            return plotType;
        }

        private InputConfig ReadInputConfig()
        {
            InputConfig inputConfig = new InputConfig();

            Decimal multiMinusEight = (decimal)(Math.Pow(10, -8));
            Decimal multiFour = 10000m;
            //Decimal multiThree = 1000m;
            Decimal multiTwo = 100m;

            inputConfig.FailureRate1 = nudFailureRate1.Value  * multiMinusEight;
            inputConfig.FailureRate2 = nudFailureRate2.Value * multiMinusEight;
            inputConfig.FailureRate3 = nudFailureRate3.Value * multiMinusEight;
            inputConfig.FailureRate4 = nudFailureRate4.Value * multiMinusEight;

            inputConfig.AdditionalAlpha = nudAdditionalAlpha.Value;
            inputConfig.AdditionalBeta = nudAdditionalBeta.Value * 10;
            inputConfig.AdditionalTime = nudAdditionalTime.Value * multiFour;
            inputConfig.AdditionalGama = nudAdditionalGama.Value;
            inputConfig.AdditionalDeltaTime = nudAdditionalDeltaTime.Value;

            inputConfig.EnvironmentCoeffTemperature = nudEnvironmentCoeffTemperature.Value;
            inputConfig.EnvironmentCoeffVibration = nudEnvironmentCoeffVibration.Value;
            inputConfig.EnvironmentCoeffOverload = nudEnvironmentCoeffOverload.Value;

            inputConfig.StorageTime = nudStorageTime.Value * multiFour;
            inputConfig.StorageG = nudStorageG.Value * multiTwo;

            inputConfig.CyclingTime = nudCyclingTime.Value * multiFour;
            inputConfig.CyclingR = nudCyclingR.Value;

            inputConfig.L2LamdaI = nudL2LamdaI.Value;
            inputConfig.L2N = nudL2N.Value;
            inputConfig.L2LamdaME = nudL2LamdaME.Value;
            inputConfig.L2LamdaNP = nudL2LamdaNP.Value;
            inputConfig.L2LamdaOP = nudL2LamdaOP.Value;
            inputConfig.L2LamdaPU = nudL2LamdaPU.Value;
            inputConfig.L2T = nudL2LamdaT.Value;
            inputConfig.L2M = nudL2M.Value;

            return inputConfig;
        }
    }
}
