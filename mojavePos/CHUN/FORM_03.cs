using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using mojavePos.Han;

namespace mojavePos
{
    public partial class FORM_03 : Form
    {
        int sX = 1500, sY = 900;
        static ToolStripStatusLabel StripLb;
        StatusStrip statusStrip;
        lbSet pn4_lb;
        lbSet pn5_lb;

        public FORM_03()
        {
            InitializeComponent();
            Load += FORM_03_Load;
        }

        private void FORM_03_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(sX, sY);
            _Create ct = new _Create();
            this.StartPosition = FormStartPosition.Manual;
            Point_Print();

            //오늘매출액 파트 라벨
            lbSet pn1_lb1 = new lbSet(this, "label1", "오늘매출액", 120, 30, 50, 180, 15);
            Label 오늘매출액 = ct.lable(pn1_lb1);
            오늘매출액.TextAlign = ContentAlignment.MiddleCenter;
            오늘매출액.BackColor = Color.LightGreen;
            Controls.Add(오늘매출액);

            lbSet pn1_lb1_1 = new lbSet(this, "label1_1", "-", 200, 30, 170, 180, 15);
            Label 오늘매출액숫자 = ct.lable(pn1_lb1_1);
            오늘매출액숫자.TextAlign = ContentAlignment.MiddleCenter;
            오늘매출액숫자.BackColor = Color.LightGray;
            Controls.Add(오늘매출액숫자);

            lbSet pn1_lb1_2 = new lbSet(this, "label1_2", "원", 50, 30, 370, 180, 15);
            Label 오늘매출액원 = ct.lable(pn1_lb1_2);
            오늘매출액원.TextAlign = ContentAlignment.MiddleCenter;
            오늘매출액원.BackColor = Color.LightGray;
            Controls.Add(오늘매출액원);

            //오늘계산서수 파트 라벨
            lbSet pn1_lb2 = new lbSet(this, "pn1_lb2", "오늘계산서수", 120, 30, 50, 300, 15);
            Label 오늘계산서수 = ct.lable(pn1_lb2);
            오늘계산서수.TextAlign = ContentAlignment.MiddleCenter;
            오늘계산서수.BackColor = Color.LightYellow;
            Controls.Add(오늘계산서수);

            lbSet pn1_lb2_1 = new lbSet(this, "pn1_lb2_1", "-", 200, 30, 170, 300, 15);
            Label 오늘계산서숫자 = ct.lable(pn1_lb2_1);
            오늘계산서숫자.TextAlign = ContentAlignment.MiddleCenter;
            오늘계산서숫자.BackColor = Color.LightGray;
            Controls.Add(오늘계산서숫자);

            lbSet pn1_lb2_2 = new lbSet(this, "pn1_lb2_2", "개", 50, 30, 370, 300, 15);
            Label 오늘계산서갯수 = ct.lable(pn1_lb2_2);
            오늘계산서갯수.TextAlign = ContentAlignment.MiddleCenter;
            오늘계산서갯수.BackColor = Color.LightGray;
            Controls.Add(오늘계산서갯수);

            //이번달매출액 파트 라벨
            lbSet pn1_lb3 = new lbSet(this, "label3", "이번달매출액", 150, 30, 50, 420, 15);
            Label 이번달매출액 = ct.lable(pn1_lb3);
            이번달매출액.TextAlign = ContentAlignment.MiddleCenter;
            이번달매출액.BackColor = Color.LightGreen;
            Controls.Add(이번달매출액);

            lbSet pn1_lb3_1 = new lbSet(this, "pn1_lb3_1", "-", 200, 30, 170, 420, 15);
            Label 이번달매출액숫자 = ct.lable(pn1_lb3_1);
            이번달매출액숫자.TextAlign = ContentAlignment.MiddleCenter;
            이번달매출액숫자.BackColor = Color.LightGray;
            Controls.Add(이번달매출액숫자);

            lbSet pn1_lb3_2 = new lbSet(this, "pn1_lb3_2", "원", 50, 30, 370, 420, 15);
            Label 이번달매출액원 = ct.lable(pn1_lb3_2);
            이번달매출액원.TextAlign = ContentAlignment.MiddleCenter;
            이번달매출액원.BackColor = Color.LightGray;
            Controls.Add(이번달매출액원);

            //누적계산서 파트 라벨
            lbSet pn1_lb4 = new lbSet(this, "label2", "누적계산서수", 120, 30, 50, 540, 15);
            Label 누적계산서수 = ct.lable(pn1_lb4);
            누적계산서수.TextAlign = ContentAlignment.MiddleCenter;
            누적계산서수.BackColor = Color.LightYellow;
            Controls.Add(누적계산서수);

            lbSet pn1_lb4_1 = new lbSet(this, "pn1_lb4_1", "-", 200, 30, 170, 540, 15);
            Label 누적계산서숫자 = ct.lable(pn1_lb4_1);
            누적계산서숫자.TextAlign = ContentAlignment.MiddleCenter;
            누적계산서숫자.BackColor = Color.LightGray;
            Controls.Add(누적계산서숫자);

            lbSet pn1_lb4_2 = new lbSet(this, "pn1_lb4_2", "개", 50, 30, 370, 540, 15);
            Label 누적계산서갯수 = ct.lable(pn1_lb4_2);
            누적계산서갯수.TextAlign = ContentAlignment.MiddleCenter;
            누적계산서갯수.BackColor = Color.LightGray;
            Controls.Add(누적계산서갯수);

            //날짜라벨
            lbSet pn1_lb5 = new lbSet(this, "pn1_lb5", "//날짜", 370, 30, 50, 630, 15);
            Label 날짜 = ct.lable(pn1_lb5);
            날짜.TextAlign = ContentAlignment.MiddleCenter;

            //시간라벨
            lbSet pn1_lb6 = new lbSet(this, "pn1_lb6", "//시간", 370, 30, 50, 680, 15);
            Label 시간 = ct.lable(pn1_lb6);
            시간.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(시간);

            //왼쪽 부분 패널
            pnSet pn1 = new pnSet(this, 500, 750, 0, 0);
            Panel 패널1 = ct.panel(pn1);
            패널1.BackColor = Color.LightBlue;
            Controls.Add(패널1);   //패널 화면 출력
            패널1.Controls.Add(오늘매출액);
            패널1.Controls.Add(오늘매출액숫자);
            패널1.Controls.Add(오늘매출액원);

            패널1.Controls.Add(오늘계산서수);
            패널1.Controls.Add(오늘계산서숫자);
            패널1.Controls.Add(오늘계산서갯수);


            패널1.Controls.Add(이번달매출액);
            패널1.Controls.Add(이번달매출액숫자);
            패널1.Controls.Add(이번달매출액원);
            
            패널1.Controls.Add(누적계산서수);
            패널1.Controls.Add(누적계산서숫자);
            패널1.Controls.Add(누적계산서갯수);

            패널1.Controls.Add(날짜);
            패널1.Controls.Add(시간);

            //영업시작 파트
            //영업시작 버튼
            btnSet pn2_btn_1 = new btnSet(this, "pn2_btn_1", "//사진으로 대체", 130, 130, 140, 70, btn_Click);
            Button 영업시작버튼 = ct.btn(pn2_btn_1);
            Controls.Add(영업시작버튼);

            //영업시작 라벨
            lbSet pn2_lb1 = new lbSet(this, "pn2_lb1", "영업시작", 200, 33, 110, 210, 25);
            Label 영업시작 = ct.lable(pn2_lb1);
            영업시작.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(영업시작);

            //준비금 라벨
            lbSet pn2_lb2 = new lbSet(this, "pn2_lb2", "준비금", 200, 15, 180, 255, 10);
            Label 준비금 = ct.lable(pn2_lb2);
            영업시작.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(준비금);

            //준비금 텍스트박스
            tbSet pn2_txbox = new tbSet(this, "pn2_txbox", 120, 20, 150, 270);
            TextBox 준비금텍스트박스 = ct.txtbox(pn2_txbox);
            Controls.Add(준비금텍스트박스);
            준비금텍스트박스.TextAlign = HorizontalAlignment.Center;
            
            //영업시작 패널
            pnSet pn2 = new pnSet(this, 400, 350, 570, 200);
            Panel 패널2 = ct.panel(pn2);
            패널2.BackColor = Color.LightGray;
            Controls.Add(패널2);   //패널 화면 출력
            패널2.Controls.Add(영업시작버튼);
            패널2.Controls.Add(영업시작);
            패널2.Controls.Add(준비금);
            패널2.Controls.Add(준비금텍스트박스);

            //관리자 시작 파트
            //관리자 버튼
            btnSet pn3_btn_1 = new btnSet(this, "pn3_btn_1", "//사진으로 대체", 130, 130, 140, 70, btn1_Click);
            Button 관리자버튼= ct.btn(pn3_btn_1);
            Controls.Add(관리자버튼);

            //관리자 라벨
            lbSet pn3_lb1 = new lbSet(this, "pn3_lb1", "관리자", 200, 33, 150, 210, 25);
            Label 관리자 = ct.lable(pn3_lb1);
            영업시작.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(관리자);

            //관리자 패널
            pnSet pn3 = new pnSet(this, 400, 350, 1040, 200);
            Panel 패널3 = ct.panel(pn3);
            패널3.BackColor = Color.LightGray;
            Controls.Add(패널3);   //패널 화면 출력
            패널3.Controls.Add(관리자버튼);
            패널3.Controls.Add(관리자);
            
        
            //경고문 라벨
            pn4_lb = new lbSet(this, "label2", "영업중이 아닙니다. 판매를 하시려면 영업시작을 눌러주십시오.", 1500, 30, 385, 27, 20);
            Label 경고문 = ct.lable(pn4_lb);
            Controls.Add(경고문);

            pn5_lb = new lbSet(this, "label2", "영업중 입니다. 판매를 종료하시려면 영업종료를 눌러주십시오.", 1500, 30, 385, 27, 20);

            //하단부 패널
            pnSet pn4 = new pnSet(this, 1500, 150, 0, 800);
            Panel 패널4 = ct.panel(pn4);
            패널4.BackColor = Color.LightGray;
            Controls.Add(패널4);   
            패널4.Controls.Add(경고문);
        }

        //시작버튼 효과
        private void btn_Click(object sender, EventArgs e)
        {
            MainPos MP = new MainPos();
            pn4_lb = pn5_lb; //바뀌어야함
            
            MP.Show();
        }

        //관리자버튼 효과
        private void btn1_Click(object sender, EventArgs e)
        {
            ManagerForm MF = new ManagerForm();
            this.Dispose(false);
            MF.Show();

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
