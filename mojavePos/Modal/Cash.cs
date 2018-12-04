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

namespace mojavePos.Modal
{
    public partial class Cash : Form
    {
        _Create ct = new _Create();
        public Cash()
        {
            InitializeComponent();
            Load += Cash_Load;
        }

        private void Cash_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(900,500);
            pnSet pn = new pnSet(this, 400, 400, 50, 50);
            Panel panel = ct.panel(pn);
            //Controls.Add(panel);
            ArrayList arr = new ArrayList();
            
            arr.Add(new lbSet(this, "lb1", "현금결제", 500, 30, 400, 20, 20));
            arr.Add(new lbSet(this, "lb2", "받을 금액", 100, 30, 30, 100, 15));
            arr.Add(new lbSet(this, "lb3", "결제 금액", 100, 30, 30, 200, 15));
            arr.Add(new lbSet(this, "lb1", "거스름돈", 100, 30, 30, 300, 15));
            arr.Add(new btnSet(this, "button", "결제완료", 380, 50, 30, 430, btn_Click));
            arr.Add(new tbSet(this, "tb1", 250, 30, 150, 100));
            arr.Add(new tbSet(this, "tb2", 250, 30, 150, 200));
            arr.Add(new tbSet(this, "tb2", 250, 30, 150, 300));

            for (int i = 0; i < arr.Count; i++)
            {
                if(typeof(lbSet) == arr[i].GetType())
                {
                    Label label = ct.lable((lbSet)arr[i]);
                    panel.Controls.Add(label);
                }
                else if(typeof(btnSet) == arr[i].GetType())
                {
                    Button button = ct.btn((btnSet)arr[i]);
                    panel.Controls.Add(button);
                }
                else if (typeof(tbSet) == arr[i].GetType())
                {
                    TextBox textbox = ct.txtbox((tbSet)arr[i]);
                    panel.Controls.Add(textbox);
                }
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
        }
    }
}
