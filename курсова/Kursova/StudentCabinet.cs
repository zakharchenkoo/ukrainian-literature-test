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
    public partial class StudentCabinet : Form
    {

        public StudentCabinet()
        {

            
            InitializeComponent();
            string data = File.ReadAllText("test.json");
            TestClass.T = JsonConvert.DeserializeObject<TestClass.gt>(data);
            if (TestClass.TisSelected)
            {
                TestClass.TisSelected = false;
            }
            TestClass.Tnew = true;
            Array.Resize(ref TestClass.Answers, TestClass.T.Size);
            //----------------
            for (int i = 0; i < TestClass.T.Size; i++)
            {
               
                Panel p = new Panel();
                p.BackColor = Color.Gainsboro;
                p.Size = new Size(700, 80);
                p.Location = new Point(0, i * 96);
                // -------------
                Label name = new Label();
                name.Text = TestClass.T.allT[i].Name;
                name.Font = new Font("Arial", 12, FontStyle.Bold);
                name.AutoSize = false;
                name.Size = new Size(560, 80);
                name.TextAlign = ContentAlignment.MiddleLeft;
                // -------------
                TestClass.Answers[i].AllM = TestClass.T.allT[i].banksize;
                TestClass.Answers[i].selected = i;
                Label mark = new Label();
                mark.Text = TestClass.Answers[i].Mark +"/" +TestClass.Answers[i].AllM;
                mark.Font = new Font("Arial", 12, FontStyle.Bold);
                mark.AutoSize = false;
                mark.Size = new Size(60, 80);
                mark.Location = new Point(570);
                mark.TextAlign = ContentAlignment.MiddleLeft;
                //---------+----
                Button go = new Button();
                go.Size = new Size(60, 60);
                go.Location = new Point(630, 10);
                go.Text = "Пройти";
                // -------------
                p.Controls.Add(name);
                p.Controls.Add(mark);
                p.Controls.Add(go);
                go.Name = "g" + (i + 1);
                go.Click += new EventHandler(this.g_button_click);
                panel.Controls.Add(p);
            }
        }

        void g_button_click(object sender , EventArgs e)
        {
            //пройти 
            Button btn = sender as Button;
            TestClass.goS = int.Parse(btn.Name.Remove(0, 1)) - 1;
            TestClass.curTest = 0;
            TestClass.qq = TestClass.T.allT[TestClass.goS];
            Array.Resize(ref TestClass.btest, TestClass.qq.Size);
            for(int i = 0; i < TestClass.qq.Size; i++ )
            {
                TestClass.btest[i] = i;
            }
            Shuffle(TestClass.btest);
            TestClass.Answers[TestClass.goS].Mark = 0;
            Close();
            TestGo t = new TestGo();
            t.Show();
            t.Location = this.Location;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Login t = new Login();
            t.Show();
            t.Location = this.Location;
        }
        private void Shuffle(int[] arr)
        {
            Random rnd = new Random();
            for (int i = arr.Length; i > 1; i--)
            {
                int pos = rnd.Next(i);
                var x = arr[i - 1];
                arr[i - 1] = arr[pos];
                arr[pos] = x;
            }
        }
    }
}
