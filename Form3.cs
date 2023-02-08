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
    public partial class Form3 : Form
    {
        Random r = new Random();
        int dieNumber;
        int dieMinLocationX;
        int dieMinLocationY;
        int dieMaxLocationX;
        int dieMaxLocationY;
        int score = 0;
        int hits = 0;
        int time;
        string activeUserName;
        List<User> users = new List<User>();
        User topUser = new User();
        int shotCount;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_MouseMove(object sender, MouseEventArgs e)
        {
            //label1.Text = e.Location.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dieNumber = r.Next(6);
            pictureBox1.Location = new Point(r.Next(dieMinLocationX, dieMaxLocationX), r.Next(dieMinLocationY, dieMaxLocationY));
            pictureBox1.ImageLocation = Form1.pictures[dieNumber];          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            score += dieNumber + 1;
            hits++;
            shotCount--;
            if (shotCount > -1)
            {
                label9.Text = "Shots " + shotCount;
            }
            label1.Text = "Score " + score;
            label3.Text = "Hits " + hits;
           
            if (shotCount < 1 && Form1.level.Equals("Level 4"))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                pictureBox1.Visible = false;
                label4.Text = "Your score is " + score;
                label4.Visible = true;
                button1.Visible = true;
                button2.Visible = true;

                foreach (User u in users)
                {
                    if (activeUserName.Equals(u.name))
                    {
                        if (Form1.level.Equals("Level 1"))
                        {
                            if (score > u.highScoreForLevel1)
                            {
                                u.highScoreForLevel1 = score;
                            }
                        }
                        else if (Form1.level.Equals("Level 2"))
                        {
                            if (score > u.highScoreForLevel2)
                            {
                                u.highScoreForLevel2 = score;
                            }
                        }
                        else if (Form1.level.Equals("Level 3"))
                        {
                            if (score > u.highScoreForLevel3)
                            {
                                u.highScoreForLevel3 = score;
                            }
                        }
                        else
                        {
                            if (score > u.highScoreForLevel4)
                            {
                                u.highScoreForLevel4 = score;
                            }
                        }
                    }
                }

                File.Delete("Users.rtf");
                StreamWriter sw = File.AppendText("Users.rtf");
                foreach (User u in users)
                {
                    sw.WriteLine(u.name);
                    sw.WriteLine(u.highScoreForLevel1);
                    sw.WriteLine(u.highScoreForLevel2);
                    sw.WriteLine(u.highScoreForLevel3);
                    sw.WriteLine(u.highScoreForLevel4);
                }
                sw.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 form1 = new Form1();
            form1.WindowState = FormWindowState.Maximized;
            form1.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form3 form3 = new Form3();
            form3.ShowDialog();
            Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            activeUserName = Form1.userName;

            label5.Text = Form1.level;

            if (Form1.level.Equals("Level 1"))
            {
                dieNumber = r.Next(6);
                time = 60;
                label2.Text = "Time " + time;
                dieMinLocationX = 400;
                dieMaxLocationX = 800;
                dieMinLocationY = 200;
                dieMaxLocationY = 400;
                pictureBox1.Size = new Size(100, 100);
                pictureBox1.Location = new Point(r.Next(400, 800), r.Next(200, 400));
                pictureBox1.ImageLocation = Form1.pictures[dieNumber];
                timer1.Interval = 1000;
            }
            else if (Form1.level.Equals("Level 2"))
            {
                dieNumber = r.Next(6);
                time = 60;
                label2.Text = "Time " + time;
                dieMinLocationX = 400;
                dieMaxLocationX = 800;
                dieMinLocationY = 200;
                dieMaxLocationY = 400;
                pictureBox1.Size = new Size(80, 80);
                pictureBox1.Location = new Point(r.Next(400, 800), r.Next(200, 400));
                
                timer1.Interval = 850;
            }
            else if(Form1.level.Equals("Level 3"))
            {
                dieNumber = r.Next(6);
                time = 30;
                label2.Text = "Time " + time;
                dieMinLocationX = 0;
                dieMaxLocationX = 1215;
                dieMinLocationY = 138;
                dieMaxLocationY = 655;
                pictureBox1.Size = new Size(60, 60);
                pictureBox1.Location = new Point(r.Next(0, 1215), r.Next(95, 655));
                timer1.Interval = 700;
            }
            else
            {
                shotCount = 25;
                label9.Visible = true;
                label9.Text = "Shots " + shotCount;
                dieNumber = r.Next(6);
                time = 30;
                label2.Text = "Time " + time;
                dieMinLocationX = 0;
                dieMaxLocationX = 1215;
                dieMinLocationY = 138;
                dieMaxLocationY = 655;
                pictureBox1.Size = new Size(60, 60);
                pictureBox1.Location = new Point(r.Next(0, 1215), r.Next(95, 655));
                timer1.Interval = 700;
            }
            
            StreamReader sr = new StreamReader("Users.rtf");
            try
            {
                String s = sr.ReadLine();
                while (s != null)
                {
                    User user = new User();

                    user.name = s;
                    s = sr.ReadLine();
                    user.highScoreForLevel1 = int.Parse(s);
                    s = sr.ReadLine();
                    user.highScoreForLevel2 = int.Parse(s);
                    s = sr.ReadLine();
                    user.highScoreForLevel3 = int.Parse(s);
                    s = sr.ReadLine();
                    user.highScoreForLevel4 = int.Parse(s);
                    s = sr.ReadLine();
                    users.Add(user);
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
            foreach (User u in users)
            {
                if (Form1.level.Equals("Level 1"))
                {
                    if (u.highScoreForLevel1 > topUser.highScoreForLevel1)
                    {
                        topUser.highScoreForLevel1 = u.highScoreForLevel1;
                        topUser.name = u.name;
                    }
                }
                else if (Form1.level.Equals("Level 2"))
                {
                    if (u.highScoreForLevel2 > topUser.highScoreForLevel2)
                    {
                        topUser.highScoreForLevel2 = u.highScoreForLevel2;
                        topUser.name = u.name;
                    }
                }
                else if (Form1.level.Equals("Level 3"))
                {
                    if (u.highScoreForLevel3 > topUser.highScoreForLevel3)
                    {
                        topUser.highScoreForLevel3 = u.highScoreForLevel3;
                        topUser.name = u.name;
                    }
                }
                else
                {
                    if (u.highScoreForLevel4 > topUser.highScoreForLevel4)
                    {
                        topUser.highScoreForLevel4 = u.highScoreForLevel4;
                        topUser.name = u.name;
                    }
                }
            }
            if (Form1.level.Equals("Level 1"))
            {
                label6.Text = "Top Score " + topUser.highScoreForLevel1.ToString();
                label7.Text = "Top User " + topUser.name;
                foreach (User u in users)
                {
                    if (u.name.Equals(activeUserName))
                    {
                        label8.Text = "High Score " + u.highScoreForLevel1;
                    }
                }

            }
            else if (Form1.level.Equals("Level 2"))
            {
                label6.Text = "Top Score " + topUser.highScoreForLevel2.ToString();
                label7.Text = "Top User " + topUser.name;
                foreach (User u in users)
                {
                    if (u.name.Equals(activeUserName))
                    {
                        label8.Text = "High Score " + u.highScoreForLevel2;
                    }
                }
            }
            else if(Form1.level.Equals("Level 3"))
            {
                label6.Text = "Top Score " + topUser.highScoreForLevel3.ToString();
                label7.Text = "Top User " + topUser.name;
                foreach (User u in users)
                {
                    if (u.name.Equals(activeUserName))
                    {
                        label8.Text = "High Score " + u.highScoreForLevel3;
                    }
                }
            }
            else
            {
                label6.Text = "Top Score " + topUser.highScoreForLevel4.ToString();
                label7.Text = "Top User " + topUser.name;
                foreach (User u in users)
                {
                    if (u.name.Equals(activeUserName))
                    {
                        label8.Text = "High Score " + u.highScoreForLevel4;
                    }
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            time--;
            label2.Text = "Time " + time;
            if (time < 1)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                pictureBox1.Visible = false;
                label4.Text = "Your score is " + score;
                label4.Visible = true;
                button1.Visible = true;
                button2.Visible = true;



                foreach (User u in users)
                {
                    if (activeUserName.Equals(u.name))
                    {
                        if (Form1.level.Equals("Level 1"))
                        {
                            if (score > u.highScoreForLevel1)
                            {
                                u.highScoreForLevel1 = score;
                            }
                        }
                        else if (Form1.level.Equals("Level 2"))
                        {
                            if (score > u.highScoreForLevel2)
                            {
                                u.highScoreForLevel2 = score;
                            }
                        }
                        else if (Form1.level.Equals("Level 3"))
                        {
                            if (score > u.highScoreForLevel3)
                            {
                                u.highScoreForLevel3 = score;
                            }
                        }
                        else
                        {
                            if (score > u.highScoreForLevel4)
                            {
                                u.highScoreForLevel4 = score;
                            }
                        }
                    }
                }

                File.Delete("Users.rtf");
                StreamWriter sw = File.AppendText("Users.rtf");
                foreach (User u in users)
                {
                    sw.WriteLine(u.name);
                    sw.WriteLine(u.highScoreForLevel1);
                    sw.WriteLine(u.highScoreForLevel2);
                    sw.WriteLine(u.highScoreForLevel3);
                    sw.WriteLine(u.highScoreForLevel4);
                }
                sw.Close();
            }
        }

        private void Form3_MouseClick(object sender, MouseEventArgs e)
        {
            shotCount--;
            if (shotCount > -1)
            {
                label9.Text = "Shots " + shotCount;
            }

            if (shotCount < 1 && Form1.level.Equals("Level 4"))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                pictureBox1.Visible = false;
                label4.Text = "Your score is " + score;
                label4.Visible = true;
                button1.Visible = true;
                button2.Visible = true;

                foreach (User u in users)
                {
                    if (activeUserName.Equals(u.name))
                    {
                        if (Form1.level.Equals("Level 1"))
                        {
                            if (score > u.highScoreForLevel1)
                            {
                                u.highScoreForLevel1 = score;
                            }
                        }
                        else if (Form1.level.Equals("Level 2"))
                        {
                            if (score > u.highScoreForLevel2)
                            {
                                u.highScoreForLevel2 = score;
                            }
                        }
                        else if (Form1.level.Equals("Level 3"))
                        {
                            if (score > u.highScoreForLevel3)
                            {
                                u.highScoreForLevel3 = score;
                            }
                        }
                        else
                        {
                            if (score > u.highScoreForLevel4)
                            {
                                u.highScoreForLevel4 = score;
                            }
                        }
                    }
                }

                File.Delete("Users.rtf");
                StreamWriter sw = File.AppendText("Users.rtf");
                foreach (User u in users)
                {
                    sw.WriteLine(u.name);
                    sw.WriteLine(u.highScoreForLevel1);
                    sw.WriteLine(u.highScoreForLevel2);
                    sw.WriteLine(u.highScoreForLevel3);
                    sw.WriteLine(u.highScoreForLevel4);
                }
                sw.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 form1 = new Form1();
            form1.WindowState = FormWindowState.Maximized;
            form1.ShowDialog();
            Close();
        }
    }
}
