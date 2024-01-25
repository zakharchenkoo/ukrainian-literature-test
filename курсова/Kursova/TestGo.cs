using ReadWriteBinaryFile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;
using System.Reflection;

namespace Kursova
{
    public partial class TestGo : Form
    {

        TestClass.Question sv = new TestClass.Question();
        public TestGo()
        {
            InitializeComponent();
            p2.Location = new Point(p1.Location.X, p1.Location.Y-45);
            p3.Location = p1.Location;
            RLoad(TestClass.curTest);
             label2.Text = TestClass.qq.Name;  
            
        }

        private void RLoad(int index)
        {
           

            sv = TestClass.qq.questions[TestClass.btest[index]];


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
            Lquestion.Text = sv.qx;
            switch (sv.type)
            {
                case 0:
                    p1_t1.Text = sv.q1;
                    p1_t2.Text = sv.q2;
                    p1_t3.Text = sv.q3;
                    p1_t4.Text = sv.q4;
                    break;
                case 1:
                    ArrayList l = new ArrayList();
                    p2_t1.Text = sv.q1;
                    p2_t2.Text = sv.q2;
                    p2_t3.Text = sv.q3;
                    p2_t4.Text = sv.q4;
                    
                    l.Add(sv.r1);
                    l.Add(sv.r2);
                    l.Add(sv.r3);
                    l.Add(sv.r4);
                    RandomOrder(l, p2_r1);
                    RandomOrder(l, p2_r2);
                    RandomOrder(l, p2_r3);
                    RandomOrder(l, p2_r4);
                    
                    break;
                case 2:
                    p3_t1.Text = sv.q1;
                    p3_t2.Text = sv.q2;
                    p3_t3.Text = sv.q3;
                    p3_t4.Text = sv.q4;

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
        public void RandomOrder(ArrayList arrList, ComboBox box)
        {
            Random r = new Random();
            for (int cnt = 0; cnt < arrList.Count; cnt++)
            {
                object tmp = arrList[cnt];
                int idx = r.Next(arrList.Count - cnt) + cnt;
                arrList[cnt] = arrList[idx];
                arrList[idx] = tmp;
            }

            box.Items.Clear();
            box.Items.Add(arrList[0]);
            box.Items.Add(arrList[1]);
            box.Items.Add(arrList[2]);
            box.Items.Add(arrList[3]);


        }

        private void p1_t1_Click(object sender, EventArgs e)
        {
            Answer(1);
        }

        private void p1_t2_Click(object sender, EventArgs e)
        {
            Answer(2);
        }

        private void p1_t3_Click(object sender, EventArgs e)
        {
            Answer(3);
        }

        private void p1_t4_Click(object sender, EventArgs e)
        {
            Answer(4);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (p3_t1.Checked == stb(sv.r1) && p3_t2.Checked == stb(sv.r2) && p3_t3.Checked == stb(sv.r3) && p3_t4.Checked == stb(sv.r4))
            {
                TestClass.Answers[TestClass.goS].Mark++;
            }
            TestEnd();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(p2_r1.Text == sv.r1 && p2_r2.Text == sv.r2 && p2_r3.Text == sv.r3 && p2_r4.Text == sv.r4)
            {
                TestClass.Answers[TestClass.goS].Mark++;
            }
            TestEnd();
        }
        private void Answer(int a)
        {
            switch(a){
                case 1:
                    if(sv.r1 == "1")
                    {
                        TestClass.Answers[TestClass.goS].Mark++;
                    }
                    break;
                case 2:
                    if (sv.r2 == "1")
                    {
                        TestClass.Answers[TestClass.goS].Mark++;
                    }
                    break;
                case 3:
                    if (sv.r3 == "1")
                    {
                        TestClass.Answers[TestClass.goS].Mark++;
                    }
                    break;
                case 4:
                    if (sv.r4 == "1")
                    {
                        TestClass.Answers[TestClass.goS].Mark++;
                    }
                    break;
            }
            TestEnd();
           
        }
        private void TestEnd()
        {
            if (TestClass.curTest < TestClass.qq.banksize - 1)
            {
                TestClass.curTest++;
                Close();
                TestGo t = new TestGo();
                t.Show();
                t.Location = this.Location;
            }
            else
            {
                Close();
                EndTest t = new EndTest();
                t.Show();
                t.Location = this.Location;
            }
        }
    }
}
