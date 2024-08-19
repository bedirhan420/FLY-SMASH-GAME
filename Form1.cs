using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace sinek_avı_güncel
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 a = new Form2();
            a.ShowDialog();
       
           
        }
    }
}
