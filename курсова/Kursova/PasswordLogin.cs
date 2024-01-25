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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Kursova
{
    public partial class PasswordLogin : Form
    {
        public PasswordLogin()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Login t = new Login();
            t.Show();
            t.Location = this.Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!TestClass.login)
            {
                //користувач
                if (textBox2.Text == "user" && textBox1.Text == "88888888")
                {
                    Close();
                    StudentCabinet t = new StudentCabinet();
                    t.Show();
                    t.Location = this.Location;
                }
                else
                {
                    label3.Text = "ПОМИЛКА, СПРОБУЙТЕ ЩЕ РАЗ";
                }
            }
            else
            {
                //адмін
                if (textBox2.Text == "admin" && textBox1.Text == "11111111")
                {
                    Close();
                    TeacherCabinet t = new TeacherCabinet();
                    t.Show();
                    t.Location = this.Location;
                }
                else
                {
                    label3.Text = "ПОМИЛКА, СПРОБУЙТЕ ЩЕ РАЗ";
                }
            }
            
        }
    }
}
