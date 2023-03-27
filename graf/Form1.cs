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
namespace graf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            chart1.Series.Clear(); // очищаем все предыдущие графики

            double xMin = 0.1; 
            double xMax = 10;

            Series series = new Series("График функции"); // создаем новую серию для графика
            series.ChartType = SeriesChartType.FastLine; // устанавливаем тип графика

            for (double x = xMin; x <= xMax; x += 0.01)

            {
                double y = (Math.Pow(x, 4) - 3 * Math.Pow(x, 3) - 2 * Math.Pow(x, 2)) / Math.Sqrt(Math.Pow(x, 2) - 8 * x + 16);
                if (Double.IsNaN(y) || Double.IsInfinity(y))
                {
                    // Если значение функции не является числом или бесконечностью, пропустить его
                    continue;
                }
                series.Points.AddXY(x, y); //добавление точки на график
            }

            // Добавляем серию данных на график и задаем основные параметры
            chart1.Series.Add(series);
            chart1.ChartAreas[0].AxisX.Minimum = xMin;
            chart1.ChartAreas[0].AxisX.Maximum = xMax;
            chart1.ChartAreas[0].AxisX.Title = "Y";
            chart1.ChartAreas[0].AxisY.Title = "X";

            chart1.Titles.Clear();
            chart1.Titles.Add("График функции y = x^4 - 3x^3 - 2x^2 / корень(x^2 - 8x + 16)");
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //обрабатываю исключение
            try { 

            double xMin = -4.5;
            double xMax = 4.5;

            Series series = new Series("График функции"); 
            series.ChartType = SeriesChartType.FastLine; 

            for (double x = xMin; x <= xMax; x += 0.01)
            {
                double ctg1 = 1.0 / Math.Tan(x + Math.PI / 2);
                double ctg2 = 1.0 / Math.Tan(x - Math.PI / 2);
                double y = Math.Pow(ctg1, 2) * Math.Pow(Math.Cos(x - Math.PI / 2), 2) / Math.Pow(ctg2, 2) - Math.Pow(Math.Cos(x + Math.PI / 2), 2);
                if (Double.IsNaN(y) || Double.IsInfinity(y))
                {
                    continue;
                }
                series.Points.AddXY(x, y);
            }

            chart1.Series.Add(series);
            chart1.ChartAreas[0].AxisX.Minimum = xMin;
            chart1.ChartAreas[0].AxisX.Maximum = xMax;
            chart1.ChartAreas[0].AxisX.Title = "X";
            chart1.ChartAreas[0].AxisY.Title = "Y";

            chart1.Titles.Clear();
            chart1.Titles.Add("График функции ctg(x+π/2)^2 * cos(x-π/2)^2 / ctg(x-π/2)^2 - cos(x+π/2)^2");

            chart1.Invalidate(); // перерисовка графика
        }
            catch (ArgumentException ex)
        {
         MessageBox.Show("Ошибка при построении графика: " + ex.Message);
        }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();

            double xMin = -11; 
            double xMax = 11; 

            Series series = new Series("График функции"); 
            series.ChartType = SeriesChartType.Point; // устанавливаем тип графика
            series.Color = Color.Blue; 
            series.BorderWidth = 2; 

            for (double x = xMin; x <= xMax; x += 0.1) 
            {
                double y = Math.Sqrt(169 - Math.Pow(x, 2) * 169 / 121);
                series.Points.AddXY(x, y);

                y = -Math.Sqrt(169 - Math.Pow(x, 2) * 169 / 121);
                series.Points.AddXY(x, y); 
            }

            chart1.Series.Add(series);
            chart1.ChartAreas[0].AxisX.Minimum = xMin;
            chart1.ChartAreas[0].AxisX.Maximum = xMax;
            chart1.ChartAreas[0].AxisX.Title = "X";
            chart1.ChartAreas[0].AxisY.Title = "Y";
            chart1.Titles.Clear();
            chart1.Titles.Add("График функции y = (x^2/a) + (y^2/b) = 1");

        }
    }
}
