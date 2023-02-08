using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Cube_Was_Thrown
{
    public partial class Form4 : Form
    {
        public Form4()
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

        private void Form4_Load(object sender, EventArgs e)
        {
            richTextBox1.AppendText("User\t\t\tLevel1\t\t\tLevel2\t\tLevel3\t\tLevel4" + Environment.NewLine);
            StreamReader sr = new StreamReader("Users.rtf");
            try
            {
                String s = sr.ReadLine();
                while (s != null)
                {
                    richTextBox1.AppendText(s + "\t\t\t" + sr.ReadLine() + "\t\t\t" + sr.ReadLine() + "\t\t\t" + sr.ReadLine() + "\t\t\t" + sr.ReadLine() + Environment.NewLine);
                    s = sr.ReadLine();
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sr.Close();
            }
        }
    }
}
