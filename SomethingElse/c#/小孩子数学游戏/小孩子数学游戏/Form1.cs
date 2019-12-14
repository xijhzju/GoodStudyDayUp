using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 小孩子数学游戏
{   
    //20190807
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitBtnText();
        }

        //生成2个随机数并赋给2个radiobtn的text
        void InitBtnText()
        {
            Random ra = new Random();
            int num1 = ra.Next(1, 99);
            int num2 = ra.Next(1, 99);
            radioButton1.Text = num1.ToString();
            while (num2 == num1)
            {
                num2 = ra.Next(1, 99);
            }
            radioButton2.Text = num2.ToString();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        void rightorwrong()
        {
            int num1 = int.Parse(radioButton1.Text);
            int num2 = int.Parse(radioButton2.Text);
            if (((num1 > num2) & radioButton1.Checked) || ((num1 < num2) && radioButton2.Checked))
            {
                URRIGHT rightForm = new URRIGHT();
                rightForm.ShowDialog();
            }
            else
            {
                urwrong wrongform = new urwrong();
                wrongform.ShowDialog();
            }
            /*String str1 = radioButton1.Text;
            String str2 = radioButton2.Text;
            int num3 = int.Parse("4");
            int num4 = int.Parse("89");
            int num5 = int.Parse(str1);
            int num6 = int.Parse(str2);*/
        }
       
     

        private void btnRestart_Click(object sender, EventArgs e)
        {
            InitBtnText();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
          // rightorwrong();           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //rightorwrong();           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            rightorwrong();
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            rightorwrong();
        }
    }
}
