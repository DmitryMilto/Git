using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Amdahl_s_law
{
    public class AmdahlsLaw
    {
        double a { get; set; }
        double a_min { get; set; }
        double a_max { get; set; }
        double n { get; set; }
        double n_min { get; set; }
        double n_max { get; set; }
        double c_a { get; set; }
        double c_a_min { get; set; }
        double c_a_max { get; set; }
        double c_t { get; set; }
        double c_t_min { get; set; }
        double c_t_max { get; set; }
        double step { get; set; }
        double c { get; set; }
        string operation { get; set; }

        public void R_N_Base(string A, string N_min, string N_max, string Step, string Operation)
        {
            a = Convert.ToDouble(A) / 100;
            n_min = Convert.ToDouble(N_min);
            n_max = Convert.ToDouble(N_max);
            step = Convert.ToDouble(Step);
            operation = Operation;
        }
        public void R_A_Base(string A_min, string A_max, string N, string Step, string Operation)
        {
            a_min = Convert.ToDouble(A_min) / 100;
            a_max = Convert.ToDouble(A_max) / 100;
            n = Convert.ToDouble(N);
            step = Convert.ToDouble(Step) / 100;
            operation = Operation;
        }

        public void R_N_NW(string A, string N_min, string N_max, string Step, string C_a, string C_t, string Operation)
        {
            a = Convert.ToDouble(A) / 100;
            n_min = Convert.ToDouble(N_min);
            n_max = Convert.ToDouble(N_max);
            step = Convert.ToDouble(Step);
            c_a = Convert.ToDouble(C_a);
            c_t = Convert.ToDouble(C_t);
            c = c_a * c_t;
            operation = Operation;
        }
        public void R_A_NW(string A_min, string A_max, string N, string Step, string C_a, string C_t, string Operation)
        {
            a_min = Convert.ToDouble(A_min) / 100;
            a_max = Convert.ToDouble(A_max) / 100;
            n = Convert.ToDouble(N);
            step = Convert.ToDouble(Step);
            c_a = Convert.ToDouble(C_a);
            c_t = Convert.ToDouble(C_t);
            c = c_a * c_t;
            operation = Operation;
        }
        public void R_Ca_NW(string A, string N, string Ca_min, string Ca_max, string C_t, string Step, string Operation)
        {
            a = Convert.ToDouble(A) / 100;
            n = Convert.ToDouble(N);
            c_a_min = Convert.ToDouble(Ca_min);
            c_a_max = Convert.ToDouble(Ca_max);
            c_t = Convert.ToDouble(C_t);
            step = Convert.ToDouble(Step);
            operation = Operation;
        }
        public void R_Ct_NW(string A, string N, string Ca, string Ct_min, string Ct_max, string Step, string Operation)
        {
            a = Convert.ToDouble(A) / 100;
            n = Convert.ToDouble(N);
            c_a = Convert.ToDouble(Ca);
            c_t_min = Convert.ToDouble(Ct_min);
            c_t_max = Convert.ToDouble(Ct_max);
            step = Convert.ToDouble(Step);
            operation = Operation;
        }

        public void ResultText(RichTextBox richTextBox)
        {
            richTextBox.Clear();
            switch (operation)
            {
                case "R_A_Base":
                    richTextBox.Text = RABase();//+
                    break;
                case "R_N_Base":
                    richTextBox.Text = RNBase();//+
                    break;
                case "R_A_NW":
                    richTextBox.Text = RANW();//+
                    break;
                case "R_N_NW":
                    richTextBox.Text = RNWN();//+
                    break;
                case "R_Ca_NW":
                    richTextBox.Text = RCaNW();//+
                    break;
                case "R_Ct_NW":
                    richTextBox.Text = RCtNW();//+
                    break;
            }
        }

        public void ResultGraph(Chart chart)
        {
            double min;
            chart.Series[0].Points.Clear();

            switch (operation)
            {
                case "R_A_Base"://+
                    min = a_min;
                    while (a_max >= min)
                    {
                        chart.Series[0].Points.AddXY(min, 1 / (min + (1 - min) / n));
                        min += step;
                    }
                    break;

                case "R_N_Base"://+
                    min = n_min;
                    while (n_max > min)
                    {
                        chart.Series[0].Points.AddXY(min, 1 / (a + (1 - a) / min));
                        min += step;
                    }
                    break;

                case "R_A_NW"://+
                    min = a_min;
                    while (a_max > min)
                    {
                        chart.Series[0].Points.AddXY(min, 1 / (c + min + (1 - min) / n));
                        min += step;
                    }
                    break;

                case "R_N_NW"://+
                    min = n_min;
                    while (n_max > min)
                    {
                        chart.Series[0].Points.AddXY(min, 1 / (c + a + (1 - a) / min));
                        min += step;
                    }
                    break;

                case "R_Ca_NW"://+
                    min = c_a_min;
                    while (c_a_max >= min)
                    {
                        c = min * c_t;
                        chart.Series[0].Points.AddXY(min, 1 / (c + a + (1 - a) / n));
                        min += step;
                    }
                    break;

                case "R_Ct_NW"://+
                    min = c_t_min;
                    while (c_t_max >= min)
                    {
                        c = min * c_a;
                        chart.Series[0].Points.AddXY(min, 1 / (c + a + (1 - a) / n));
                        min += step;
                    }
                    break;
            }
            
        }

        private String RABase()
        {
            double R;
            double min = a_min;

            string result = "Количество процессоров равна " + n + " \n";
            while (a_max >= min)
            {
                R = 1 / (min + (1 - min) / n);
                result += "R = " + R + " a = " + min * 100 + " % \n";
                min += step;
            }
            return result;
        }
        private String RNBase()
        {
            double R;
            double min = n_min;

            string result = "Доля последовательных вычислений в алгоритме равна " + a * 100 + " % \n";
            while (n_max >= min)
            {
                R = 1 / (a + (1 - a) / min);
                result += "R = " + R + " n = " + min + "\n";
                min += step;
            }
            return result;
        }
        private String RANW()
        {
            double R;
            double min = a_min;

            string result = "Количество процессоров равна " + n + " \n";
            result += "Коэффициент сетевой деградации вычислений равна " + c + "\n";
            while (a_max >= min)
            {
                R = 1 / (c + min + (1 - min) / n);
                result += "R = " + R + " a = " + min * 100 + " % \n";
                min += step;
            }
            return result;
        }
        private String RNWN()
        {
            double R;
            double min = n_min;

            string result = "Доля последовательных вычислений в алгоритме равна " + a * 100 + " % \n";
            result += "Коэффициент сетевой деградации вычислений равна " + c + "\n";
            while (n_max >= min)
            {
                R = 1 / (c + a + (1 - a) / min);
                result += "R = " + R + " n = " + min + "\n";
                min += step;
            }
            return result;
        }
        private String RCaNW()
        {
            double R;
            double min = c_a_min;

            string result = "Доля последовательных вычислений в алгоритме равна " + a * 100 + " % \n";
            result += "Количество процессоров равна " + n + " \n";
            while (c_a_max >= min)
            {
                c = min * c_t;
                R = 1 / (c + a + (1 - a) / n);
                result += "R = " + R + " c = " + c + "\n";
                min += step;
            }
            return result;
        }
        private String RCtNW()
        {
            double R;
            double min = c_t_min;

            string result = "Доля последовательных вычислений в алгоритме равна " + a * 100 + " % \n";
            result += "Количество процессоров равна " + n + " \n";
            while (c_t_max >= min)
            {
                c = min * c_a;
                R = 1 / (c + a + (1 - a) / n);
                result += "R = " + R + " c = " + c + "\n";
                min += step;
            }
            return result;
        }
    }
}
