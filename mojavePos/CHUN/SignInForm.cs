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
    public partial class FORM_02 : Form
    {
        int sX = 750, sY = 450;

        static ToolStripStatusLabel StripLb;
        StatusStrip statusStrip;

        public FORM_02()
        {
            InitializeComponent();
            Load += FORM_02_Load;
        }

        private void FORM_02_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(sX, sY);

            _Create ct = new _Create();
            Point_Print();

            //Name 라벨 출력
            lbSet lb1 = new lbSet(this, "label1", "Name", 50, 15, 90, 50, 10);
            Label 라벨1 = ct.lable(lb1);
            Controls.Add(라벨1);

            //Name 텍스트박스 출력
            tbSet tx1 = new tbSet(this, "txt1", 170, 30, 30, 70);
            TextBox 네임택박 = ct.txtbox(tx1);
            Controls.Add(네임택박);

            //Postion 라벨 출력
            lbSet lb2 = new lbSet(this, "label2", "Postion", 100, 15, 80, 110, 10);
            Label 라벨2 = ct.lable(lb2);
            Controls.Add(라벨2);

            //Postion 텍스트박스 출력
            tbSet tx2 = new tbSet(this, "txt2", 170, 30, 30, 130);
            TextBox 포지션택박 = ct.txtbox(tx2);
            Controls.Add(포지션택박);

            //Password 라벨 출력
            lbSet lb3 = new lbSet(this,"label3", "Password", 100, 15, 70, 170, 10);
            Label 라벨3 = ct.lable(lb3);
            Controls.Add(라벨3);

            //Password 텍스트박스 출력
            tbSet tx3 = new tbSet(this, "txt3", 170, 30, 30, 190);
            TextBox 패스워드택박 = ct.txtbox(tx3);
            Controls.Add(패스워드택박);

            //Serial 라벨 출력
            lbSet lb4 = new lbSet(this, "label4", "Serial Number", 100, 15, 70, 230, 10);
            Label 라벨4 = ct.lable(lb4);
            Controls.Add(라벨4);

            //Serial 텍스트박스 출력
            tbSet tx4 = new tbSet(this, "txt4", 170, 30, 30, 250);
            TextBox 시리얼택박 = ct.txtbox(tx4);
            Controls.Add(시리얼택박);

            btnSet Btn1_pn1 = new btnSet(this, "Btn1_pn1", "가입", 80, 30, 55, 330, btn_Click);
            Button 가입버튼 = ct.btn(Btn1_pn1);
            Controls.Add(가입버튼);

            btnSet Btn2_pn1 = new btnSet(this, "Btn2_pn1", "취소", 80, 30, 155, 330, btn2_Click);
            Button 취소버튼 = ct.btn(Btn2_pn1);
            Controls.Add(취소버튼);

            //왼쪽 패널 출력
            pnSet pn1 = new pnSet(this, 240, 370, 30, 30);
            Panel 패널 = ct.panel(pn1);
            패널.BackColor = Color.AliceBlue;
            Controls.Add(패널); //패널 안에 라벨 텍스트박스 출력
            패널.Controls.Add(라벨1);
            패널.Controls.Add(라벨2);
            패널.Controls.Add(라벨3);
            패널.Controls.Add(라벨4);
            패널.Controls.Add(네임택박);
            패널.Controls.Add(포지션택박);
            패널.Controls.Add(패스워드택박);
            패널.Controls.Add(시리얼택박);


            lbSet lb5 = new lbSet(this, "label5", "- ELBON the table 을 위한 포스기.", 240, 15, 15, 60, 10);
            Label 라벨5 = ct.lable(lb5);
            Controls.Add(라벨5);

            lbSet lb6 = new lbSet(this, "label6", "Mojave of Pos", 200, 20, 250, 53, 17);
            Label 라벨6 = ct.lable(lb6);
            Controls.Add(라벨6);

            lbSet lb7 = new lbSet(this,"label7", "1. Mojave of Pos 는 'Mojave/모하비'에서 제작하였습니다.", 350, 15, 15, 120, 8);
            Label 라벨7 = ct.lable(lb7);
            Controls.Add(라벨7);

            lbSet lb8 = new lbSet(this, "label8", "2. Mojave of Pos는 ELBON the table의 효율적인 재정관리를 할 수 있도\n록돕기 위해 제작 되었습니다.", 450, 30, 15, 150, 8);
            Label 라벨8 = ct.lable(lb8);
            Controls.Add(라벨8);

            lbSet lb9 = new lbSet(this, "label9", "3. Mojave of Pos는 자체 제공한 시리얼넘버로 하나의 아이디만 회원가입\n할수 있습니다.", 400, 30, 15, 180, 8);
            Label 라벨9 = ct.lable(lb9);
            Controls.Add(라벨9);

            lbSet lb10 = new lbSet(this, "label10", "4. Mojave of Pos는 비밀번호찾기 기능을 따로 제공하지 않습니다.", 400, 15, 15, 210, 8);
            Label 라벨10 = ct.lable(lb10);
            Controls.Add(라벨10);

            lbSet lb11 = new lbSet(this, "label6", "5. Mojave of Pos안의 ELBON the table 정보는 절대 외부에 공개 하지\n않습니다.", 400, 30, 15, 240, 8);
            Label 라벨11 = ct.lable(lb11);
            Controls.Add(라벨11);

            lbSet lb12 = new lbSet(this, "label12", "6. Mojave of Pos는 포스기에 최적화 되어 있습니다.", 400, 15, 15, 270, 8);
            Label 라벨12 = ct.lable(lb12);
            Controls.Add(라벨12);

            lbSet lb13 = new lbSet(this, "label13", "만든이 : ", 100, 15, 15, 300, 8);
            Label 라벨13 = ct.lable(lb13);
            Controls.Add(라벨13);

            lbSet lb14 = new lbSet(this, "label13", "문의사항 : question@MojaveKorea.co.kr", 300, 15, 15, 330, 8);
            Label 라벨14 = ct.lable(lb14);
            Controls.Add(라벨14);


            //오른쪽 패널 출력
            pnSet pn2 = new pnSet(this, 420, 370, 300, 30);
            Panel 패널2 = ct.panel(pn2);
            패널2.BackColor = Color.AliceBlue;
            Controls.Add(패널2);   //패널 화면 출력
            패널2.Controls.Add(라벨5);
            패널2.Controls.Add(라벨6);
            패널2.Controls.Add(라벨7);
            패널2.Controls.Add(라벨8);
            패널2.Controls.Add(라벨9);
            패널2.Controls.Add(라벨10);
            패널2.Controls.Add(라벨11);
            패널2.Controls.Add(라벨12);
            패널2.Controls.Add(라벨13);
            패널2.Controls.Add(라벨14);
        }
        private void btn_Click(object sender, EventArgs e)
        {
            FORM_01 F1 = new FORM_01();
            this.Dispose(false);
            F1.Show();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            FORM_01 F1 = new FORM_01();
            this.Dispose(false);
            F1.Show();
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

