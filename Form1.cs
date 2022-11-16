using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fitro
{
    public partial class Amplifier : Form
    {
        public Amplifier()
        {
            InitializeComponent();
        }
        
        int count = 1;
        double ampli_value = 0, capacitance1_value = 0, frequency_value = 0, gain_value = 0;

        public void enable()
        {
            button1.Enabled=false; button2.Enabled=false;

            try
            {
                ampli_value=Convert.ToDouble(amp_rate_in.Text);
                capacitance1_value=Convert.ToDouble(capacitance_in.Text);
                frequency_value=Convert.ToDouble(frequency_in.Text);
                gain_value=Convert.ToDouble(gain_in.Text);

                if (ampli_value !=0 && capacitance1_value!=0 && frequency_value!=0)
                {
                    button1.Enabled=true; button2.Enabled=true;
                }
            }

            catch { }
        }
        private void validation(object sender, EventArgs e)
        {
            try {
                ampli_value=Convert.ToDouble(amp_rate_in.Text);
                capacitance1_value=Convert.ToDouble(capacitance_in.Text);
                frequency_value=Convert.ToDouble(frequency_in.Text);
                gain_value=Convert.ToDouble(gain_in.Text);

                if (ampli_value !=0 && capacitance1_value!=0 && frequency_value!=0)
                {
                    button1.Enabled=true; button2.Enabled=true;
                }
            }

            catch
            { }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            count = count % 9 +1;
            pictureBox1.Image= Image.FromFile(Directory.GetCurrentDirectory() + "\\res0" + Convert.ToString(count)+ ".png");

        }

        private void enable(object sender, EventArgs e)
        {
          
                button1.Enabled=false; button2.Enabled=false;

                try
                {
                    ampli_value=Convert.ToDouble(amp_rate_in.Text);
                    capacitance1_value=Convert.ToDouble(capacitance_in.Text);
                    frequency_value=Convert.ToDouble(frequency_in.Text);
                    gain_value=Convert.ToDouble(gain_in.Text);

                    if (ampli_value !=0 && capacitance1_value!=0 && frequency_value!=0)
                    {
                        button1.Enabled=true; button2.Enabled=true;
                    }
                }

                catch { }
            
        }

        private void fitro_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Close this app?", "Are you sure?",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2)==DialogResult.Cancel)
                e.Cancel=false;
        }

        private void calcular(object sender, EventArgs e)
        {
            double r1, r2, r3, c2;
            int b;
            double ampli_gain = ampli_value*gain_value;
            for (int a = 0; a<5; a++)
            {
                b = a +1;
                r1= Math.Sqrt(2) / (2 * a * 2 * Math.PI * frequency_value * capacitance1_value);
                r2=ampli_gain*r1;
                r3=(r2/ampli_gain+1);
                c2=2*(ampli_gain+1)*capacitance1_value;

                list_r1.Items.Add(b.ToString("#0")+ "....." + r1.ToString("#0.00000"));
                list_r2.Items.Add(b.ToString("#0")+ "....." + r2.ToString("#0.00000"));
                list_r3.Items.Add(b.ToString("#0")+ "....." + r3.ToString("#0.00000"));
                list_c2.Items.Add(b.ToString("#0")+ "....." + c2.ToString("#0.00000"));







            }
        }

      
        private void Clean(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear all data?", "Are you sure?",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2)==DialogResult.OK)
            {
                amp_rate_in.Clear(); capacitance_in.Clear(); frequency_in.Clear(); gain_in.Clear();
                list_r1.Items.Clear(); list_r2.Items.Clear(); list_r3.Items.Clear(); list_c2.Items.Clear();
            }
           enable();
        } 

    }
      
}


   


