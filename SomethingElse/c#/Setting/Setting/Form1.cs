using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Setting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Properties.Settings programSetting = new Properties.Settings();

        private void buttonGetSettings_Click(object sender, EventArgs e)
        {
            textBoxName.Text = programSetting.Name;
            textBoxGender.Text = programSetting.Gender;
            textBoxAge.Text = programSetting.Age.ToString();
        }

        private void buttonSaveSetting_Click(object sender, EventArgs e)
        {
            programSetting.Age = Convert.ToInt32(textBoxAge.Text);
            programSetting.Save();
        }
    }
}
