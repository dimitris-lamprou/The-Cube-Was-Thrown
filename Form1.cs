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

namespace The_Cube_Was_Thrown
{
    public partial class Form1 : Form
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        Random r = new Random();
        public static string[] pictures = { "images/Alea_1.png", "images/Alea_2.png", "images/Alea_3.png", "images/Alea_4.png", "images/Alea_5.png", "images/Alea_6.png" };
        int countForResize = 0;
        int countForTimer3 = 0;
        System.Windows.Forms.FormWindowState prevState = FormWindowState.Normal;
        public static string userName = "";
        bool flag = false;
        public static string level = "Level 1";

        public Form1()
        {
            InitializeComponent();
            player.SoundLocation = "BGMusic.wav";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!comboBox1.Text.Equals(""))
            {
                comboBox1.Items.Add(comboBox1.Text);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            countForResize++;

            if (WindowState == FormWindowState.Minimized)
            {
                prevState = FormWindowState.Minimized;
            }
            else
            {
                if (WindowState == FormWindowState.Maximized && !(prevState == FormWindowState.Minimized))
                {
                    button3.Location = new Point(button3.Location.X - 15, 100 + 5);
                    button3.Width += 30;
                    button3.Height += 30;

                    button4.Location = new Point(button4.Location.X - 15, button4.Location.Y - 50 + 5);
                    button4.Width += 30;
                    button4.Height += 30;

                    button2.Location = new Point(button2.Location.X - 15, button2.Location.Y + 5 + 5);
                    button2.Width += 30;
                    button2.Height += 30;

                    label1.Location = new Point(label1.Location.X - 40, label1.Location.Y + 30 + 50);
                    label1.Font = new Font("Comic Sans MS", 15);

                    comboBox1.Location = new Point(comboBox1.Location.X -20, comboBox1.Location.Y + 30 + 50);
                    comboBox1.Width += 30;
                    comboBox1.Font = new Font("Comic Sans MS", 15);

                    button1.Location = new Point(button1.Location.X + 20, button1.Location.Y + 20 + 50);
                    button1.Width += 30;
                    button1.Height += 30;

                    prevState = FormWindowState.Maximized;
                }
                else if (WindowState == FormWindowState.Normal && countForResize > 1 && !(prevState == FormWindowState.Minimized))
                {
                    button3.Location = new Point(210, 20);
                    button3.Width -= 30;
                    button3.Height -= 30;

                    button4.Location = new Point(210, 87);
                    button4.Width -= 30;
                    button4.Height -= 30;

                    button2.Location = new Point(210, 155);
                    button2.Width -= 30;
                    button2.Height -= 30;

                    label1.Location = new Point(86, 209);
                    label1.Font = new Font("Comic Sans MS", 12);

                    comboBox1.Location = new Point(141, 207);
                    comboBox1.Width -= 30;
                    comboBox1.Font = new Font("Comic Sans MS", 12);

                    button1.Location = new Point(390, 200);
                    button1.Width -= 30;
                    button1.Height -= 30;

                    prevState = FormWindowState.Normal;
                }
                else
                {
                    if (WindowState == FormWindowState.Normal)
                    {
                        prevState = FormWindowState.Normal;
                    }
                    else
                    {
                        prevState = FormWindowState.Maximized;
                    }
                }
            }
        }

        private void FormMaximizedBoundsChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Motion(pictureBox1);
            Motion(pictureBox2);
            Motion(pictureBox3);
            Motion(pictureBox4);
            Motion(pictureBox5);
            Motion(pictureBox6);
            Motion(pictureBox7);
            Motion(pictureBox8);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public Point[] Moves(int x, int y)
        {
            const int k = 1;
            Point[] p = { new Point(x + k, y + k), new Point(x + k, y + -k), new Point(x + -k, y + k), new Point(x + -k, y + -k) };
            return p;
        }

        public void Motion(System.Windows.Forms.PictureBox pictureBox)
        {
            
            if (this.Width < 900)
            {
                if (pictureBox.Location.X >= 540)
                {
                    pictureBox.Location = new Point(pictureBox.Location.X - 5, pictureBox.Location.Y);
                }
                else if (pictureBox.Location.Y >= 295)
                {
                    pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y - 5);
                }
                else if (pictureBox.Location.X <= 5)
                {
                    pictureBox.Location = new Point(pictureBox.Location.X + 5, pictureBox.Location.Y);
                }
                else if (pictureBox.Location.Y <= 5)
                {
                    pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y + 5);
                }
                else
                {
                    pictureBox.Location = Moves(pictureBox.Location.X, pictureBox.Location.Y)[r.Next(4)];
                }
            }
            else
            {
                if (pictureBox.Location.X >= 1150)
                {
                    pictureBox.Location = new Point(pictureBox.Location.X - 5, pictureBox.Location.Y);
                }
                else if (pictureBox.Location.Y >= 550)
                {
                    pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y - 5);
                }
                else if (pictureBox.Location.X <= 5)
                {
                    pictureBox.Location = new Point(pictureBox.Location.X + 5, pictureBox.Location.Y);
                }
                else if (pictureBox.Location.Y <= 5)
                {
                    pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y + 5);
                }
                else
                {
                    pictureBox.Location = Moves(pictureBox.Location.X, pictureBox.Location.Y)[r.Next(4)];
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //comboBox1.Text = e.Location.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = pictures[r.Next(6)];
            pictureBox2.ImageLocation = pictures[r.Next(6)];
            pictureBox3.ImageLocation = pictures[r.Next(6)];
            pictureBox4.ImageLocation = pictures[r.Next(6)];
            pictureBox5.ImageLocation = pictures[r.Next(6)];
            pictureBox6.ImageLocation = pictures[r.Next(6)];
            pictureBox7.ImageLocation = pictures[r.Next(6)];
            pictureBox8.ImageLocation = pictures[r.Next(6)];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 form2 = new Form2();
            if (WindowState == FormWindowState.Maximized)
            {
                form2.WindowState = FormWindowState.Maximized;
                form2.ShowDialog();
            }
            else
            {
                form2.ShowDialog();
            }
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label2.Text.Equals("Level 4"))
            {
                label2.Text = "Level 1";
                level = "Level 1";
            }
            else if (label2.Text.Equals("Level 1"))
            {
                label2.Text = "Level 2";
                level = "Level 2";
            }
            else if (label2.Text.Equals("Level 2"))
            {
                label2.Text = "Level 3";
                level = "Level 3";
            }
            else
            {
                label2.Text = "Level 4";
                level = "Level 4";
            }
            timer3.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Interval = 1000;
            countForTimer3++;
            label2.Visible = true;
            if (countForTimer3>1)
            {
                label2.Visible = false;
                countForTimer3 = 0;
                timer3.Enabled = false;
                timer3.Interval = 1;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Please Enter a Name");
            }
            else
            {
                foreach (string s in comboBox1.Items)
                {
                    if (s.Equals(comboBox1.Text))
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    userName = comboBox1.Text;
                    StreamWriter sw = File.AppendText("Users.rtf");
                    sw.WriteLine(userName + Environment.NewLine + "0" + Environment.NewLine + "0" + Environment.NewLine + "0" + Environment.NewLine + "0");
                    sw.Close();
                }
                else
                {
                    userName = comboBox1.Text;
                }
                level = label2.Text;
                Hide();
                Form3 form3 = new Form3();
                form3.ShowDialog();
                Close();
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("Users.rtf");
            try
            {
                String s = sr.ReadLine();
                while (s != null)
                {
                    comboBox1.Items.Add(s);
                    s = sr.ReadLine();
                    s = sr.ReadLine();
                    s = sr.ReadLine();
                    s = sr.ReadLine();
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
            label2.Text = level;
            comboBox1.Text = userName;
            player.Play();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Hide();
            Form4 form4 = new Form4();
            if (WindowState == FormWindowState.Maximized)
            {
                form4.WindowState = FormWindowState.Maximized;
                form4.ShowDialog();
            }
            else
            {
                form4.ShowDialog();
            }
            Close();
        }
    }
}
