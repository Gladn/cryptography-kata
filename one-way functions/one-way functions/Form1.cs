using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Runtime.InteropServices;

namespace one_way_functions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        
        /// </summary>
        /// 1
        BigInteger binpow(BigInteger a, BigInteger n, BigInteger m)
        {
            BigInteger res = 1;
            while (n > 0)
            {
                if (n % 2 == 1)
                {
                    res *= a;
                    res %= m;
                }
                a *= (a % m);
                a %= m;
                n >>= 1;
            }
            return res % m;

        }


        static BigInteger abcol(BigInteger N) => (N*(N-1))/2;
       

        void binpowToText() {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
               
                BigInteger a = BigInteger.Parse(textBox1.Text);
                BigInteger x = BigInteger.Parse(textBox2.Text);
                BigInteger p = BigInteger.Parse(textBox3.Text);
                textBox4.Text = binpow(a, x, p).ToString();
            }
        }
        void AbcolToText()
        {
            if (textBox5.Text != "")
            {
                long a = long.Parse(textBox5.Text);
                textBox8.Text = abcol(a).ToString();
            }
        }
        

        private void Form1_Load_1(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 3;
            string[] Data3 = { "A", "B", "C" };
            string[] Data3ch = { "22", "5", "4" };
            for (int j = 0; j < Data3.Count(); j++)
            {              
                dataGridView1.Rows[j].Cells[0].Value = Data3[j].ToString();
                dataGridView1.Rows[j].Cells[1].Value = Data3ch[j].ToString();
            }
            binpowToText();
            AbcolToText();
        }
      
        
       
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            binpowToText();
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            binpowToText();
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            binpowToText();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            AbcolToText();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
