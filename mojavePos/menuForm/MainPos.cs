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
    public partial class MainPos : Form
    {
        _Create ct= new _Create();
        private Panel pn4;
        private Commons comm;

        public MainPos()
        {
            InitializeComponent();
            Load += MainPos_Load;
           
            //this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void MainPos_Load(object sender, EventArgs e)
        {
            comm = new Commons();
            this.IsMdiContainer = true;
            this.ClientSize = new Size(1500, 900);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            Mainup_Load();
            btn_Load();
        }

        //메인Pos 상단바 UI
        private void Mainup_Load()
        {
            ArrayList arr = new ArrayList();

            arr.Add(new pnSet(this, 300, 100, 0, 0));
            arr.Add(new pnSet(this, 900, 100, 300, 0));
            arr.Add(new pnSet(this, 300, 100, 1200, 0));
            
            Panel pnl = new Panel();
            pnl = ct.panel((pnSet)arr[0]);
            pnl.BackColor = Color.Blue;
            Controls.Add(pnl);

            PictureBox mojave = new PictureBox();
            mojave.Image = (Bitmap)mojavePos.Properties.Resources.ResourceManager.GetObject("mojave");
            mojave.SizeMode = PictureBoxSizeMode.StretchImage;
            mojave.Size = new Size(300, 100);
            mojave.Location = new Point(0, 0);
            pnl.Controls.Add(mojave);

            Panel pnl2 = new Panel();
            pnl2 = ct.panel((pnSet)arr[1]);
            pnl2.BackColor = Color.Gainsboro;
            Controls.Add(pnl2);

            Panel pnl3 = new Panel();
            pnl3 = ct.panel((pnSet)arr[2]);
            pnl3.BackColor = Color.Silver;
            pnl3.Click += Pnl3_Click;
            Controls.Add(pnl3);
            
            arr.Add(new lbSet(this, "라벨1", "MojavePos System", 400, 70, 300, 20, 40));
            arr.Add(new lbSet(this, "라벨2", "종료", 150, 50, 100, 20, 35));
            
            Label label1 = ct.lable((lbSet)arr[3]);
            pnl2.Controls.Add(label1);

            Label label2 = ct.lable((lbSet)arr[4]);
            pnl3.Controls.Add(label2);

            arr.Add(new pnSet(this, 1500, 800, 0, 100));
            pn4 = new Panel();
            pn4.Name = "contents";
            pn4 = ct.panel((pnSet)arr[5]);
            pn4.BackColor = Color.Beige;
            Controls.Add(pn4);

        }
        //종료버튼 클릭시 이벤트
        private void Pnl3_Click(object sender, EventArgs e)
        {
            Dispose();
            FORM_03 f3 = new FORM_03();
            f3.Show();
        }
        //버튼 UI
        private void btn_Load()
        {
            ArrayList arrayList = new ArrayList();
            
            arrayList.Add(new pnSet(this, 5, 310, 620, 40));
            arrayList.Add(new pnSet(this, 5, 310, 620, 450));
            arrayList.Add(new btnSet(this,"table1"," 1", 200, 310, 100, 40,btn_Click));
            arrayList.Add(new btnSet(this, "table2", "2", 200, 310, 350, 40, btn_Click));
            arrayList.Add(new btnSet(this, "table3", "3", 200, 310, 100, 450, btn_Click));
            arrayList.Add(new btnSet(this, "table4", "4", 200, 310, 350, 450, btn_Click));
            arrayList.Add(new btnSet(this, "table5", "5", 200, 150, 700, 40, btn_Click));
            arrayList.Add(new btnSet(this, "table6", "6", 200, 150, 700, 200, btn_Click));
            arrayList.Add(new btnSet(this, "table7", "7", 200, 150, 950, 40, btn_Click));
            arrayList.Add(new btnSet(this, "table8", "8", 200, 150, 950, 200, btn_Click));
            arrayList.Add(new btnSet(this, "table9", "9", 200, 150, 1200, 40, btn_Click));
            arrayList.Add(new btnSet(this, "table10", "10", 200, 150, 1200, 200, btn_Click));
            arrayList.Add(new btnSet(this, "table11", "11", 200, 150, 700, 450, btn_Click));
            arrayList.Add(new btnSet(this, "table12", "12", 200, 150, 700, 610, btn_Click));
            for (int i = 0; i<arrayList.Count; i++)
            {
                if(typeof(pnSet) == arrayList[i].GetType())
                {
                    Panel panel =  ct.panel((pnSet)arrayList[i]);
                    panel.BackColor = Color.Silver;
                    pn4.Controls.Add(panel);
                }
                if (typeof(btnSet) == arrayList[i].GetType())
                {
                    Button btn = ct.btn((btnSet)arrayList[i]);
                    pn4.Controls.Add(btn);
                }
            }
        }
        //버튼 이벤트
        private void btn_Click(object sender, EventArgs e)
        {
            CountView cv = new CountView();
            cv.MdiParent = this;
            cv.WindowState = FormWindowState.Maximized;
            cv.FormBorderStyle = FormBorderStyle.None;
            pn4.Controls.Add(cv);
            cv.Show();
        }
    }
}
