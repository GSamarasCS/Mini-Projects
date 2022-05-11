using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Button_Party
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Button> buttonParty = new List<Button>();
        int limit; //depends on form's current size, represents how many buttons can fit in a line 

        private void Party_Click(object sender, EventArgs e)
        {
            try
            {               
                int line = 1;
                int times = Convert.ToInt32(textBox1.Text);
                int index;
                bool flag = false;
                bool flag2 = false;
                
                for (int i = 1; i <= times; i++)
                {
                    Button party = new Button();
                    party.Size = new Size(Party.Width, Party.Height);

                    //get location
                    index = i;
                    int temp = Convert.ToInt32(Party.Location.X) + (i + 1) * Party.Width;
                    if (temp >= this.Width)
                    {
                        if (!flag)
                        {
                            limit = i;
                            flag = true;
                        }

                        if (!flag2)
                        {
                            line++;
                            index = i - limit * (line - 1);
                            flag2 = true;
                        }
                        else
                        {                           
                            index = i - limit * (line - 1);
                            if (index % limit == limit - 1) 
                                flag2 = false;
                        }
                    }
                    party.Location = new Point(Party.Location.X + index * Party.Width, Party.Location.Y + (line - 1) * Party.Height);

                    party.Name = "button" + i.ToString();
                    party.Text = "Button" + i.ToString();
                    party.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                    this.Controls.Add(party);
                    buttonParty.Add(party);
                    party.Click += new EventHandler(LetsParty);

                    //disable starting button (until all buttons that were created get clicked)
                    Party.Enabled = false;
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LetsParty(object o, EventArgs e)
        {
            try
            {
                //get button's index
                int index = 0;
                foreach (Button party in buttonParty)
                {
                    if (party == ((Button)o))
                        break;
                    index++;
                }

                //hide button
                ((Button)o).Visible = false;

                //rearrange buttons
                for (int i = buttonParty.Count - 1; i >= index; i--)
                    if (i != 0)
                        buttonParty.ElementAt(i).Location = buttonParty.ElementAt(i - 1).Location;              

                //remove button
                buttonParty.Remove(((Button)o));

                //enable starting button if no addional buttons exist
                if (buttonParty.Count == 0)                
                    Party.Enabled = true;               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
