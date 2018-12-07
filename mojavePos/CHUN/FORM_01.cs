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
    //로그인 화면
    public partial class FORM_01 : Form
    {
        int sX = 750, sY = 450; // 폼 사이즈 지정.
        ///////// 좌표 체크시 추가 /////////
        static ToolStripStatusLabel StripLb;
        StatusStrip statusStrip;
        /////////////////////////////////////

        public FORM_01()
        {
            InitializeComponent();
            Load += FORM_01_Load;
        }

        private void FORM_01_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(sX, sY);  // 폼 사이즈 지정

            _Create ct = new _Create();
            Point_Print();

            // 제목라벨
            lbSet lb1 = new lbSet(this, "label1", "ELBON", 500, 50, 275, 10, 40);
            Label 라벨 = ct.lable(lb1);
            Controls.Add(라벨);
            
            // 제목라벨2
            lbSet lb2 = new lbSet(this, "label2", "the table", 300, 50, 320, 70, 20);
            Label 라벨2 = ct.lable(lb2);
            Controls.Add(라벨2);

            // 제목 패널
            pnSet pn1 = new pnSet(this, 750, 110, 0, 0);
            Panel 패널 = ct.panel(pn1);
            패널.BackColor = Color.CadetBlue;
            Controls.Add(패널);   //패널 화면 출력
            패널.Controls.Add(라벨);    //패널 위에 라벨 출력
            패널.Controls.Add(라벨2);

            //아이디 라벨
            lbSet lb3 = new lbSet(this, "label3", "Name / Position", 150, 20, 190,50, 15);
            Label 라벨3 = ct.lable(lb3);
            라벨3.BackColor = Color.White;
            Controls.Add(라벨3);

            //비밀번호 라벨
            lbSet lb4 = new lbSet(this, "label4", "Password", 150, 20, 190, 100, 15);
            Label 라벨4 = ct.lable(lb4);
            라벨4.BackColor = Color.White;
            Controls.Add(라벨4);

            //아이디 텍스트박스
            tbSet tx1 = new tbSet(this, "txt1", 200, 35, 370, 50);
            TextBox test = ct.txtbox(tx1);
            Controls.Add(test);

            //비밀번호 텍스트박스
            tbSet tx2 = new tbSet(this, "txt2", 200, 35, 370, 100);
            TextBox test2 = ct.txtbox(tx2);
            Controls.Add(test2);

            //로그인 패널
            pnSet pn2 = new pnSet(this, 750, 170, 0, 110);
            Panel 패널2 = ct.panel(pn2);
            패널2.BackColor = Color.White;
            Controls.Add(패널2);   //패널 화면 출력
            패널2.Controls.Add(라벨3);    //패널 위에 라벨 출력
            패널2.Controls.Add(라벨4);
            패널2.Controls.Add(test);
            패널2.Controls.Add(test2);

            //로그인 버튼
            btnSet 버튼객체1 = new btnSet(this, "button", "로그인", 250, 40, 260, 40,btn_Click);
            Button 버튼생성1 = ct.btn(버튼객체1);
            Controls.Add(버튼생성1);

            //계정만들기 버튼
            btnSet 버튼객체2 = new btnSet(this, "button", "계정만들기", 130, 30, 320, 90,btn2_Click);
            Button 버튼생성2 = ct.btn(버튼객체2);
            Controls.Add(버튼생성2);

            //끝 패널
            pnSet pn3 = new pnSet(this, 750, 150, 0, 280);
            Panel 패널3 = ct.panel(pn3);
            패널3.BackColor = Color.White;
            Controls.Add(패널3);   //패널 화면 출력
            패널3.Controls.Add(버튼생성1);
            패널3.Controls.Add(버튼생성2);
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

        ///////////////////////// 좌표 체크시 추가 /////////////////////////////

        private void Point_Print()
        {

            MouseMove += new MouseEventHandler(this.Current_FORM_MouseMove);
            statusStrip = new StatusStrip();
            StripLb = new ToolStripStatusLabel();
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { StripLb });
            statusStrip.Location = new Point(0, sY);
            statusStrip.Name = "statusStrip1";
            statusStrip.Size = new Size(sX, 22);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            // toolStripStatusLabel1
            StripLb.Name = "StripLb1";
            StripLb.Size = new Size(121, 17);
            StripLb.Text = "StripLb1";
            Controls.Add(statusStrip);
        }
        private void Current_FORM_MouseMove(object sender, MouseEventArgs e)
        {
            StripLb.Text = "(" + e.X + ", " + e.Y + ")";
        }
        ///////////////////////////////////////////////////////////////////////
    }
}
