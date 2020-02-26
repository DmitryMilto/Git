using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Amdahl_s_law
{
    public partial class Form1 : Form
    {
        private void radioButtonGraph_CheckedChanged(object sender, EventArgs e)
        {
            chartGraph.Visible = radioButtonGraph.Checked;
        }
        private void radioButtonText_CheckedChanged(object sender, EventArgs e)
        {
            richResultBase.Visible = radioButtonText.Checked;
        }
        private void radioGraphNetWork_CheckedChanged(object sender, EventArgs e)
        {
            chartGraphNetWork.Visible = radioGraphNetWork.Checked;
        }
        private void radioRusiltNetWork_CheckedChanged(object sender, EventArgs e)
        {
            richTextNetwork.Visible = radioRusiltNetWork.Checked;
        }
        private void radioRABase_CheckedChanged(object sender, EventArgs e)
        {
            groupRABase.Visible = radioRABase.Checked;
        }
        private void radioRNBase_CheckedChanged(object sender, EventArgs e)
        {
            groupRNBase.Visible = radioRNBase.Checked;
        }
        private void radioRANw_CheckedChanged(object sender, EventArgs e)
        {
            groupRaNW.Visible = radioRANw.Checked;
        }
        private void radioRNNw_CheckedChanged(object sender, EventArgs e)
        {
            groupRnNW.Visible = radioRNNw.Checked;
        }
        private void radioRCaNw_CheckedChanged(object sender, EventArgs e)
        {
            groupRCaNW.Visible = radioRCaNw.Checked;
        }
        private void radioRCtNw_CheckedChanged(object sender, EventArgs e)
        {
            groupRCtNW.Visible = radioRCtNw.Checked;
        }
        public Form1()
        {
            InitializeComponent();
            chartGraph.Visible = radioButtonGraph.Checked;
            richResultBase.Visible = radioButtonText.Checked;
            chartGraphNetWork.Visible = radioGraphNetWork.Checked;
            richTextNetwork.Visible = radioRusiltNetWork.Checked;

            groupRABase.Visible = radioRABase.Checked;
            groupRNBase.Visible = radioRNBase.Checked;

            groupRaNW.Visible = radioRANw.Checked;
            groupRnNW.Visible = radioRNNw.Checked;
            groupRCaNW.Visible = radioRCaNw.Checked;
            groupRCtNW.Visible = radioRCtNw.Checked;
        }

        private void calculateBasicLaw_Click(object sender, EventArgs e)
        {
            AmdahlsLaw amdahlsLaw = new AmdahlsLaw();

            if (radioRNBase.Checked)
                amdahlsLaw.R_N_Base(textABase.Text.ToString(),
                    textNMinBase.Text.ToString(), textNMaxBase.Text.ToString(), textNStepBase.Text.ToString(), "R_N_Base");
            else
                amdahlsLaw.R_A_Base(textAMinBase.Text.ToString(),
                    textAMaxBase.Text.ToString(), textNBase.Text.ToString(), textAStepBase.Text.ToString(), "R_A_Base");

            amdahlsLaw.ResultText(richResultBase);
            amdahlsLaw.ResultGraph(chartGraph);
        }
        private void buttonNetWork_Click(object sender, EventArgs e)
        {
            AmdahlsLaw amdahlsLaw = new AmdahlsLaw();



            if (radioRANw.Checked)
                amdahlsLaw.R_A_NW(textAMinNW.Text.ToString(),
            textAMaxNW.Text.ToString(), textNNW.Text.ToString(), textAStepNW.Text.ToString(),
            textCa_NW.Text.ToString(), textCt_NW.Text.ToString(), "R_A_NW");

            if (radioRNNw.Checked)
                amdahlsLaw.R_N_NW(textANW.Text.ToString(),
        textNMinNW.Text.ToString(), textNMaxNW.Text.ToString(), textNStepNW.Text.ToString(),
        textCaNW.Text.ToString(), textCtNW.Text.ToString(), "R_N_NW");

            if (radioRCaNw.Checked)
                amdahlsLaw.R_Ca_NW(textACa.Text.ToString(),
            textNCa.Text.ToString(), textCaMin.Text.ToString(), textCaMax.Text.ToString(),
            textCt.Text.ToString(), textCaStep.Text.ToString(), "R_Ca_NW");

            if (radioRCtNw.Checked)
                amdahlsLaw.R_Ct_NW(textACt.Text.ToString(),
            textNCt.Text.ToString(), textCaCt.Text.ToString(), textCtMin.Text.ToString(),
            textCtMax.Text.ToString(), textCtStep.Text.ToString(), "R_Ct_NW");

            amdahlsLaw.ResultText(richTextNetwork);
            amdahlsLaw.ResultGraph(chartGraphNetWork);
        }
    }
}
