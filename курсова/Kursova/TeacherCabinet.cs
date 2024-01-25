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
    public partial class TeacherCabinet : Form
    {
        public TeacherCabinet()
        {

            
            InitializeComponent();
            string data = File.ReadAllText("test.json");
            TestClass.T = JsonConvert.DeserializeObject<TestClass.gt>(data);
            if (TestClass.TisSelected)
            {
                TestClass.TisSelected = false;
            }
            TestClass.Tnew = true;
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
            //видалення 
            Button btn = sender as Button;
            TestClass.Test[] temp;
            temp = Array.Empty<TestClass.Test>();
            for (int i=0;i < TestClass.T.Size; i++)
            {
                if (i != int.Parse(btn.Name.Remove(0, 1))-1)
                {
                    var templist = temp.ToList();
                    templist.Add(TestClass.T.allT[i]);
                    temp = templist.ToArray();
                }
            }
            TestClass.T.Size -= 1;
            TestClass.T.allT = temp;
            string output = JsonConvert.SerializeObject(TestClass.T);
            File.WriteAllText("test.json", output);
            Close();
            TeacherCabinet t = new TeacherCabinet();
            t.Show();
            t.Location = this.Location;
            
        }
        void r_button_click(object sender, EventArgs e)
        {
            //редагування 
            Button btn = sender as Button;
            TestClass.Tselected = int.Parse(btn.Name.Remove(0, 1)) - 1;
            TestClass.TisSelected = true;
            TestClass.Tnew = true;
            TestClass.qq = TestClass.T.allT[TestClass.Tselected];
            
            Close();
            TestCreation t = new TestCreation();
            t.Show();
            t.Location = this.Location;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TestClass.qq.Name = "";
            TestClass.qq.Size = 0;
            TestClass.qq.questions = Array.Empty<TestClass.Question>();
            Close();
            TestCreation t = new TestCreation();
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
    }
}
