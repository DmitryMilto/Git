using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Amdahl_s_law
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chartGraph.Visible = radioButtonGraph.Checked;
            richResultBase.Visible = radioButtonText.Checked;
            chartGraphNetWork.Visible = radioGraphNetWork.Checked;
            richTextNetwork.Visible = radioRusiltNetWork.Checked;
        }

        private void calculateBasicLaw_Click(object sender, EventArgs e)
        {
            AmdahlsLawBase amdahlsLaw = new AmdahlsLawBase(textBoxABase.Text.ToString(),
                textBoxNMinBase.Text.ToString(), textBoxNMaxBase.Text.ToString(), textBoxStepBase.Text.ToString());

            amdahlsLaw.ResultText(richResultBase);
            amdahlsLaw.ResultGraph(chartGraph);
        }

        private void radioButtonGraph_CheckedChanged(object sender, EventArgs e)
        {
            chartGraph.Visible = radioButtonGraph.Checked;
        }

        private void radioButtonText_CheckedChanged(object sender, EventArgs e)
        {
            richResultBase.Visible = radioButtonText.Checked;
        }

        private void buttonNetWork_Click(object sender, EventArgs e)
        {
            AmdahlsLawBase amdahlsLaw = new AmdahlsLawBase(textBoxANetWork.Text.ToString(),
                textBoxNMinNetWork.Text.ToString(), textBoxNMaxNetWork.Text.ToString(), textBoxStepNetWork.Text.ToString(),
                textBoxCaNetWork.Text.ToString(), textBoxCtNetWork.Text.ToString());

            amdahlsLaw.ResultTextNetWork(richTextNetwork);
            amdahlsLaw.ResultGraphNetWork(chartGraphNetWork);
        }

        private void radioGraphNetWork_CheckedChanged(object sender, EventArgs e)
        {
            chartGraphNetWork.Visible = radioGraphNetWork.Checked;
        }

        private void radioRusiltNetWork_CheckedChanged(object sender, EventArgs e)
        {
            richTextNetwork.Visible = radioRusiltNetWork.Checked;
        }
    }

    public class AmdahlsLawBase
    {
        double a { get; set; }
        double a_min { get; set; }
        double a_max { get; set; }
        double n_min { get; set; }
        double n_max { get; set; }
        double step { get; set; }
        double c_a { get; set; }
        double c_a_min { get; set; }
        double c_a_max { get; set; }
        double c_t { get; set; }
        double c_t_min { get; set; }
        double c_t_max { get; set; }
        double c { get; set; }

        public AmdahlsLawBase(string A, string N_min, string N_max, string Step)
        {
            a = Convert.ToDouble(A) / 100;
            n_min = Convert.ToDouble(N_min);
            n_max = Convert.ToDouble(N_max);
            step = Convert.ToDouble(Step);
        }
        public AmdahlsLawBase(string A, string N_min, string N_max, string Step, string C_a, string C_t)
        {
            a = Convert.ToDouble(A) / 100;
            n_min = Convert.ToDouble(N_min);
            n_max = Convert.ToDouble(N_max);
            step = Convert.ToDouble(Step);
            c_a = Convert.ToDouble(C_a);
            c_t = Convert.ToDouble(C_t);
            c = c_a * c_t;
        }

        public void ResultText(RichTextBox richTextBox)
        {
            double R;
            double min = n_min;
            richTextBox.Clear();
            richTextBox.Text = "Доля последовательных вычислений в алгоритме равна " + a * 100 + " % \n";
            while (n_max > min)
            {
                R = 1 / (a + (1 - a) / min);
                richTextBox.Text += "R = " + R + " n = " + min + "\n";
                min += step;
            }
        }
        public void ResultGraph(Chart chart)
        {
            double R;
            double min = n_min;
            chart.Series[0].Points.Clear();
            while (n_max > min)
            {
                R = 1 / (a + (1 - a) / min);
                chart.Series[0].Points.AddXY(min, R);
                min += step;
            }
        }
        public void ResultTextNetWork(RichTextBox richTextBox)
        {
            double R;
            double min = n_min;
            richTextBox.Clear();
            richTextBox.Text = "Доля последовательных вычислений в алгоритме равна " + a * 100 + " % \n";
            richTextBox.Text += "Коэффициент сетевой деградации вычислений равна " + c + "\n";
            while (n_max > min)
            {
                R = 1 / (c + a + (1 - a) / min);
                richTextBox.Text += "R = " + R + " n = " + min + "\n";
                min += step;
            }
        }
        public void ResultGraphNetWork(Chart chart)
        {
            double R;
            double min = n_min;
            chart.Series[0].Points.Clear();
            while (n_max > min)
            {
                R = 1 / (c + a + (1 - a) / min);
                chart.Series[0].Points.AddXY(min, R);
                min += step;
            }
        }
    }
}
