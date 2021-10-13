using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Lab3Seti;

namespace Lab3UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            textBoxCRC.Text = "";
            textBoxParity.Text = "";
            textBoxVerHorParity.Text = "";

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            byte[] input = File.ReadAllBytes(openFileDialog.FileName);

            textBoxParity.Text = string.Join("", Parity.MakeMessage(input));

            uint[] countSumHor;
            uint[] countSumVer;
            byte[] temp = new byte[8];

            for (int i = 0, k = 0; i < input.Length; i++, k++)
            {
                temp[k] = input[i];
                if(i > 0 && i % 7 == 0)
                {
                    VerHorParity.VertAndHorizontParityControlSum(temp, out countSumVer, out countSumHor);
                    textBoxVerHorParity.Text += "" + string.Join("", countSumVer) + " " + string.Join("", countSumHor) +Environment.NewLine;
                    k = 0;
                }
            }

            uint CSCRC;
            CRCTable.CRC32(input, out CSCRC);
            textBoxCRC.Text += Convert.ToString(CSCRC, 2);

        }
    }
}
