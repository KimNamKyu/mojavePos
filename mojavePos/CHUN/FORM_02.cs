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

/*-----------------------------------------------------------------
 // 클릭시 버튼 색상 변경해줘야 함.
 // 아이디는 하나만 만들어야 하니, DB에 No = 2 이상은 넣어지면 안된다. => 경고박스("이미 한개이상 가입 하였습니다 한 포스기당 하나의 아이디만 가입할수 있습니다.")가 뜨고 디비에 올라가지면 안된다.
 // 모듈화 시켜서 만들어 놓기.
------------------------------------------------------------------*/

namespace mojavePos
{
    public partial class FORM_02 : Form
    {
        


        //static ToolStripStatusLabel StripLb;
        //StatusStrip statusStrip;
        _Create ct;
        TextBox 네임택박, 포지션택박, 패스워드택박, 시리얼택박;
        FORM_01 F1;
        private string PS_No;

        public FORM_02()
        {
            InitializeComponent();
            Load += FORM_02_Load;
        }

        private void FORM_02_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(750, 430);  //폼 사이즈
            this.ControlBox = false;        //최소화 최대화 버튼 없애기

            ct = new _Create();

            //Name 라벨 출력
            lbSet lb1 = new lbSet(this, "label1", "Name", 50, 15, 90, 50, 10);
            Label 라벨1 = ct.lable(lb1);
            라벨1.Font = new Font("Tahoma", 10, FontStyle.Bold);
            Controls.Add(라벨1);

            //Name 텍스트박스 출력
            tbSet tx1 = new tbSet(this, "txt1", 170, 30, 30, 70);
            네임택박 = ct.txtbox(tx1);
            Controls.Add(네임택박);

            //Postion 라벨 출력
            lbSet lb2 = new lbSet(this, "label2", "Postion", 100, 15, 80, 110, 10);
            Label 라벨2 = ct.lable(lb2);
            라벨2.Font = new Font("Tahoma", 10, FontStyle.Bold);
            Controls.Add(라벨2);

            //Postion 텍스트박스 출력
            tbSet tx2 = new tbSet(this, "txt2", 170, 30, 30, 130);
            포지션택박 = ct.txtbox(tx2);
            Controls.Add(포지션택박);

            //Password 라벨 출력
            lbSet lb3 = new lbSet(this, "label3", "Password", 100, 15, 70, 170, 10);
            Label 라벨3 = ct.lable(lb3);
            라벨3.Font = new Font("Tahoma", 10, FontStyle.Bold);
            Controls.Add(라벨3);

            //Password 텍스트박스 출력
            tbSet tx3 = new tbSet(this, "txt3", 170, 30, 30, 190);
            패스워드택박 = ct.txtbox(tx3);
            Controls.Add(패스워드택박);

            //Serial 라벨 출력
            lbSet lb4 = new lbSet(this, "label4", "Serial Number", 100, 15, 85, 230, 10);
            Label 라벨4 = ct.lable(lb4);
            라벨4.Font = new Font("Tahoma", 10, FontStyle.Bold);
            Controls.Add(라벨4);

            //Serial 텍스트박스 출력
            tbSet tx4 = new tbSet(this, "txt4", 170, 30, 30, 250);
            시리얼택박 = ct.txtbox(tx4);
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
            패널.BackColor = Color.FromArgb(52, 152, 219);

            Controls.Add(패널); //패널 안에 라벨 텍스트박스 출력
            패널.Controls.Add(라벨1);
            패널.Controls.Add(라벨2);
            패널.Controls.Add(라벨3);
            패널.Controls.Add(라벨4);
            패널.Controls.Add(네임택박);
            패널.Controls.Add(포지션택박);
            패널.Controls.Add(패스워드택박);
            패널.Controls.Add(시리얼택박);


            lbSet lb5 = new lbSet(this, "label5", "- ELBON the table 을 위한 포스기.", 240, 15, 15, 50, 10);
            Label 라벨5 = ct.lable(lb5);
            라벨5.Font = new Font("Tahoma", 10, FontStyle.Bold);
            Controls.Add(라벨5);

            lbSet lb6 = new lbSet(this, "label6", "Mojave of Pos", 200, 25, 250, 43, 17);
            Label 라벨6 = ct.lable(lb6);
            라벨6.Font = new Font("Tahoma", 15, FontStyle.Bold);
            Controls.Add(라벨6);

            lbSet lb7 = new lbSet(this, "label7", "1. Mojave of Pos 는 'Mojave/모하비'에서 제작하였습니다.", 350, 15, 15, 80, 8);
            Label 라벨7 = ct.lable(lb7);
            라벨7.Font = new Font("Tahoma", 8, FontStyle.Bold);
            Controls.Add(라벨7);

            lbSet lb8 = new lbSet(this, "label8", "2. Mojave of Pos는 ELBON the table의 효율적인 재정관리를 할 수 있도록 돕기 위해 제작 되었습니다.", 380, 30, 15, 110, 8);
            Label 라벨8 = ct.lable(lb8);
            라벨8.Font = new Font("Tahoma", 8, FontStyle.Bold);
            Controls.Add(라벨8);

            lbSet lb9 = new lbSet(this, "label9", "3. Mojave of Pos는 자체 제공한 시리얼넘버로 하나의 아이디만 회원가입할수 있습니다.", 380, 30, 15, 155, 8);
            Label 라벨9 = ct.lable(lb9);
            라벨9.Font = new Font("Tahoma", 8, FontStyle.Bold);
            Controls.Add(라벨9);

            lbSet lb10 = new lbSet(this, "label10", "4. Mojave of Pos는 비밀번호찾기 기능을 따로 제공하지 않습니다.", 380, 15, 15, 200, 8);
            Label 라벨10 = ct.lable(lb10);
            라벨10.Font = new Font("Tahoma", 8, FontStyle.Bold);
            Controls.Add(라벨10);

            lbSet lb11 = new lbSet(this, "label6", "5. Mojave of Pos안의 ELBON the table 정보는 절대 외부에 공개 하지 않습니다.", 380, 30, 15, 230, 8);
            Label 라벨11 = ct.lable(lb11);
            라벨11.Font = new Font("Tahoma", 8, FontStyle.Bold);
            Controls.Add(라벨11);

            lbSet lb12 = new lbSet(this, "label12", "6. Mojave of Pos는 포스기에 최적화 되어 있습니다.", 380, 15, 15, 275, 8);
            Label 라벨12 = ct.lable(lb12);
            라벨12.Font = new Font("Tahoma", 8, FontStyle.Bold);
            Controls.Add(라벨12);

            lbSet lb13 = new lbSet(this, "label13", "문의사항 : question@MojaveKorea.co.kr", 380, 15, 15, 310, 8);
            Label 라벨13 = ct.lable(lb13);
            라벨13.Font = new Font("Tahoma", 8, FontStyle.Bold);
            Controls.Add(라벨13);


            //오른쪽 패널 출력
            pnSet pn2 = new pnSet(this, 420, 370, 300, 30);
            Panel 패널2 = ct.panel(pn2);
            패널2.BackColor = Color.FromArgb(232, 227, 227);
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

        }
        private void btn_Click(object sender, EventArgs e)
        {

            F1 = new FORM_01();
            //this.Dispose(false);

            if (네임택박.Text.Length == 0 || 포지션택박.Text.Length == 0 || 패스워드택박.Text.Length == 0 || 시리얼택박.Text.Length == 0)
            {
                MessageBox.Show("입력을 받지 않았습니다. 다시 입력해주세요.");
            }
            else
            {
                if (시리얼택박.Text != "1111")

                {
                    MessageBox.Show("시리얼 번호가 맞지 않습니다. 다시 입력해주시기 바랍니다.");
                }
                else
                {
                    common(1);
                    F1.Show();
                }
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            F1 = new FORM_01();
            //this.Dispose(false);
            F1.Show();
        }

        private void listview_Click(object o, EventArgs e)
        {
            ListView lv = (ListView)o;
            ListView.SelectedListViewItemCollection slv = lv.SelectedItems;
            for (int i = 0; i < slv.Count; i++)
            {
                ListViewItem item = slv[i];
                //MessageBox.Show(item.SubItems[0].Text);
                PS_No = item.SubItems[0].Text;
                네임택박.Text = item.SubItems[1].Text;
                포지션택박.Text = item.SubItems[2].Text;
                패스워드택박.Text = item.SubItems[3].Text;
                시리얼택박.Text = item.SubItems[4].Text;
            }
        }

        //예외처리 PS_No >= 2 일때 DB에 넣어지면 안된다.

        public void common(int type)
        {
            Hashtable ht = new Hashtable();
            switch (type)
            {
                case 1:

                    ht = new Hashtable();
                    ht.Add("@PS_Id", 네임택박.Text);
                    ht.Add("@PS_Rank", 포지션택박.Text);
                    ht.Add("@PS_passwd", 패스워드택박.Text);
                    ht.Add("@PS_code", 시리얼택박.Text);
                   

                    //label1.Text = textBox1.Text;

                    break;
                default:
                    break;
            }

        }
    }
}

