using Newtonsoft.Json;
using ReadWriteBinaryFile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Kursova
{
    public partial class TestCreation : Form
    {
        public TestCreation()
        {
            InitializeComponent();
            textBox1.Text = TestClass.qq.Name;
            textBox2.Text = TestClass.qq.banksize.ToString();
            if (TestClass.QisSelected)
            {
                TestClass.QisSelected = false;
            }
            if (TestClass.TisSelected)
            {
                
                
                button3.Visible = true;
            }
            else if(TestClass.Tnew)
            {
                TestClass.Tnew = false;
            }
            //----------------
            for (int i = 0; i <= TestClass.qq.Size-1; i++)
            {
                Panel p = new Panel();
                p.BackColor = Color.Gainsboro;
                p.Size = new Size(700, 80);
                p.Location = new Point(0, i * 96);
                // -------------
                Label name = new Label();
                name.Text = TestClass.qq.questions[i].qx;
                name.Font = new Font("Arial", 12, FontStyle.Bold);
                name.AutoSize = false;
                name.Size = new Size(560, 80);
                name.TextAlign = ContentAlignment.MiddleLeft;
                Button del = new Button();
                Button red = new Button();
                // -------------
                del.Size = new Size(120, 30);
                del.Location = new Point(570, 45);
                del.Text = "Видалити";

                red.Size = new Size(120, 30);
                red.Location = new Point(570, 10);
                red.Text = "Редагувати";
                // -------------
                p.Controls.Add(name);
                p.Controls.Add(del);
                p.Controls.Add(red);
                del.Name = "d" + (i + 1);
                red.Name = "r" + (i + 1);
                del.Click += new EventHandler(this.d_button_click);
                red.Click += new EventHandler(this.r_button_click);
                panel.Controls.Add(p);
            }
        }

        void d_button_click(object sender , EventArgs e)
        {
            //видалення нажате
            Button btn = sender as Button;
            TestClass.Test temp = new TestClass.Test();
            temp.questions = Array.Empty<TestClass.Question>();
            for (int i=0;i < TestClass.qq.Size; i++)
            {
                if (i != int.Parse(btn.Name.Remove(0, 1))-1)
                {
                    var templist = temp.questions.ToList();
                    templist.Add(TestClass.qq.questions[i]);
                    temp.questions = templist.ToArray();
                }
            }
            temp.Size = TestClass.qq.Size-1;
            temp.Name = TestClass.qq.Name;
            TestClass.qq = temp;
            //reload
            
            Close();
            TestCreation t = new TestCreation();
            t.Show();
            t.Location = this.Location;

        }
        void r_button_click(object sender, EventArgs e)
        {
            //редагування нажате
            Button btn = sender as Button;
            TestClass.Qselected = int.Parse(btn.Name.Remove(0, 1)) - 1;
            TestClass.QisSelected = true;
            Close();
            NewQ t = new NewQ();
            t.Show();
            t.Location = this.Location;
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            NewQ t = new NewQ();
            t.Show();
            t.Location = this.Location;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TestClass.TisSelected)
            {
                TestClass.T.allT[TestClass.Tselected] = TestClass.qq;
                string output = JsonConvert.SerializeObject(TestClass.T);
                File.WriteAllText("test.json", output);
            }
            else
            {
                TestClass.T.Size++;
                Array.Resize(ref TestClass.T.allT, TestClass.T.Size);

                TestClass.T.allT[TestClass.T.Size - 1] = TestClass.qq;
                string output = JsonConvert.SerializeObject(TestClass.T);
                File.WriteAllText("test.json", output);
            }
            Close();
            TeacherCabinet t = new TeacherCabinet();
            t.Show();
            t.Location = this.Location;
            
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TestClass.qq.Name = textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            TeacherCabinet t = new TeacherCabinet();
            t.Show();
            t.Location = this.Location;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TestClass.qq.banksize = Convert.ToInt32(textBox2.Text);
        }
    }
}
