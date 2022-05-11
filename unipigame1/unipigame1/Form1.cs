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

namespace unipigame1
{
    public partial class Form1 : Form
    {
        int gamertest = 0;
        int level = 1;
        public string recenthighscorename = "";
        public int recenthighscore = 0;
        bool doesfileexist = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[ ]") && textBox1.Text != "")
            {
                Form2 maingame;
                if (doesfileexist) maingame = new Form2(richTextBox1, textBox1.Text, level);
                else maingame = new Form2(new RichTextBox(), textBox1.Text, level);
                maingame.Width = 2 * maingame.Width - maingame.ClientRectangle.Width;
                maingame.Height = 2 * maingame.Height - maingame.ClientRectangle.Height;
                maingame.Show();
            }
            else MessageBox.Show("Your name can't be empty or start with an empty character.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("highscores.txt"))
            {
                richTextBox1.LoadFile("highscores.txt", RichTextBoxStreamType.PlainText);
                doesfileexist = true;
            }
            else doesfileexist = false;
        }

        private void Form1_Enter(object sender, EventArgs e)
        {
            if (File.Exists("highscores.txt"))
            {
                richTextBox1.LoadFile("highscores.txt", RichTextBoxStreamType.PlainText);
                doesfileexist = true;
            }
        }

        private void radioButton1_MouseUp(object sender, MouseEventArgs e)
        {
            if (radioButton1.Checked)
            {
                level = 1;
                label3.Text = "Slow speed but less points (100 points per hit)";
            }
            else if (radioButton2.Checked)
            {
                level = 2;
                label3.Text = "Normal speed (200 points per hit)";
            }
            else if (radioButton3.Checked)
            {
                level = 3;
                label3.Text = "Fast speed with more points (300 per hit) *Recommended";
            }
        }
    }
}
