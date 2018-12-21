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
using WindowsFormsApp;

/*===========================================================================================================================================

// 클릭시 버튼 색상 변경해줘야 함.
// 아래 클릭버튼 주석 관련된것 해줘야함.

 =============================================================================================================================================*/

namespace mojavePos
{
    public partial class FORM_01 : Form
    {
        _Create ct = new _Create();
        TextBox textbox , 텍스트박스1 , 텍스트박스2;
        FORM_01 F1;
        FORM_03 F3;
        public FORM_01()
        {
            InitializeComponent();
            Load += FORM_01_Load;
        }

        private void FORM_01_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(750, 430);  // 폼 사이즈 지정
            //this.ControlBox = false;
            BackColor = Color.Black;

            // 제목 패널
            pnSet pn1 = new pnSet(this, 750, 110, 0, 0);
            Panel 패널 = ct.panel(pn1);
            패널.BackColor = Color.FromArgb(52, 152, 219);
            Controls.Add(패널);   //패널 화면 출력

            ArrayList arr = new ArrayList();

            arr.Add(new lbSet(this, "lb1", "ELBON", 500, 35, 330, 10, 40));
            arr.Add(new lbSet(this, "lb2", "the table", 300, 70, 260, 30, 20));

            for (int i = 0; i < arr.Count; i++)
            {
                if (typeof(lbSet) == arr[i].GetType())
                {
                    Label label = ct.lable((lbSet)arr[i]);
                    if(i==1) label.Font = new Font("Tahoma", 40, FontStyle.Bold); //글꼴설정
                    else label.Font = new Font("Tahoma", 20, FontStyle.Bold);
                    패널.Controls.Add(label);
                }
            }

            //로그인 패널
            tbSet tx1 = new tbSet(this, "tb1", 200, 35, 370, 50);
            텍스트박스1 = ct.txtbox(tx1);
            Controls.Add(텍스트박스1);

            tbSet tx2 = new tbSet(this, "tb2", 200, 35, 370, 100);
            텍스트박스2 = ct.txtbox(tx2);
            Controls.Add(텍스트박스2);

            pnSet pn2 = new pnSet(this, 750, 169, 0, 110);
            Panel 패널2 = ct.panel(pn2);
            패널2.BackColor = Color.White;
            Controls.Add(패널2);
            패널2.Controls.Add(텍스트박스1);
            패널2.Controls.Add(텍스트박스2);


            ArrayList arr1 = new ArrayList();
            arr1.Add(new lbSet(this, "lb3", "Name ", 150, 20, 190, 50,15));
            arr1.Add(new lbSet(this, "lb4", "Password", 150, 20, 190, 100, 15));
           
            for (int i = 0; i < arr1.Count; i++)
            {
                if (typeof(lbSet) == arr1[i].GetType())
                {
                    Label label = ct.lable((lbSet)arr1[i]);
                    label.Font = new Font("Tahoma", 15, FontStyle.Bold);
                    패널2.Controls.Add(label);
                }
            }
            //끝 패널
            pnSet pn3 = new pnSet(this, 750, 160, 0, 280);
            Panel 패널3 = ct.panel(pn3);
            패널3.BackColor = Color.White;
            Controls.Add(패널3);   //패널 화면 출력

            ArrayList arr2 = new ArrayList();
            arr2.Add(new btnSet(this, "button", "로그인", 250, 40, 260, 35, btn_Click));
            arr2.Add(new btnSet(this, "button", "계정만들기", 130, 30, 320, 85, btn2_Click));
            for (int i = 0; i < arr2.Count; i++)
            {
                if (typeof(btnSet) == arr2[i].GetType())
                {
                    Button button = ct.btn((btnSet)arr2[i]);
                    button.Font = new Font("Tahoma", 8, FontStyle.Regular);
                    패널3.Controls.Add(button);
                }
            }
        }

        private void btn_Click(object sender, EventArgs e) //클릭버튼 수정할것.
        {
            Module api = new Module();
            api = new Module();
            
            //(textBox_Results != null && !string.IsNullOrWhiteSpace(textBox_Results.Text))
            F3 = new FORM_03();
            F1 = new FORM_01();
            if (텍스트박스1.Text.Length == 0 || 텍스트박스2.Text.Length == 0)
            {
                MessageBox.Show("입력을 받지 않았습니다. 다시 입력해주시기 바랍니다.");
            }
            else
            {

            }
            /*
            else if()
            {

            }
            else
            {

            }*/
            
            
            
            //입력값이 DB의 값과 틀렸을때(틀렸습니다. 다시입력해주세요) 나오게 할것.
            //비밀번호가 5회 이상 틀렸으면 아이디 정지시키고 연락해달라고 할것.
            //입력값이 맞다면 F3 로 넘어갈것.
            
            //this.Dispose(false);
            //F3.Show();
        }
        

        private void btn2_Click(object sender, EventArgs e)
        {
            FORM_02 F2 = new FORM_02();
            F2.Show();
        }

    }
}
