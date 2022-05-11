using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace unipigame1
{
    public partial class Form2 : Form
    {
        Random rng= new Random();
        RichTextBox temp = new RichTextBox();
        string playername;
        int level;
        int gamephase = 0;
        int time = 0;
        int endtime = 60;
        int score = 0;
        int addpoints = 100;
        public Form2(RichTextBox l, string Pname,int lvl)
        {
            temp.Text = l.Text;
            playername = Pname;
            level = lvl;
            InitializeComponent();
            if (level != 0)
            {
                addpoints = level * addpoints;
                timer1.Interval = (int)2000 / lvl;
            }
            this.Text = "Unipi Game - Level " + level.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = score.ToString() + " Points";
            label2.Text = "Player: " + playername.ToString();
            if (temp.Lines.Length > 0) label6.Text = "Top score: " + temp.Lines[0];
            else label6.Text = "";
            pictureBox2.Location = new Point(rng.Next(0, ClientRectangle.Width - pictureBox2.Width), rng.Next(pictureBox3.Height, ClientRectangle.Height - pictureBox2.Size.Height));
            timer1.Enabled = true;
            timer2.Enabled = true;
            gamephase = 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox2.Location = new Point(rng.Next(0, ClientRectangle.Width - pictureBox2.Width), rng.Next(pictureBox3.Height, ClientRectangle.Height - pictureBox2.Size.Height));
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (gamephase == 1)
            {
                score += addpoints;
                label1.Text = score.ToString() + " Points";
                pictureBox2.Location = new Point(rng.Next(0, ClientRectangle.Width - pictureBox2.Width), rng.Next(pictureBox3.Height, ClientRectangle.Height - pictureBox2.Size.Height));
                timer1.Stop();
                timer1.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (time >= endtime)
            {
                gamephase = 0;
                timer1.Stop();
                timer2.Stop();
                textBox1.Text = score.ToString();
                label7.Text = "Level "+level.ToString();
                panel1.Visible = true;
                richTextBox1.Clear();
                if (String.IsNullOrEmpty(temp.Text)) richTextBox1.AppendText(playername.ToString() + " " + score.ToString());
                else
                {
                    bool f = false;
                    foreach (string s in temp.Lines)
                    {
                        String[] tmp = s.Split(' ');
                        int t = Int32.Parse(tmp[1]);
                        if (!String.IsNullOrEmpty(richTextBox1.Text)) richTextBox1.AppendText(Environment.NewLine);
                        if (score >= t && !f)
                        {
                            richTextBox1.AppendText(playername.ToString() + " " + score.ToString()+Environment.NewLine);
                            f = true;
                        }
                        richTextBox1.AppendText(s);

                    }
                    if (!f) richTextBox1.AppendText(Environment.NewLine + playername.ToString() + " " + score.ToString());
                }
                richTextBox1.SaveFile("highscores.txt", RichTextBoxStreamType.PlainText);
            }
            else time++;

            label3.Text = "Time: "+(endtime -  time).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 maingame = new Form2(richTextBox1, playername, level);
            maingame.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}