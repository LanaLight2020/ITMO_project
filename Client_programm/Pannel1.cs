using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Дополнительные пространства имен
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;


namespace Client_programm
{
    class Pannel1
    {
        int[] chX;
        int[] chY;
        double[] FFTchX;
        double [] FFTchY;
        string dataBaseName;
        int lengthCh;
        //int upperBoarder;
        //int bottomBoarder;

        public Pannel1(string DataBaseName)
        {
            dataBaseName = DataBaseName;
        }

        //Построение графического объекта на основе данных из БД
        public Chart getColumnFromDB(int columnNumber, int bottomBoarder, int upperBoarder, Chart newChart)
        {

            string stringConnection = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=" + dataBaseName + @";Data Source=SVETLANA-BAYAND\SQLEXPRESS";
            SqlConnection myConn = new SqlConnection(stringConnection);
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConn;
            myCommand.CommandText = "SELECT Ch_" + columnNumber + " FROM " + dataBaseName + ".dbo.userData WHERE (ID > " + bottomBoarder + " ) AND (ID < " + upperBoarder + ")";
            myConn.Open();
            SqlDataReader reader = myCommand.ExecuteReader();
            lengthCh = upperBoarder - bottomBoarder + 1;
            chY = new int[lengthCh];
            chX = new int[lengthCh];
            int i = 0;
            while (reader.Read())
            {
                chY[i] = Int32.Parse(reader["Ch_" + columnNumber.ToString()].ToString()) - 32768;
                chX[i] = ++i;
            }
            reader.Close();
            myConn.Close();
            return drawGraphic(newChart);
        }

        private Chart drawGraphic(Chart chart1)
        {
            chart1.Series["Series1"].Points.Clear();

            for (int i = 0; i < lengthCh - 1; i++)
            {
                chart1.Series["Series1"].Points.AddXY(chX[i], chY[i]);
            }
            chart1.Series["Series1"].ChartType = SeriesChartType.FastLine;
            chart1.Series["Series1"].Color = Color.Red;
            return chart1;
        }

        //Расчет БПФ и вывод графика
        public Chart countFFT(Chart newChart)
        {
            double[] x = new double[lengthCh];
            for (int i = 1; i<= lengthCh; i++)
            {
                x[i - 1] = chX[i - 1];
            }
            alglib.complex[] f;
            alglib.fftr1d(x, out f);
            FFTchY = new double[lengthCh / 2];
            FFTchX = new double[lengthCh / 2];
            for (int i = 0; i< lengthCh/2;i++)
            {
                FFTchY[i] = Math.Sqrt(f[i].x * f[i].x + f[i].y * f[i].y)/ lengthCh;
                FFTchX[i] = (double)i / (double)lengthCh * 100000.0;
            }
            return drawFFT(newChart);
        }

        private Chart drawFFT(Chart chart1)
        {
            for (int i = 0; i < lengthCh/2; i++)
            {
                chart1.Series["Series1"].Points.AddXY(FFTchX[i], FFTchY[i]);
            }
            chart1.Series["Series1"].ChartType = SeriesChartType.FastLine;
            chart1.Series["Series1"].Color = Color.Red;
            return chart1;
        }
    }
}
