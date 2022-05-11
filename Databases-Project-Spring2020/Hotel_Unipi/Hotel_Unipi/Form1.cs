using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hotel_Unipi
{
    public partial class Form1 : Form
    {
        List<string> dataItems = new List<string>();
        public static int day;
        public static int month;

        public Form1()
        {
            InitializeComponent();
        }

        private void show_month_day()
        {
            label1.Visible = true;
            label2.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
        }

        private void hide_month_day()
        {
            label1.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            hide_month_day();
            if (comboBox1.Text == "(h) Ποια δωμάτια ενοικιάστηκαν από την ημερομηνία “X” έως και σήμερα:")
                show_month_day();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "(a) Πόσες κρατήσεις αντιστοιχούν σε κάθε κατηγορία δωματίων:")
            {
                Queries q = new Queries();
                dataItems = q.query_a();
                richTextBox1.Clear();
                for (int i = 0; i < dataItems.Count; i++)
                {
                    richTextBox1.Text += dataItems[i];
                    richTextBox1.ScrollToCaret();
                }
            }
            else if (comboBox1.Text == "(b) Ποια κατηγορία δωματίων παρουσιάζει βάσει των κρατήσεων τον μεγαλύτερο τζίρο:")
            {
                Queries q = new Queries();
                dataItems = q.query_b();
                richTextBox1.Clear();
                for (int i = 0; i < dataItems.Count; i++)
                {
                    richTextBox1.Text += dataItems[i];
                    richTextBox1.ScrollToCaret();
                }
            }
            else if (comboBox1.Text == "(c) Πόσα δωμάτια είναι προς το παρόν διαθέσιμα προς κράτηση:")
            {
                Queries q = new Queries();
                dataItems = q.query_c();
                richTextBox1.Clear();
                for (int i = 0; i < dataItems.Count; i++)
                {
                    richTextBox1.Text += dataItems[i];
                    richTextBox1.ScrollToCaret();
                }
            }
            else if (comboBox1.Text == "(d) Ποιες παροχές (facilities) διατίθενται σε συγκεκριμένα δωμάτια:")
            {
                Queries q = new Queries();
                dataItems = q.query_d();
                richTextBox1.Clear();
                for (int i = 0; i < dataItems.Count; i++)
                {
                    richTextBox1.Text += dataItems[i];
                    richTextBox1.ScrollToCaret();
                }
            }
            else if (comboBox1.Text == "(e) Ποιοι επισκέπτες έχουν κράτηση αυτό το μήνα:")
            {
                Queries q = new Queries();
                dataItems = q.query_e();
                richTextBox1.Clear();
                for (int i = 0; i < dataItems.Count; i++)
                {
                    richTextBox1.Text += dataItems[i];
                    richTextBox1.ScrollToCaret();
                }
            }
            else if (comboBox1.Text == "(f) Ποιο είναι το μέσο κέρδος ανά τύπο/κατηγορία δωματίου για τη θερινή σεζόν:")
            {
                Queries q = new Queries();
                dataItems = q.query_f();
                richTextBox1.Clear();
                for (int i = 0; i < dataItems.Count; i++)
                {
                    richTextBox1.Text += dataItems[i];
                    richTextBox1.ScrollToCaret();
                }
            }
            else if (comboBox1.Text == "(g) Ποιος είναι ο πελάτης με τις περισσότερες κρατήσεις ανά εύρος ζώνης τιμής δωματίου:")
            {
                Queries q = new Queries();
                dataItems = q.query_g();
                richTextBox1.Clear();
                for (int i = 0; i < dataItems.Count; i++)
                {
                    richTextBox1.Text += dataItems[i];
                    richTextBox1.ScrollToCaret();
                }
            }
            else if (comboBox1.Text == "(h) Ποια δωμάτια ενοικιάστηκαν από την ημερομηνία “X” έως και σήμερα:")
            {
                bool match = false;
                bool areNumbers = false;
                try
                {
                    day = Convert.ToInt32(textBox1.Text);
                    month = Convert.ToInt32(textBox2.Text);
                    areNumbers = true;
                }
                catch (FormatException)
                {
                    MessageBox.Show("1 <= day <= 31\n1<= month <= 12", "Invalid Input!", MessageBoxButtons.OK, MessageBoxIcon.Error);                  
                }
                if (areNumbers)
                    if (day >= 1 && day <= 31 && month >= 1 && month <= 12)
                        match = true;
                    else
                        MessageBox.Show("1 <= day <= 31\n1<= month <= 12", "Invalid Input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (match)
                {
                    Queries q = new Queries();
                    dataItems = q.query_h();
                    richTextBox1.Clear();
                    try
                    {
                        for (int i = 0; i < dataItems.Count; i++)
                        {
                            richTextBox1.Text += dataItems[i];
                            richTextBox1.ScrollToCaret();
                        }
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Input a valid date!", "Invalid Input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
   
    }
}
