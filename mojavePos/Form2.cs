using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mojavePos
{
    public partial class Form2 : Form
    {
        private Panel pn1;

        public Form2()
        {
            InitializeComponent();
            Load += Form2_Load;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            _Create ct = new _Create();
            this.IsMdiContainer = true;

            ArrayList arr = new ArrayList();

            arr.Add(new pnSet(this, 400, 400, 0, 0));
            pn1 = ct.panel((pnSet)arr[0]);
            Controls.Add(pn1);

            arr.Add(new btnSet(this, "1", "1", 100, 100, 50, 50, btn_Click));
            arr.Add(new btnSet(this, "1", "1", 100, 100, 150, 150, btn_Click));
            Button btn = ct.btn((btnSet)arr[1]);
            pn1.Controls.Add(btn);
            Button btn2 = ct.btn((btnSet)arr[2]);
            pn1.Controls.Add(btn2);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.MdiParent = this;
            f3.WindowState = FormWindowState.Maximized;
            f3.FormBorderStyle = FormBorderStyle.None;
            pn1.Controls.Add(f3);
            f3.Show();
        }
    }
}
