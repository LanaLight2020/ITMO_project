using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Дополнительные пространства имен
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace Client_programm
{
    public partial class Form1 : Form
    {
        Pannel1 pannel;
        int chosenChannel;
        public Form1()
        {
            InitializeComponent();
            btnsColors();
            chosenChannel = 1;
        }

        private void createDataBase_button_Click(object sender, EventArgs e)
        {
            DataBaseLoading dataBaseLoading = new DataBaseLoading(DataBaseName.Text);
            dataBaseLoading.ReadLoadData();
        }
       

        private void buildGraph_btn_Click(object sender, EventArgs e)
        {
            Pannel1 pannel1 = new Pannel1(DataBaseName.Text);
            chart1 = pannel1.getColumnFromDB(chosenChannel, Int32.Parse(beginRangeTextBox.Text), Int32.Parse(endRangeTextBox.Text), chart1);
            pannel = pannel1;
        }

        private void buildFFTbtn_Click(object sender, EventArgs e)
        {
            chart2 = pannel.countFFT(chart2);
        }

        private void ch_1_Click(object sender, EventArgs e)
        {
            chosenChannel = 1;
            btnsColors();
            ch_1.BackColor = SystemColors.Highlight;
        }

        private void ch_2_Click(object sender, EventArgs e)
        {
            chosenChannel = 2;
            btnsColors();
            ch_2.BackColor = SystemColors.Highlight;
        }

        private void ch_3_Click(object sender, EventArgs e)
        {
            chosenChannel = 3;
            btnsColors();
            ch_3.BackColor = SystemColors.Highlight;
        }

        private void ch_4_Click(object sender, EventArgs e)
        {
            chosenChannel = 4;
            btnsColors();
            ch_4.BackColor = SystemColors.Highlight;
        }

        private void ch_5_Click(object sender, EventArgs e)
        {
            chosenChannel = 5;
            btnsColors();
            ch_5.BackColor = SystemColors.Highlight;
        }

        private void ch_6_Click(object sender, EventArgs e)
        {
            chosenChannel = 6;
            btnsColors();
            ch_6.BackColor = SystemColors.Highlight;
        }

        private void ch_7_Click(object sender, EventArgs e)
        {
            chosenChannel = 7;
            btnsColors();
            ch_7.BackColor = SystemColors.Highlight;
        }

        private void ch_8_Click(object sender, EventArgs e)
        {
            chosenChannel = 8;
            btnsColors();
            ch_8.BackColor = SystemColors.Highlight;
        }

        private void ch_9_Click(object sender, EventArgs e)
        {
            chosenChannel = 9;
            btnsColors();
            ch_9.BackColor = SystemColors.Highlight;
        }

        private void ch_10_Click(object sender, EventArgs e)
        {
            chosenChannel = 10;
            btnsColors();
            ch_10.BackColor = SystemColors.Highlight;
        }

        private void ch_11_Click(object sender, EventArgs e)
        {
            chosenChannel = 11;
            btnsColors();
            ch_11.BackColor = SystemColors.Highlight;
        }

        private void ch_12_Click(object sender, EventArgs e)
        {
            chosenChannel = 12;
            btnsColors();
            ch_12.BackColor = SystemColors.Highlight;
        }

        private void ch_13_Click(object sender, EventArgs e)
        {
            chosenChannel = 13;
            btnsColors();
            ch_13.BackColor = SystemColors.Highlight;
        }

        private void ch_14_Click(object sender, EventArgs e)
        {
            chosenChannel = 14;
            btnsColors();
            ch_14.BackColor = SystemColors.Highlight;
        }

        private void ch_15_Click(object sender, EventArgs e)
        {
            chosenChannel = 15;
            btnsColors();
            ch_15.BackColor = SystemColors.Highlight;
        }

        private void ch_16_Click(object sender, EventArgs e)
        {
            chosenChannel = 16;
            btnsColors();
            ch_16.BackColor = SystemColors.Highlight;
        }

        private void ch_17_Click(object sender, EventArgs e)
        {
            chosenChannel = 17;
            btnsColors();
            ch_17.BackColor = SystemColors.Highlight;
        }

        private void ch_18_Click(object sender, EventArgs e)
        {
            chosenChannel = 18;
            btnsColors();
            ch_18.BackColor = SystemColors.Highlight;
        }

        private void ch_19_Click(object sender, EventArgs e)
        {
            chosenChannel = 19;
            btnsColors();
            ch_19.BackColor = SystemColors.Highlight;
        }

        private void ch_20_Click(object sender, EventArgs e)
        {
            chosenChannel = 20;
            btnsColors();
            ch_20.BackColor = SystemColors.Highlight;
        }

        private void ch_21_Click(object sender, EventArgs e)
        {
            chosenChannel = 21;
            btnsColors();
            ch_21.BackColor = SystemColors.Highlight;
        }

        private void ch_22_Click(object sender, EventArgs e)
        {
            chosenChannel = 22;
            btnsColors();
            ch_22.BackColor = SystemColors.Highlight;
        }

        private void ch_23_Click(object sender, EventArgs e)
        {
            chosenChannel = 23;
            btnsColors();
            ch_23.BackColor = SystemColors.Highlight;
        }

        private void ch_24_Click(object sender, EventArgs e)
        {
            chosenChannel = 24;
            btnsColors();
            ch_24.BackColor = SystemColors.Highlight;
        }

        private void ch_25_Click(object sender, EventArgs e)
        {
            chosenChannel = 25;
            btnsColors();
            ch_25.BackColor = SystemColors.Highlight;
        }

        private void ch_26_Click(object sender, EventArgs e)
        {
            chosenChannel = 26;
            btnsColors();
            ch_26.BackColor = SystemColors.Highlight;
        }

        private void ch_27_Click(object sender, EventArgs e)
        {
            chosenChannel = 27;
            btnsColors();
            ch_27.BackColor = SystemColors.Highlight;
        }

        private void ch_28_Click(object sender, EventArgs e)
        {
            chosenChannel = 28;
            btnsColors();
            ch_28.BackColor = SystemColors.Highlight;
        }

        private void ch_29_Click(object sender, EventArgs e)
        {
            chosenChannel = 29;
            btnsColors();
            ch_29.BackColor = SystemColors.Highlight;
        }

        private void ch_30_Click(object sender, EventArgs e)
        {
            chosenChannel = 30;
            btnsColors();
            ch_30.BackColor = SystemColors.Highlight;
        }

        private void ch_31_Click(object sender, EventArgs e)
        {
            chosenChannel = 31;
            btnsColors();
            ch_31.BackColor = SystemColors.Highlight;
        }

        private void ch_32_Click(object sender, EventArgs e)
        {
            chosenChannel = 32;
            btnsColors();
            ch_32.BackColor = SystemColors.Highlight;
        }

        private void ch_33_Click(object sender, EventArgs e)
        {
            chosenChannel = 33;
            btnsColors();
            ch_33.BackColor = SystemColors.Highlight;
        }

        private void ch_34_Click(object sender, EventArgs e)
        {
            chosenChannel = 34;
            btnsColors();
            ch_34.BackColor = SystemColors.Highlight;
        }

        private void ch_35_Click(object sender, EventArgs e)
        {
            chosenChannel = 35;
            btnsColors();
            ch_35.BackColor = SystemColors.Highlight;
        }

        private void ch_36_Click(object sender, EventArgs e)
        {
            chosenChannel = 36;
            btnsColors();
            ch_36.BackColor = SystemColors.Highlight;
        }

        private void ch_37_Click(object sender, EventArgs e)
        {
            chosenChannel = 37;
            btnsColors();
            ch_37.BackColor = SystemColors.Highlight;
        }

        private void ch_38_Click(object sender, EventArgs e)
        {
            chosenChannel = 38;
            btnsColors();
            ch_38.BackColor = SystemColors.Highlight;
        }

        private void ch_39_Click(object sender, EventArgs e)
        {
            chosenChannel = 39;
            btnsColors();
            ch_39.BackColor = SystemColors.Highlight;
        }

        private void ch_40_Click(object sender, EventArgs e)
        {
            chosenChannel = 40;
            btnsColors();
            ch_40.BackColor = SystemColors.Highlight;
        }

        private void ch_41_Click(object sender, EventArgs e)
        {
            chosenChannel = 41;
            btnsColors();
            ch_41.BackColor = SystemColors.Highlight;
        }

        private void ch_42_Click(object sender, EventArgs e)
        {
            chosenChannel = 42;
            btnsColors();
            ch_42.BackColor = SystemColors.Highlight;
        }

        private void ch_43_Click(object sender, EventArgs e)
        {
            chosenChannel = 43;
            btnsColors();
            ch_43.BackColor = SystemColors.Highlight;
        }

        private void ch_44_Click(object sender, EventArgs e)
        {
            chosenChannel = 44;
            btnsColors();
            ch_44.BackColor = SystemColors.Highlight;
        }

        private void ch_45_Click(object sender, EventArgs e)
        {
            chosenChannel = 45;
            btnsColors();
            ch_45.BackColor = SystemColors.Highlight;
        }

        private void ch_46_Click(object sender, EventArgs e)
        {
            chosenChannel = 46;
            btnsColors();
            ch_46.BackColor = SystemColors.Highlight;
        }

        private void ch_47_Click(object sender, EventArgs e)
        {
            chosenChannel = 47;
            btnsColors();
            ch_47.BackColor = SystemColors.Highlight;
        }

        private void ch_48_Click(object sender, EventArgs e)
        {
            chosenChannel = 48;
            btnsColors();
            ch_48.BackColor = SystemColors.Highlight;
        }

        private void btnsColors()
        {
            ch_1.BackColor = SystemColors.GradientActiveCaption;
            ch_2.BackColor = SystemColors.GradientActiveCaption;
            ch_3.BackColor = SystemColors.GradientActiveCaption;
            ch_4.BackColor = SystemColors.GradientActiveCaption;
            ch_5.BackColor = SystemColors.GradientActiveCaption;
            ch_6.BackColor = SystemColors.GradientActiveCaption;
            ch_7.BackColor = SystemColors.GradientActiveCaption;
            ch_8.BackColor = SystemColors.GradientActiveCaption;
            ch_9.BackColor = SystemColors.GradientActiveCaption;
            ch_10.BackColor = SystemColors.GradientActiveCaption;
            ch_11.BackColor = SystemColors.GradientActiveCaption;
            ch_12.BackColor = SystemColors.GradientActiveCaption;
            ch_13.BackColor = SystemColors.GradientActiveCaption;
            ch_14.BackColor = SystemColors.GradientActiveCaption;
            ch_15.BackColor = SystemColors.GradientActiveCaption;
            ch_16.BackColor = SystemColors.GradientActiveCaption;
            ch_17.BackColor = SystemColors.GradientActiveCaption;
            ch_18.BackColor = SystemColors.GradientActiveCaption;
            ch_19.BackColor = SystemColors.GradientActiveCaption;
            ch_20.BackColor = SystemColors.GradientActiveCaption;
            ch_21.BackColor = SystemColors.GradientActiveCaption;
            ch_22.BackColor = SystemColors.GradientActiveCaption;
            ch_23.BackColor = SystemColors.GradientActiveCaption;
            ch_24.BackColor = SystemColors.GradientActiveCaption;
            ch_25.BackColor = SystemColors.GradientActiveCaption;
            ch_26.BackColor = SystemColors.GradientActiveCaption;
            ch_27.BackColor = SystemColors.GradientActiveCaption;
            ch_28.BackColor = SystemColors.GradientActiveCaption;
            ch_29.BackColor = SystemColors.GradientActiveCaption;
            ch_30.BackColor = SystemColors.GradientActiveCaption;
            ch_31.BackColor = SystemColors.GradientActiveCaption;
            ch_32.BackColor = SystemColors.GradientActiveCaption;
            ch_33.BackColor = SystemColors.GradientActiveCaption;
            ch_34.BackColor = SystemColors.GradientActiveCaption;
            ch_35.BackColor = SystemColors.GradientActiveCaption;
            ch_36.BackColor = SystemColors.GradientActiveCaption;
            ch_37.BackColor = SystemColors.GradientActiveCaption;
            ch_38.BackColor = SystemColors.GradientActiveCaption;
            ch_39.BackColor = SystemColors.GradientActiveCaption;
            ch_40.BackColor = SystemColors.GradientActiveCaption;
            ch_41.BackColor = SystemColors.GradientActiveCaption;
            ch_42.BackColor = SystemColors.GradientActiveCaption;
            ch_43.BackColor = SystemColors.GradientActiveCaption;
            ch_44.BackColor = SystemColors.GradientActiveCaption;
            ch_45.BackColor = SystemColors.GradientActiveCaption;
            ch_46.BackColor = SystemColors.GradientActiveCaption;
            ch_47.BackColor = SystemColors.GradientActiveCaption;
            ch_48.BackColor = SystemColors.GradientActiveCaption;
        }

        
    }
}
