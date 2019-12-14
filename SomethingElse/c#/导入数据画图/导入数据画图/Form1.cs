using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 导入数据画图
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double[] temp = new double[1000];
        int Len = 0; 

        private void importFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "导入数据作图";
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                string strLine;

                while (sr.EndOfStream == false)
                {
                    strLine = sr.ReadLine();
                    temp[Len] = Convert.ToDouble(strLine);
                    Len++;
                }
                sr.Dispose();
                fs.Dispose();
            }

            for (int pointIndex = 0; pointIndex < Len; pointIndex++)
            {
                //chart属性里面series 集合里面把charttype改成line
                 chart1.Series["Line1"].Points.AddY(temp[pointIndex]);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
