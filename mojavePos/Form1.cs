using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _Create ct = new _Create();

            lbSet lb1 = new lbSet(this, "label1", "라벨이다asdfdsafa \n라벨.", 500, 300, 100, 100,10);
            Label 라벨1 = ct.lable(lb1);
            pnSet pn1 = new pnSet(this, 300, 300, 30, 30 );
            Panel 패널 = ct.panel(pn1);
            패널.BackColor = Color.Aqua;
            btnSet btn1 = new btnSet(this, "btn1", "버튼", 50, 50, 100, 70, btn_Click);
            Button button = ct.btn(btn1);

            Controls.Add(button);
            패널.Controls.Add(라벨1);
            Controls.Add(패널);

        }

        private void btn_Click(object sender, EventArgs e)
        {

        }
    }
}
