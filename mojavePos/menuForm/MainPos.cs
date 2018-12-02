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
        public MainPos()
        {
            InitializeComponent();
            Load += MainPos_Load;
        }

        private void MainPos_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(1500, 900);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
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

            Panel pnl2 = new Panel();
            pnl2 = ct.panel((pnSet)arr[1]);
            pnl2.BackColor = Color.Gainsboro;
            Controls.Add(pnl2);

            Panel pnl3 = new Panel();
            pnl3 = ct.panel((pnSet)arr[2]);
            pnl3.BackColor = Color.Green;
            pnl3.Click += Pnl3_Click;
            Controls.Add(pnl3);

            arr.Add(new lbSet(this, "라벨1", "MojavePos System", 400, 70, 300, 20, 40));
            arr.Add(new lbSet(this, "라벨2", "종료", 150, 50, 100, 20, 35));
            Label label1 = ct.lable((lbSet)arr[3]);
            pnl2.Controls.Add(label1);

            Label label2 = ct.lable((lbSet)arr[4]);
            pnl3.Controls.Add(label2);

        }
        //종료버튼 클릭시 이벤트
        private void Pnl3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("asdas");
        }
        //버튼 UI
        private void btn_Load()
        {
            ArrayList arrayList = new ArrayList();
            pnSet pn1 = new pnSet(this, 5, 310, 620, 140);
            Panel back = ct.panel(pn1);
            back.BackColor = Color.Silver;
            Controls.Add(back);
            pnSet pn2 = new pnSet(this, 5, 310, 620, 550);
            Panel back2 = ct.panel(pn2);
            back2.BackColor = Color.Silver;
            Controls.Add(back2);

            arrayList.Add(new btnSet(this,"table1"," 1", 200, 310, 100, 140,btn_Click));
            arrayList.Add(new btnSet(this, "table2", "2", 200, 310, 350, 140, btn_Click));
            arrayList.Add(new btnSet(this, "table3", "3", 200, 310, 100, 550, btn_Click));
            arrayList.Add(new btnSet(this, "table4", "4", 200, 310, 350, 550, btn_Click));
            arrayList.Add(new btnSet(this, "table5", "5", 200, 150, 700, 140, btn_Click));
            arrayList.Add(new btnSet(this, "table6", "6", 200, 150, 700, 300, btn_Click));
            arrayList.Add(new btnSet(this, "table7", "7", 200, 150, 950, 140, btn_Click));
            arrayList.Add(new btnSet(this, "table8", "8", 200, 150, 950, 300, btn_Click));
            arrayList.Add(new btnSet(this, "table9", "9", 200, 150, 1200, 140, btn_Click));
            arrayList.Add(new btnSet(this, "table10", "10", 200, 150, 1200, 300, btn_Click));
            arrayList.Add(new btnSet(this, "table11", "11", 200, 150, 700, 550, btn_Click));
            arrayList.Add(new btnSet(this, "table12", "12", 200, 150, 700, 710, btn_Click));
            for (int i = 0; i<arrayList.Count; i++)
            {
                ct.btn((btnSet)arrayList[i]);
            }
        }
        //버튼 이벤트
        private void btn_Click(object sender, EventArgs e)
        {
            CountView cv = new CountView();
            cv.ClientSize = new Size(1450,880);
            cv.FormBorderStyle = FormBorderStyle.FixedSingle;
            cv.MaximizeBox = false;
            cv.MinimizeBox = false;
            cv.Show();
        }
    }
}
