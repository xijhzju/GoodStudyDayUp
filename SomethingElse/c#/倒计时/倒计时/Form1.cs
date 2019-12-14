using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 倒计时
{
    public partial class MainForm : Form
    {
        private int time;
        private int timeLeft;
        public MainForm()
        {
            InitializeComponent();
            comboBoxTime.SelectedIndex = 0;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            //开始是把combox里的时间传给time,然后开始timers
            string nums = System.Text.RegularExpressions.Regex.Replace(comboBoxTime.Text, @"[^0-9]+", "");
            try
            {
                time = int.Parse(nums);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message+"\n"+"时间以秒为单位，请输入数字");
                return;
            }

            timeLeft = time;
            labelTimeLeft.Text = timeLeft.ToString();
            progressBar1.Value = 0;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            labelTimeLeft.Text = timeLeft.ToString();
            progressBar1.Value = (int)((1 - (double)timeLeft / (double)time) * 100);
            if (timeLeft == 0)
            {
                timer1.Stop();
                MessageBox.Show("TIME IS OVER");
            }
        }
    }
}
