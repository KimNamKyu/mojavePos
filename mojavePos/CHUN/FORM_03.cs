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
       
        lbSet pn4_lb, pn5_lb;
        Label 시간, 날짜, 경고문;
        Timer timer;
        _Create ct;
        Panel 패널4;
        public FORM_03()
        {
            InitializeComponent();
            Load += FORM_03_Load;
          
        }

        public void FORM_03_Load(object sender, EventArgs e)
        {
            
            ClientSize = new Size(750, 430);
            ct = new _Create();
            BackColor = Color.FromArgb(191, 191, 191);
            this.StartPosition = FormStartPosition.Manual;
            
            //날짜라벨
            lbSet pn1_lb5 = new lbSet(this, "pn1_lb5", "//날짜", 250, 30, 5, 240, 15);
            날짜 = ct.lable(pn1_lb5);
            날짜.TextAlign = ContentAlignment.MiddleCenter;
            날짜.Font = new Font("Tahoma", 15, FontStyle.Bold);
            날짜.ForeColor = Color.White;
            Controls.Add(날짜);
            
            //시간라벨
            lbSet pn1_lb6 = new lbSet(this, "pn1_lb6", "//시간", 170, 30, 45, 270, 15);
            시간 = ct.lable(pn1_lb6);
            시간.TextAlign = ContentAlignment.MiddleCenter;
            시간.Font = new Font("Tahoma", 15, FontStyle.Bold);
            시간.ForeColor = Color.White;
            Controls.Add(시간);

            //패널
            pnSet pn1 = new pnSet(this, 250, 350, 0, 0);
            Panel 패널1 = ct.panel(pn1);
            패널1.BackColor = Color.FromArgb(19, 38, 78);
            Controls.Add(패널1);   //패널 화면 출력
            패널1.Controls.Add(날짜);
            패널1.Controls.Add(시간);

            //그림넣기

            ArrayList arr = new ArrayList();
            arr.Add(new lbSet(this, "label1", "오늘매출액", 100, 25, 70, 70, 10));
            arr.Add(new lbSet(this, "label1_1", "10,000,000", 100, 25, 60, 100, 10));
            arr.Add(new lbSet(this, "label1_2", "원", 20, 25, 160, 100, 10));
            arr.Add(new lbSet(this, "pn1_lb2", "분기 매출액", 110, 25, 70, 140, 10));
            arr.Add(new lbSet(this, "pn1_lb2_0", "2", 20, 25, 58, 140, 10));
            arr.Add(new lbSet(this, "pn1_lb2_1", "10,000,000", 100, 25, 60, 170, 10));
            arr.Add(new lbSet(this, "pn1_lb2_2", "원", 20, 25, 160, 170, 10));
            
            for(int i = 0; i< arr.Count; i++)
            {
                if(typeof(lbSet) == arr[i].GetType())
                {
                    Label label = ct.lable((lbSet)arr[i]);
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.ForeColor = Color.White;
                    label.Font = new Font("Tahoma", 10, FontStyle.Bold);
                    패널1.Controls.Add(label);
                }
            }
            //영업시작 파트
            //영업시작 버튼
            btnSet pn2_btn_1 = new btnSet(this, "pn2_btn_1", " ", 80, 80, 50, 30, btn_Click);
            Button 영업시작버튼 = ct.btn(pn2_btn_1);
            영업시작버튼.Font = new Font("Tahoma", 10, FontStyle.Bold);
            영업시작버튼.BackgroundImage = mojavePos.Properties.Resources.test2;
            Controls.Add(영업시작버튼);

            //영업시작 라벨
            lbSet pn2_lb1 = new lbSet(this, "pn2_lb1", "영업시작",  130, 30, 30, 120, 20);
            Label 영업시작 = ct.lable(pn2_lb1);
            영업시작.TextAlign = ContentAlignment.MiddleCenter;
             영업시작.Font = new Font("Tahoma", 20, FontStyle.Bold);
            Controls.Add(영업시작);

            //준비금 라벨
            lbSet pn2_lb2 = new lbSet(this, "pn2_lb2", "준비금", 55, 15,65, 155, 10);
            Label 준비금 = ct.lable(pn2_lb2);
            준비금.TextAlign = ContentAlignment.MiddleCenter;
            준비금.Font = new Font("Tahoma", 10, FontStyle.Bold);
            Controls.Add(준비금);

            //준비금 텍스트박스
            tbSet pn2_txbox = new tbSet(this, "pn2_txbox", 120, 20, 33, 175);
            TextBox 준비금텍스트박스 = ct.txtbox(pn2_txbox);
            준비금텍스트박스.Font = new Font("Tahoma", 10, FontStyle.Bold);
            준비금텍스트박스.TextAlign = HorizontalAlignment.Center;
            Controls.Add(준비금텍스트박스);
            

            //영업시작 패널
            pnSet pn2 = new pnSet(this, 180, 220, 300, 70);
            Panel 패널2 = ct.panel(pn2);
            패널2.BackColor = Color.FromArgb(232, 227, 227);
            Controls.Add(패널2);   //패널 화면 출력
            패널2.Controls.Add(영업시작버튼);
            패널2.Controls.Add(영업시작);
            패널2.Controls.Add(준비금);
            패널2.Controls.Add(준비금텍스트박스);

            
            //관리자 시작 파트
            //관리자 버튼
            btnSet pn3_btn_1 = new btnSet(this, "pn3_btn_1", " ", 80, 80, 50, 30, btn1_Click);
            Button 관리자버튼 = ct.btn(pn3_btn_1);
            관리자버튼.Font = new Font("Tahoma", 10, FontStyle.Bold);
           
            관리자버튼.BackgroundImage = mojavePos.Properties.Resources.test2;
          

            Controls.Add(관리자버튼);

            //관리자 라벨
            lbSet pn3_lb1 = new lbSet(this, "pn3_lb1", "관리자", 100, 35, 45, 120, 20);
            Label 관리자 = ct.lable(pn3_lb1);
             관리자.Font = new Font("Tahoma", 20, FontStyle.Bold);
            영업시작.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(관리자);

            //관리자 패널
            pnSet pn3 = new pnSet(this, 180, 220, 520, 70);
            Panel 패널3 = ct.panel(pn3);
            패널3.BackColor = Color.FromArgb(232, 227, 227);
            Controls.Add(패널3);   //패널 화면 출력
            패널3.Controls.Add(관리자버튼);
            패널3.Controls.Add(관리자);


            //경고문 라벨
            pn4_lb = new lbSet(this, "label2", "영업중이 아닙니다. 판매를 하시려면 영업시작을 눌러주십시오.", 1500, 30, 80, 12, 15);
            pn5_lb = new lbSet(this, "label2", "영업중 입니다. 판매를 종료하시려면 영업종료를 눌러주십시오.", 1500, 30, 90, 12, 15);
            Label 경고문 = ct.lable(pn4_lb);
            경고문.Font = new Font("Tahoma", 15, FontStyle.Bold);
            Controls.Add(경고문);

            //하단부 패널
            pnSet pn4 = new pnSet(this, 750, 50, 0,380);
            Panel 패널4 = ct.panel(pn4);
            패널4.BackColor = Color.FromArgb(232, 227, 227);
            Controls.Add(패널4);
            패널4.Controls.Add(경고문);
            

            Control_Init();
        }

        private void Control_Init()
        {
            timer = new Timer();
            timer.Tick += Timer_Tick1;
            timer.Start();
        }

        private void Timer_Tick1(object sender, EventArgs e)
        {
            시간.Text = string.Format("{0:HH:mm:ss}", DateTime.Now);
            날짜.Text = string.Format("{0:yyyy.MM.dd (dddd)}", DateTime.Now);
        }
        

        //시작버튼 효과
        private void btn_Click(object sender, EventArgs e)
        {
            MainPos MP = new MainPos();
            if(MessageBox.Show("영업을 시작 하시겠습니까?","",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                
                MP.Show();               
                //하위라벨 및 버튼라벨 바꾸기
                //경고문.Text = "영업중 입니다.판매를 종료하시려면 영업종료를 눌러주십시오.";
            }
            else if(MessageBox.Show("영업을 종료 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                //하위 라벨 및 버튼 바꾸기
            }
        }

        //관리자버튼 효과
        private void btn1_Click(object sender, EventArgs e)
        {
            ManagerForm MF = new ManagerForm();
           
            MF.Show();

        }
      
    }
}
