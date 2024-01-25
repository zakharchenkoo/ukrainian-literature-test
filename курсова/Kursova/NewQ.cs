using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReadWriteBinaryFile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace Kursova
{
    public partial class NewQ : Form
    {
        
        public NewQ()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            p2.Location = p1.Location;
            p3.Location = p1.Location;
            if (TestClass.QisSelected)
            {
                RLoad(TestClass.Qselected);
                button1.Text = "Прийняти зміни";
                button2.Visible = true;
            }
        }
        private void RLoad(int index)
        {
            
            TestClass.Question sv = new TestClass.Question();
            
            sv = TestClass.qq.questions[index];


            switch (sv.type)
            {
                case 0:
                    p1.Show();
                    p2.Hide();
                    p3.Hide();
                    break;
                case 1:
                    p1.Hide();
                    p2.Show();
                    p3.Hide();
                    break;
                case 2:
                    p1.Hide();
                    p2.Hide();
                    p3.Show();
                    break;
            }
            textBox1.Text = sv.qx;
            comboBox1.SelectedIndex = sv.type;
            switch (sv.type)
            {
                case 0:
                    p1_t1.Text = sv.q1;
                    p1_t2.Text = sv.q2;
                    p1_t3.Text = sv.q3;
                    p1_t4.Text = sv.q4;

                    p1_r1.Checked = stb(sv.r1);
                    p1_r2.Checked = stb(sv.r2);
                    p1_r3.Checked = stb(sv.r3);
                    p1_r4.Checked = stb(sv.r4);
                    break;
                case 1:
                    p2_t1.Text = sv.q1;
                    p2_t2.Text = sv.q2;
                    p2_t3.Text = sv.q3;
                    p2_t4.Text = sv.q4;

                    p2_r1.Text = sv.r1;
                    p2_r2.Text = sv.r2;
                    p2_r3.Text = sv.r3;
                    p2_r4.Text = sv.r4;
                    break;
                case 2:
                    p3_t1.Text = sv.q1;
                    p3_t2.Text = sv.q2;
                    p3_t3.Text = sv.q3;
                    p3_t4.Text = sv.q4;

                    p3_r1.Checked = stb(sv.r1);
                    p3_r2.Checked = stb(sv.r2);
                    p3_r3.Checked = stb(sv.r3);
                    p3_r4.Checked = stb(sv.r4);
                    break;
            }

        }
        private bool stb(string ss)
        {
            if (ss == "0")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    p1.Show();
                    p2.Hide();
                    p3.Hide();
                    break;
               case 1:
                    p1.Hide();
                    p2.Show();
                    p3.Hide();
                    break;
                case 2:
                    p1.Hide();
                    p2.Hide();
                    p3.Show();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            TestClass.Question sv = new TestClass.Question();
            try
            {
                sv.qx = textBox1.Text;
                sv.type = comboBox1.SelectedIndex;
                switch (sv.type)
                {
                    case 0:
                        sv.q1 = p1_t1.Text;
                        sv.q2 = p1_t2.Text;
                        sv.q3 = p1_t3.Text;
                        sv.q4 = p1_t4.Text;
                        /* */
                        sv.r1 = p1_r1.Checked ? "1" : "0";
                        sv.r2 = p1_r2.Checked ? "1" : "0";
                        sv.r3 = p1_r3.Checked ? "1" : "0";
                        sv.r4 = p1_r4.Checked ? "1" : "0";
                        break;
                    case 1:
                        sv.q1 = p2_t1.Text;
                        sv.q2 = p2_t2.Text;
                        sv.q3 = p2_t3.Text;
                        sv.q4 = p2_t4.Text;
                        /* */
                        sv.r1 = p2_r1.Text;
                        sv.r2 = p2_r2.Text;
                        sv.r3 = p2_r3.Text;
                        sv.r4 = p2_r4.Text;
                        break;
                    case 2:
                        sv.q1 = p3_t1.Text;
                        sv.q2 = p3_t2.Text;
                        sv.q3 = p3_t3.Text;
                        sv.q4 = p3_t4.Text;
                        /* */
                        sv.r1 = p3_r1.Checked ? "1" : "0";
                        sv.r2 = p3_r2.Checked ? "1" : "0";
                        sv.r3 = p3_r3.Checked ? "1" : "0";
                        sv.r4 = p3_r4.Checked ? "1" : "0";
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Неправильний тип данних\r\n" + ex.Message);
                return;
            }
            if (TestClass.QisSelected)
            {
                TestClass.qq.questions[TestClass.Qselected] = sv;
            }
            else
            {
                TestClass.qq.Size++;
                Array.Resize(ref TestClass.qq.questions, TestClass.qq.Size);
                
                TestClass.qq.questions[TestClass.qq.Size - 1] = sv;
            }
            try
            {
                
                Close();
                TestCreation t = new TestCreation();
                t.Show();
                t.Location = this.Location;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            TestCreation t = new TestCreation();
            t.Show();
            t.Location = this.Location;
        }
    }
}
