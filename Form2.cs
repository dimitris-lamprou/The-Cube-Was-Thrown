﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Cube_Was_Thrown
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 form1 = new Form1();
            if (WindowState == FormWindowState.Maximized)
            {
                form1.WindowState = FormWindowState.Maximized;
                form1.ShowDialog();
            }
            else
            {
                form1.ShowDialog();
            }
            Close();
        }
    }
}
