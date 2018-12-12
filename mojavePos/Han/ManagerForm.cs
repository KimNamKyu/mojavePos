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
    public partial class ManagerForm : Form
    {
        _Create ct = new _Create();
        Panel bottom;
        private Graphics gr;
        MenuForm menu;

        public ManagerForm()
        {
            InitializeComponent();
            Load += MemberForm_Load;
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(1500, 900);
            this.IsMdiContainer = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Head();

          
        }
       
       
        private void Head()
        {
            pnSet pn1 = new pnSet(this, 1500, 100, 0, 0);
            Panel head = ct.panel(pn1);
            Controls.Add(head);
            /*-------------메뉴박스------------------*/

            lbSet lb1 = new lbSet(this, "lb1", "Category", 200, 35, 350, 80, 25);
            Label 카테고리 = ct.lable(lb1);
            카테고리.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(카테고리);

            btnSet btn_1 = new btnSet(this, "btn_1", "//사진으로 대체", 30, 30, 460, 125, btn_Click);
            Button 카테고리추가버튼 = ct.btn(btn_1);
            Controls.Add(카테고리추가버튼);

            pictureBoxSet picturebox_1 = new pictureBoxSet(this, 40, 40, 410, 120, " ");
            PictureBox 카테고리픽쳐 = ct.picture(picturebox_1);
            카테고리픽쳐.BackColor = Color.Green;
            Controls.Add(카테고리픽쳐);

            lbSet lb2 = new lbSet(this, "lb2", "Menu", 200, 35, 1000, 80, 25);
            Label 메뉴 = ct.lable(lb2);
            카테고리.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(메뉴);

            btnSet btn_2 = new btnSet(this, "btn_2", "//사진으로 대체", 30, 30, 1060, 125, btn2_Click);
            Button 메뉴추가버튼 = ct.btn(btn_2);
            Controls.Add(메뉴추가버튼);

            pictureBoxSet picturebox_2 = new pictureBoxSet(this, 40, 40, 1010, 120, " ");
            PictureBox 메뉴픽쳐 = ct.picture(picturebox_2);
            메뉴픽쳐.BackColor = Color.Green;
            Controls.Add(메뉴픽쳐);

            /*-----------*/
            gr = this.CreateGraphics();
            Pen pen1 = new Pen(Color.Black, 1);
            pen1.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            Point First = new Point(300, 300);
            Point Second = new Point(1200, 300);
            /*-----------*/

            pnSet pn2 = new pnSet(this, 1500, 800, 0, 100);
            bottom = ct.panel(pn2); // 패널이름 : bottom
            Controls.Add(bottom);
            bottom.Controls.Add(카테고리);
            bottom.Controls.Add(카테고리추가버튼);
            bottom.Controls.Add(카테고리픽쳐);
            bottom.Controls.Add(메뉴);
            bottom.Controls.Add(메뉴추가버튼);
            bottom.Controls.Add(메뉴픽쳐);
            //bottom.Controls.Add(pen1);

            head.BackColor = Color.Black;
            bottom.BackColor = Color.BurlyWood;
            /*----------------------------*/
            ArrayList btn_list = new ArrayList();
            btn_list.Add(new btnSet(this, "menu", "메뉴관리", 375, 100, 0, 0, Main_Click));
            btn_list.Add(new btnSet(this, "money", "매출관리", 375, 100, 375, 0, Main_Click));
            btn_list.Add(new btnSet(this, "user", "회원관리", 375, 100, 750, 0, Main_Click));
            btn_list.Add(new btnSet(this, "exit", "종료", 375, 100, 1125, 0, Main_Click));
            
            for(int i=0; i < btn_list.Count; i++)
            {
                Button button = ct.btn((btnSet)btn_list[i]);
                head.Controls.Add(button);
            }

        }
        private void Main_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Name)
            {
                case "menu":
                    MenuForm menu = new MenuForm();
                    menu.MdiParent = this;
                    menu.WindowState = FormWindowState.Maximized;
                    menu.FormBorderStyle = FormBorderStyle.None;
                    bottom.Controls.Add(menu);
                    menu.Show();
                    break;
                case "money":
                    MoneyForm  money= new MoneyForm();
                    money.MdiParent = this;
                    money.WindowState = FormWindowState.Maximized;
                    money.FormBorderStyle = FormBorderStyle.None;
                    bottom.Controls.Add(money);
                    money.Show();
                    break;
                case "user":
                    UserForm user = new UserForm();
                    user.MdiParent = this;
                    user.WindowState = FormWindowState.Maximized;
                    user.FormBorderStyle = FormBorderStyle.None;
                    bottom.Controls.Add(user);
                    user.Show();
                    break;
                case "exit":
                    this.Close();
                    break;
            }
        }
        private void btn_Click(object sender, EventArgs e)
        {

        }
        private void btn2_Click(object sender, EventArgs e)
        {

        }
    }
}
