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
    //로그인 화면
    public partial class FORM_01 : Form
    {
        _Create ct = new _Create();

        public FORM_01()
        {
            InitializeComponent();
            Load += FORM_01_Load;
        }

        private void FORM_01_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(750, 450);  // 폼 사이즈 지정

            // 제목 패널
            pnSet pn1 = new pnSet(this, 750, 110, 0, 0);
            Panel 패널 = ct.panel(pn1);
            패널.BackColor = Color.CadetBlue;
            Controls.Add(패널);   //패널 화면 출력

            ArrayList arr = new ArrayList();

            arr.Add(new lbSet(this, "lb1", "ELBON", 500, 50, 275, 10, 40));
            arr.Add(new lbSet(this, "lb2", "the table", 300, 50, 320, 70, 20));

            for (int i = 0; i < arr.Count; i++)
            {
                if (typeof(lbSet) == arr[i].GetType())
                {
                    Label label = ct.lable((lbSet)arr[i]);
                    패널.Controls.Add(label);
                }
            }

            //로그인 패널
            pnSet pn2 = new pnSet(this, 750, 170, 0, 110);
            Panel 패널2 = ct.panel(pn2);
            패널2.BackColor = Color.White;
            Controls.Add(패널2);

            ArrayList arr1 = new ArrayList();
            arr1.Add(new lbSet(this, "lb3", "Name / Position", 150, 20, 190, 50, 15));
            arr1.Add(new lbSet(this, "lb4", "Password", 150, 20, 190, 100, 15));
            arr1.Add(new tbSet(this, "tb1", 200, 35, 370, 50));
            arr1.Add(new tbSet(this, "tb2", 200, 35, 370, 100));

            for (int i = 0; i < arr1.Count; i++)
            {
                if (typeof(lbSet) == arr1[i].GetType())
                {
                    Label label = ct.lable((lbSet)arr1[i]);
                    패널2.Controls.Add(label);
                }
                else if (typeof(tbSet) == arr1[i].GetType())
                {
                    TextBox textbox = ct.txtbox((tbSet)arr1[i]);
                    textbox.ReadOnly = true;
                    패널2.Controls.Add(textbox);
                }
            }
            //끝 패널
            pnSet pn3 = new pnSet(this, 750, 150, 0, 280);
            Panel 패널3 = ct.panel(pn3);
            패널3.BackColor = Color.White;
            Controls.Add(패널3);   //패널 화면 출력

            ArrayList arr2 = new ArrayList();

            arr2.Add(new btnSet(this, "button", "로그인", 250, 40, 260, 40, btn_Click));
            arr2.Add(new btnSet(this, "button", "계정만들기", 130, 30, 320, 90, btn2_Click));
            for (int i = 0; i < arr2.Count; i++)
            {
                if (typeof(btnSet) == arr2[i].GetType())
                {
                    Button button = ct.btn((btnSet)arr2[i]);
                    패널3.Controls.Add(button);
                }
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            FORM_03 F3 = new FORM_03();
            this.Dispose(false);
            F3.Show();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            FORM_02 F2 = new FORM_02();
            this.Dispose(false);
            F2.Show();
        }

    }
}
