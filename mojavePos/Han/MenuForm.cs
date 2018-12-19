using mojavePos.CHUN;
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

namespace mojavePos.Han
{
    public partial class MenuForm : Form
    {
        _Create ct = new _Create();
        Panel bottom;
        private Graphics gr;

        public MenuForm()
        {
            InitializeComponent();
            Load += MenuForm_Load;
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(1500, 800);

            pnSet pn2 = new pnSet(this, 1500, 800, 0, 0);
            bottom = ct.panel(pn2); // 패널이름 : bottom
            Controls.Add(bottom);

            ArrayList arr = new ArrayList();

            arr.Add(new lbSet(this, "lb1", "Category", 200, 35, 350, 80, 25));
            arr.Add(new btnSet(this, "btn_1", "//사진으로 대체", 30, 30, 460, 125, btn_Click));
            arr.Add(new pictureBoxSet(this, 40, 40, 410, 120, " "));
            arr.Add(new lbSet(this, "lb2", "Menu", 200, 35, 1000, 80, 25));
            arr.Add(new btnSet(this, "btn_2", "//사진으로 대체", 30, 30, 1060, 125, btn2_Click));
            arr.Add(new pictureBoxSet(this, 40, 40, 1010, 120, " "));

            for (int i = 0; i < arr.Count; i++)
            {
                if (typeof(lbSet) == arr[i].GetType())
                {
                    Label label = ct.lable((lbSet)arr[i]);
                    bottom.Controls.Add(label);
                }
                else if (typeof(btnSet) == arr[i].GetType())
                {
                    Button button = ct.btn((btnSet)arr[i]);
                    bottom.Controls.Add(button);
                }
                else if (typeof(pictureBoxSet) == arr[i].GetType())
                {
                    PictureBox picuturebox = ct.picture((pictureBoxSet)arr[i]);
                    picuturebox.BackColor = Color.Green;
                    bottom.Controls.Add(picuturebox);

                }
            }
            /*-----------*/
            gr = this.CreateGraphics();
            Pen pen1 = new Pen(Color.Black, 1);
            pen1.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            Point First = new Point(300, 300);
            Point Second = new Point(1200, 300);
            /*-----------*/

            bottom.BackColor = Color.BurlyWood;
            /*----------------------------*/


        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "btn_1":
                    Menu_modal Me_mo = new Menu_modal();
                    Me_mo.Location = new Point(100, 100);
                    Me_mo.StartPosition = FormStartPosition.Manual;
                    Me_mo.Location = new System.Drawing.Point(240, 30); //모달 처음 위치값 지정<나중에 바꾸기>
                    Me_mo.BackColor = Color.Black;
                    Me_mo.Show();
                    break;
            }

        }
        private void btn2_Click(object sender, EventArgs e)
        {

        }
    }
}
